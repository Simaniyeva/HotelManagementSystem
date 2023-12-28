using HotelAPI.Application.Repositories.CountryRepositories;

namespace HotelAPI.Persistence;

public class UnitOfWork : IUnitOfWork
{
    public ICountryReadRepository CountryReadRepository => throw new NotImplementedException();

    public Task<int> SaveAsync()
    {
        throw new NotImplementedException();
    }
}
