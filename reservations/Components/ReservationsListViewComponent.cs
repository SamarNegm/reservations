using Microsoft.AspNetCore.Mvc;
using ReservationCore.ReservationsRepos;

namespace App.UI.Components
{
    public class ReservationsListViewComponent : ViewComponent
    {
        private IResevationRepository resevationRepository;

        public ReservationsListViewComponent(IResevationRepository resevationRepository)
        {
            this.resevationRepository = resevationRepository;
        }
        public IViewComponentResult Invoke()
        {
            var items = resevationRepository.GetAll();

            return View(items);
        }
    }
}
