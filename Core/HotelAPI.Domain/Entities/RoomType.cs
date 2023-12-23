namespace HotelAPI.Domain.Entities;

public class RoomType:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    //Relations
    public List<Room>Rooms { get; set; }

}
