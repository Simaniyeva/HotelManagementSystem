namespace HotelAPI.Domain.DTOs.CityDtos;

public class CityPostDto : IDto
{
    public string Name { get; set; }
    public string PostalCode { get; set; }

    //Relations 
    public int CountryId { get; set; }

}
