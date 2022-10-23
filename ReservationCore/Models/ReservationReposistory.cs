namespace ReservationCore.Models
{
    public class ReservationReposistory : IResevationRepository
    {
        private HotelReservationContext wiredContext;

        public ReservationReposistory(HotelReservationContext context)
        {
            wiredContext = context;
        }

        public void Add(Reservations product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservations> GetAll()
        {
            return wiredContext.Reservations.ToList();
        }

        public Reservations GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Reservations product)
        {
            throw new NotImplementedException();
        }
    }
}
