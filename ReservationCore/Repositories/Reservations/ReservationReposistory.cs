using ReservationCore.Models;

namespace ReservationCore.ReservationsRepos
{
    public class ReservationReposistory : IResevationRepository
    {
        private HotelReservationContext wiredContext;

        public ReservationReposistory(HotelReservationContext context)
        {
            wiredContext = context;
        }

        public void Add(Reservation reservation)
        {

            wiredContext.Add(reservation);

            wiredContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetAll()
        {
            return wiredContext.Reservation.ToList();
        }

        public Reservation GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Reservation product)
        {
            throw new NotImplementedException();
        }
    }
}
