namespace HotelAPI.Domain.DTOs.EquipmentDtos;

public class EquipmentPostDto : IDto
{
    public string Name { get; set; }
    public int Quantity { get; set; }
}
