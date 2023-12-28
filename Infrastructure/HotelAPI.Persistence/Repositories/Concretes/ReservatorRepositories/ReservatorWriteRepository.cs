namespace HotelAPI.Persistence.Repositories.Concretes.ReservatorRepositories;

public class ReservatorWriteRepository : WriteRepository<Reservator>, IReservatorWriteRepository
{
    public ReservatorWriteRepository(HotelIdentityDbContext context) : base(context) { }
}

