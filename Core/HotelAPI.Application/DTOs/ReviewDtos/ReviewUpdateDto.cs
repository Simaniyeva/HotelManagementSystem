
namespace HotelAPI.Application.DTOs.ReviewDtos;

public class ReviewUpdateDto : IDto
{
    public int Id { get; set; }
    public string Content { get; set; }

    //Relations
    public int ReservatorId { get; set; }
    public int HotelId { get; set; }
}