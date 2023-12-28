﻿namespace HotelAPI.Persistence.Repositories.Concretes.CountryRepositories;

public class CountryWriteRepository : WriteRepository<Country>, ICountryWriteRepository
{
    public CountryWriteRepository(HotelIdentityDbContext context) : base(context) { }
}
