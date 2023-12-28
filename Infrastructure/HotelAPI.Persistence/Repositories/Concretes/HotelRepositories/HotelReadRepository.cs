namespace HotelAPI.Persistence.Repositories.Concretes.HotelRepositories;

public class HotelReadRepository : ReadRepository<Hotel>, IHotelReadRepository
{
    public HotelReadRepository(HotelIdentityDbContext context) : base(context) { }
}
