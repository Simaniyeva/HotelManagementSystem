namespace HotelAPI.Infrastructure.Repositories;

public interface IRepository<TEntity>where TEntity : BaseEntity, IEntityBase, new()
{
}
