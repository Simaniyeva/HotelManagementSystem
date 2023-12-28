﻿namespace HotelAPI.Persistence.Repositories.Concretes.RoomRepositories;

public class RoomWriteRepository : WriteRepository<Room>, IRoomWriteRepository
{
    public RoomWriteRepository(HotelIdentityDbContext context) : base(context) { }
}

