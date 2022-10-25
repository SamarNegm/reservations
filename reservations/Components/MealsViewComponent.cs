using Microsoft.AspNetCore.Mvc;
using ReservationCore.Repositories.MealsRepo;
namespace App.UI.Components
{
    public class MealsViewComponent : ViewComponent
    {
        private IMealsRepository mealRepository;

        public MealsViewComponent(IMealsRepository mealRepository)
        {
            this.mealRepository = mealRepository;
        }

        public IViewComponentResult Invoke()
        {
            var items = mealRepository.GetAll();

            return View(items);
        }
    }
}
