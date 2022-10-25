using ReservationCore.Models;

namespace ReservationCore.Repositories.RoomRepo
{
    public interface IRoomTypeRepository
    {
        public List<RoomType> GetAll();
    }
}
