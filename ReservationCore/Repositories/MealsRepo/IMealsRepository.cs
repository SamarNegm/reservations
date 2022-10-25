using ReservationCore.Models;

namespace ReservationCore.Repositories.MealsRepo
{
    public interface IMealsRepository
    {
        public List<MealPlan> GetAll();

    }
}
