namespace HotelAPI.Domain.Entities;

public class Equipment:BaseEntity
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public EquipmentCondition Condition { get; set; } = EquipmentCondition.Good;
}
