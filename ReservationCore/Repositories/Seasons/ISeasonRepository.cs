using ReservationCore.Models;

namespace ReservationCore.Repositories.Seasons
{
    public interface ISeasonRepository
    {
        public List<Season> GetAll();
        public List<SeasonsMealPrice> GetSeasonMealPrices();
        public List<SeaonsRoomPrice> GetSeasonRoomPrices();
        public decimal GetSeasonMealPrice(int mealId, int seasonId);
        public decimal GetSeasonRoomPrice(int roomId, int seasonId);



    }
}
