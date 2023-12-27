using HotelAPI.Domain.Entities;

namespace HotelAPI.Application.Repositories;

public interface IWriteRepository<TEntity> :IRepository<TEntity> where TEntity : class,IEntityBase,new()
{
    Task CreateAsync(TEntity entity);
    Task CreateRangeASync(List<TEntity> entities);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
