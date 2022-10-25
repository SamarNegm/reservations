using ReservationCore.Models;

namespace ReservationCore.Repositories.MealsRepo
{
    public class MealsRepository : IMealsRepository
    {
        private HotelReservationContext wiredContext;
        public MealsRepository(HotelReservationContext wiredContext)
        {
            this.wiredContext = wiredContext;
        }

        public List<MealPlan> GetAll()
        {
            return wiredContext.MealPlan.ToList();
        }
    }
}
