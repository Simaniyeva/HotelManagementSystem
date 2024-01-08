namespace HotelAPI.Application.DTOs.ServiceDtos;

public class ServiceUpdateDto : IDto
{
    public int Id { get; set; }
    public string Description { get; set; }
    public string AvailabilitySchedule { get; set; }
    public double Price { get; set; }
}

