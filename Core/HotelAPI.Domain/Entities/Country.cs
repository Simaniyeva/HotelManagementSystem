namespace HotelAPI.Domain.Entities;

public class Country : BaseEntity
{
    public string Name { get; set; }

    //Relations
    public List<City> Cities { get; set; }
}
