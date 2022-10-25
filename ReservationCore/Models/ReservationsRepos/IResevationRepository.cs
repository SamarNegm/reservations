namespace ReservationCore.Models.ReservationsRepos
{
    public interface IResevationRepository
    {
        public void Add(Reservation reservation);
        public void Update(Reservation reservation);
        public Reservation GetById(int id);
        public List<Reservation> GetAll();
        public void Delete(int id);
    }
}
