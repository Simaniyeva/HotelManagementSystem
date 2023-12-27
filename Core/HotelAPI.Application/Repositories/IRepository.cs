using HotelAPI.Domain.Entities;

namespace HotelAPI.Application.Repositories;

public interface IRepository<TEntity>where TEntity : class,IEntityBase, new()
{
}
