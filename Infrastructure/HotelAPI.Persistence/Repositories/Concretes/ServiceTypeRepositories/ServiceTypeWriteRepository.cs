namespace HotelAPI.Persistence.Repositories.Concretes.ServiceTypeRepositories;

public class ServiceTypeWriteRepository : WriteRepository<ServiceType>, IServiceTypeWriteRepository
{
    public ServiceTypeWriteRepository(HotelIdentityDbContext context) : base(context) { }
}