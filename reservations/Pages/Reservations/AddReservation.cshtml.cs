using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReservationCore.Models;
using ReservationCore.Repositories.MealsRepo;
using ReservationCore.Repositories.RoomRepo;
using ReservationCore.Repositories.Seasons;
using ReservationCore.ReservationsRepos;

namespace App.UI.Pages.Reservations
{
    public class AddReservationModel : PageModel
    {
        private IResevationRepository resevationRepository;
        private IWebHostEnvironment environment;
        private IMealsRepository mealRepository;
        private IRoomTypeRepository roomTypeRepository;
        private ISeasonRepository seasonRepository;

        public AddReservationModel(IResevationRepository resevationRepository,
            IMealsRepository mealRepository,
            IRoomTypeRepository roomTypeRepository,
            ISeasonRepository seasonRepository,
            IWebHostEnvironment environment)
        {
            this.resevationRepository = resevationRepository;
            this.environment = environment;
            this.mealRepository = mealRepository;
            this.roomTypeRepository = roomTypeRepository;
            this.seasonRepository = seasonRepository;
        }
        [BindProperty]
        public Reservation NewReservation { get; set; }
        public List<MealPlan> MealPlans { get; set; }
        public List<RoomType> Rooms { get; set; }
        public List<Season> Seasons { get; set; }
        public decimal TotalPrice { get; set; }
        private void init()
        {
            MealPlans = mealRepository.GetAll();
            Rooms = roomTypeRepository.GetAll();
            Seasons = seasonRepository.GetAll();
        }
        public void OnGet()
        {
            init();
            TotalPrice = 0;
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid || NewReservation.Checkout < NewReservation.Checkin)
            {
                init();
                return Page();
            }

            this.resevationRepository.Add(NewReservation);
            GetReservationTotal(NewReservation);
            init();
            return Page();
        }

        private void GetReservationTotal(Reservation newReservation)
        {
            decimal TotalPricePerDay = GetTotalMealsPrice(newReservation) + GetTotalRoomsPrice(newReservation);
            int totalNumberOfDays = (newReservation.Checkout.Subtract(newReservation.Checkin).Days);
            TotalPrice = TotalPricePerDay * totalNumberOfDays;
        }

        private decimal GetTotalMealsPrice(Reservation newReservation)
        {
            decimal mealPrice = seasonRepository.GetSeasonMealPrice(newReservation.MealId, newReservation.SeasonId);
            decimal totalMealsPrice = (newReservation.Adults + (newReservation.Child ?? 0)) * mealPrice;

            return totalMealsPrice;

        }

        private decimal GetTotalRoomsPrice(Reservation newReservation)
        {
            int totalNumberOfAdultsRooms = newReservation.Adults / 2 + newReservation.Adults % 2;
            int totalNumberOfChildsRooms = (newReservation.Child ?? 0) / 2 + (newReservation.Child ?? 0) % 2;
            int totalNumberOfRooms = totalNumberOfAdultsRooms;
            if (totalNumberOfChildsRooms > totalNumberOfAdultsRooms)
            {
                totalNumberOfRooms += (newReservation.Child ?? 0 - totalNumberOfAdultsRooms * 2) / 4 + (((newReservation.Child ?? 0) - totalNumberOfAdultsRooms * 2) % 4 == 0 ? 0 : 1);
            }
            decimal roomPrice = seasonRepository.GetSeasonRoomPrice(newReservation.RoomId, newReservation.SeasonId);
            return totalNumberOfRooms * roomPrice;
        }
    }
}
