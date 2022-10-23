using Microsoft.AspNetCore.Mvc.RazorPages;
using ReservationCore.Models;

namespace App.UI.Pages.Reservation
{
    public class ViewAllReservationsModel : PageModel
    {
        private IResevationRepository resevationRepository;

        public ViewAllReservationsModel(IResevationRepository resevationRepository)
        {
            this.resevationRepository = resevationRepository;

        }
        List<Reservations> OurReservations { get; set; }

        public void OnGet()
        {
            OurReservations = resevationRepository.GetAll();
        }
    }
}
