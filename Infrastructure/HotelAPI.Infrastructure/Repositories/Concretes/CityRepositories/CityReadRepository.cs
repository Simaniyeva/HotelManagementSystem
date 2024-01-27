namespace HotelAPI.Infrastructure.Repositories.Concretes.CityRepositories;

public class CityReadRepository : ReadRepository<City>, ICityReadRepository
{
    public CityReadRepository(HotelIdentityDbContext context) : base(context) { }
}
