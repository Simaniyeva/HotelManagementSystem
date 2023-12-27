using HotelAPI.Application.Repositories;

namespace HotelAPI.Persistence.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : class, IEntityBase, new()
    {
        public Task CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task CreateRangeASync(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
