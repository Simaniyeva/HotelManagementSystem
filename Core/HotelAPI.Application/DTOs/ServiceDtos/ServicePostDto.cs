namespace HotelAPI.Application.DTOs.ServiceDtos;

public class ServicePostDto : IDto
{
    public string Description { get; set; }
    public string AvailabilitySchedule { get; set; }
    public double Price { get; set; }
}

