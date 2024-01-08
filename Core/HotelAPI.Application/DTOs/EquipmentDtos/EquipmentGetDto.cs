namespace HotelAPI.Domain.DTOs.EquipmentDtos;

public class EquipmentGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
    public EquipmentCondition Condition { get; set; }
}
