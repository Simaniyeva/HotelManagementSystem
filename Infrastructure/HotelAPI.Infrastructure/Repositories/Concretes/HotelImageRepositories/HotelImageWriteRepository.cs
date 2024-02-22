using HotelAPI.Domain.Repositories.HotelImageRepositories;

namespace HotelAPI.Infrastructure.Repositories.Concretes.HotelImageRepositories;

public class HotelImageWriteRepository : WriteRepository<HotelImage>, IHotelImageWriteRepository
{
    public HotelImageWriteRepository(HotelIdentityDbContext context) : base(context) { }
}
