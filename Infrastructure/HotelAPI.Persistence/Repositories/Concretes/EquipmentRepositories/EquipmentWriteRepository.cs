namespace HotelAPI.Persistence.Repositories.Concretes.EquipmentRepositories;

public class EquipmentWriteRepository : WriteRepository<Equipment>, IEquipmentWriteRepository
{
    public EquipmentWriteRepository(HotelIdentityDbContext context) : base(context) { }
}