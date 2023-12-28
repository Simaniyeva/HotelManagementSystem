namespace HotelAPI.Persistence.Repositories.Concretes.CountryRepositories;

public class CountryReadRepository : ReadRepository<Country>, ICountryReadRepository
{
    public CountryReadRepository(HotelIdentityDbContext context) : base(context) { }
}
