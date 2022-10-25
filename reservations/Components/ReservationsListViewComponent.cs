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
        public IViewComponentResult Invoke(int count)
        {
            var items = resevationRepository.GetAll();
            if (count > 0)
            {
                return View(items.Take(count).ToList());

            }
            return View(items);
        }
    }
}
