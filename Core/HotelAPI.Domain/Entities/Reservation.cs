namespace HotelAPI.Domain.Entities;

public class Reservation:BaseEntity
{
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }

    //Relations
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public int ReservatorId { get; set; }
    public Reservator Reservator { get; set; }
}
