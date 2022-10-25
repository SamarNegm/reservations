using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReservationCore.Models;
using ReservationCore.ReservationsRepos;

namespace App.UI.Pages.Reservations
{
    public class AddReservationModel : PageModel
    {
        private IResevationRepository resevationRepository;
        private IWebHostEnvironment environment;

        public AddReservationModel(IResevationRepository resevationRepository, IWebHostEnvironment environment)
        {
            this.resevationRepository = resevationRepository;
            this.environment = environment;
        }
        public void OnGet()
        {
        }
        [BindProperty]
        public Reservation NewReservation { get; set; }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) { return Page(); }

            this.resevationRepository.Add(NewReservation);

            return RedirectToPage("ViewAllReservations");
        }

    }
}
