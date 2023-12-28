using HotelAPI.Application.Repositories.CountryRepositories;

namespace HotelAPI.Persistence;

public interface IUnitOfWork
{
    public ICountryReadRepository CountryReadRepository{get;}
    Task<int> SaveAsync();
}
