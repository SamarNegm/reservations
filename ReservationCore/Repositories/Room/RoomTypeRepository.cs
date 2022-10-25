using ReservationCore.Models;

namespace ReservationCore.Repositories.RoomRepo
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        HotelReservationContext wiredContext;
        public RoomTypeRepository(HotelReservationContext wiredContext)
        {
            this.wiredContext = wiredContext;
        }

        List<RoomType> IRoomTypeRepository.GetAll()
        {
            return wiredContext.RoomType.ToList();
        }
    }
}
