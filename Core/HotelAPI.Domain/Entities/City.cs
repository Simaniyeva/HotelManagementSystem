namespace HotelAPI.Domain.Entities;

public class City : BaseEntity
{
    public string Name { get; set; }
    public string PostalCode { get; set; }

    //Relations
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public List<Hotel>Hotels { get; set; }
}
