namespace HotelAPI.Domain.DTOs.CityDtos;

public class CityUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PostalCode { get; set; }
    //Relations 
    public int CountryId { get; set; }
}