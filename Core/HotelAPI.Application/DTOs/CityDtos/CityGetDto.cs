using HotelAPI.Domain.DTOs.CountryDtos;

namespace HotelAPI.Domain.DTOs.CityDtos;

public class CityGetDto:IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PostalCode { get; set; }
    public bool isActive { get; set; }

    //Relations
    public CountryGetDto Country { get; set; }
    public List<HotelGetDto>Hotels { get; set; }
}
