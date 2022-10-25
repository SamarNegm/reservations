using ReservationCore.Models;

namespace ReservationCore.Repositories.Seasons
{
    public class SeasonRepository : ISeasonRepository
    {
        HotelReservationContext HotelReservationContext;
        public SeasonRepository(HotelReservationContext hotelReservationContext)
        {
            HotelReservationContext = hotelReservationContext;
        }

        public List<Season> GetAll()
        {
            return HotelReservationContext.Season.ToList();
        }

        public List<SeasonsMealPrice> GetSeasonMealPrices()
        {
            return HotelReservationContext.SeasonsMealPrice.ToList();
        }

        public decimal GetSeasonMealPrice(int mealId, int seasonId)
        {
            SeasonsMealPrice measonsMealPrice = HotelReservationContext.SeasonsMealPrice.First(item => item.SeasonId == seasonId && item.MealPlanId == mealId);
            return measonsMealPrice.Price;
        }

        public List<SeaonsRoomPrice> GetSeasonRoomPrices()
        {
            return HotelReservationContext.SeaonsRoomPrice.ToList();

        }

        public decimal GetSeasonRoomPrice(int roomId, int seasonId)
        {
            SeaonsRoomPrice seaonsRoomPrice = HotelReservationContext.SeaonsRoomPrice.First(item => item.SeasonId == seasonId && item.RoomId == roomId);
            return seaonsRoomPrice.Price ?? 0;
        }
    }
}
