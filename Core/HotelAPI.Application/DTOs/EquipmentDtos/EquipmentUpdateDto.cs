namespace HotelAPI.Domain.DTOs.EquipmentDtos;

public class EquipmentUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}
