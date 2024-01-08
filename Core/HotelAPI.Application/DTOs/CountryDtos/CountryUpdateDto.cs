namespace HotelAPI.Domain.DTOs.CountryDtos;

public class CountryUpdateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Continent { get; set; }
}