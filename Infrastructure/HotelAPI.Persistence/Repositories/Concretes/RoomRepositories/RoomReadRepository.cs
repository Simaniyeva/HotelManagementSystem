namespace HotelAPI.Persistence.Repositories.Concretes.RoomRepositories;
public class RoomReadRepository : ReadRepository<Room>, IRoomReadRepository
{
    public RoomReadRepository(HotelIdentityDbContext context) : base(context) { }
}

