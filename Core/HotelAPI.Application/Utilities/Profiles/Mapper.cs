using HotelAPI.Application.DTOs.ServiceTypeDtos;
namespace HotelAPI.Application.Utilities.Profiles;

public class Mapper:Profile
{
    public Mapper()
    {
        //Country
        CreateMap<Country, CountryGetDto>();
        CreateMap<CountryPostDto, Country>();
        CreateMap<CountryUpdateDto, Country>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<CountryGetDto, CountryUpdateDto>();

        //City
        CreateMap<City, CityGetDto>();
        CreateMap<CityPostDto, City>();
        CreateMap<CityUpdateDto, City>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<CityGetDto, CityUpdateDto>();

        //Equipment
        CreateMap<Equipment, EquipmentGetDto>();
        CreateMap<EquipmentPostDto, Equipment>();
        CreateMap<EquipmentUpdateDto, Equipment>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<EquipmentGetDto, EquipmentUpdateDto>();

        //Hotel
        CreateMap<Hotel, HotelGetDto>();
        CreateMap<HotelPostDto, Hotel>();
        CreateMap<HotelUpdateDto, Hotel>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<HotelGetDto, HotelUpdateDto>();

        //Reservation
        CreateMap<Reservation, ReservationGetDto>();
        CreateMap<ReservationPostDto, Reservation>();
        CreateMap<ReservationUpdateDto, Reservation>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ReservationGetDto, ReservationUpdateDto>();

        //Reservator
        CreateMap<Reservator, ReservatorGetDto>();
        CreateMap<ReservatorPostDto, Reservator>();
        CreateMap<ReservatorUpdateDto, Reservator>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ReservatorGetDto, ReservatorUpdateDto>();    
        
        //Review
        CreateMap<Review, ReviewGetDto>();
        CreateMap<ReviewPostDto, Review>();
        CreateMap<ReviewUpdateDto, Review>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ReviewGetDto, ReviewUpdateDto>();

 
        //Room
        CreateMap<Room, RoomGetDto>();
        CreateMap<RoomPostDto, Room>();
        CreateMap<RoomUpdateDto, Room>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<RoomGetDto, RoomUpdateDto>();  
        
        //RoomType
        CreateMap<RoomType, RoomTypeGetDto>();
        CreateMap<RoomTypePostDto, RoomType>();
        CreateMap<RoomTypeUpdateDto, RoomType>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<RoomTypeGetDto, RoomTypeUpdateDto>();

        //Service
        CreateMap<Service, ServiceGetDto>();
        CreateMap<ServicePostDto, Service>();
        CreateMap<ServiceUpdateDto, Service>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ServiceGetDto, ServiceUpdateDto>();


        //ServiceType
        CreateMap<ServiceType, ServiceTypeGetDto>();
        CreateMap<ServiceTypePostDto, ServiceType>();
        CreateMap<ServiceTypeUpdateDto, ServiceType>()
            .ForMember(x => x.CreatedDate, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<ServiceTypeGetDto, ServiceTypeUpdateDto>();


    }

}


