namespace HotelAPI.Domain.Entities;

public class ServiceType:BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }


    //Relations
    public List<Service>Services { get; set; }
}
