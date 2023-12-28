namespace HotelAPI.Persistence.Repositories.Concretes.ReservatorRepositories;
public class ReservatorReadRepository : ReadRepository<Reservator>, IReservatorReadRepository
{
    public ReservatorReadRepository(HotelIdentityDbContext context) : base(context) { }
}

