namespace HotelAPI.Persistence.Repositories.Concretes.EquipmentRepositories;

public class EquipmentReadRepository : ReadRepository<Equipment>, IEquipmentReadRepository
{
    public EquipmentReadRepository(HotelIdentityDbContext context) : base(context) { }
}
