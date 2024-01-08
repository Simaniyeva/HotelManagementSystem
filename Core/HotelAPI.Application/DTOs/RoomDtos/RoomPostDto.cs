namespace HotelAPI.Domain.DTOs.RoomDtos;

public class RoomPostDto : IDto
{
    public int Number { get; set; }
    public int Floor { get; set; }
    public string Phone { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public RoomState RoomState { get; set; }
    public List<EquipmentGetDto> Equipments { get; set; }

    //Relations
    public int RoomTypeId { get; set; }
    public int HotelId { get; set; }
}
