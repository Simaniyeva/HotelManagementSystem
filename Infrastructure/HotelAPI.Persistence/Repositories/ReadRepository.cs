using HotelAPI.Application.Repositories;
using HotelAPI.Persistence.DbContexts;
using System.Linq.Expressions;

namespace HotelAPI.Persistence.Repositories;

public class ReadRepository<TEntity> : IReadRepository<TEntity>where TEntity:class,IEntityBase,new()
{
    private readonly HotelIdentityDbContext _context;
    public Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? exp = null, params string[] includes)
    {
        throw new NotImplementedException();
    }

    public Task<List<TEntity>> GetAllPaginatedAsync(int page, int size, Expression<Func<TEntity, bool>>? exp, params string[] includes)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp, params string[] includes)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistsAsync(Expression<Func<TEntity, bool>> exp)
    {
        throw new NotImplementedException();
    }
}

