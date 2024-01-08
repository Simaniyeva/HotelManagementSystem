namespace HotelAPI.Domain.DTOs.ReservatorDtos;

public class ReservatorPostDto: IDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}
