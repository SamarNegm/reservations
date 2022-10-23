namespace ReservationCore.Models
{
    public interface IResevationRepository
    {
        public void Add(Reservations reservation);
        public void Update(Reservations reservation);
        public Reservations GetById(int id);
        public List<Reservations> GetAll();
        public void Delete(int id);
    }
}
