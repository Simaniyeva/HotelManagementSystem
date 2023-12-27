namespace HotelAPI.Domain.Entities;

public class Country : BaseEntity,IEntityBase
{
    public string Name { get; set; }
    public string Continent { get; set; }

    //Relations
    public List<City> Cities { get; set; }
}
