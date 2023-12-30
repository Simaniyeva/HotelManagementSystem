namespace HotelAPI.Persistence;

public interface IUnitOfWork
{
    public ICountryReadRepository CountryReadRepository{get;}
    public ICountryWriteRepository CountryWriteRepository{get; }

    public ICityReadRepository CityReadRepository { get;}
    public ICityWriteRepository CityWriteRepository { get; }

    public IEquipmentReadRepository EquipmentReadRepository { get; }
    public IEquipmentWriteRepository EquipmentWriteRepository { get; }

    public IHotelReadRepository HotelReadRepository { get; }
    public IHotelWriteRepository HotelWriteRepository { get; }

    public IReservationReadRepository ReservationReadRepository { get; }
    public IReservationWriteRepository ReservationWriteRepository { get; }

    public IReservatorReadRepository ReservatorReadRepository { get; }
    public IReservatorWriteRepository ReservatorWriteRepository { get; }

    public IReviewReadRepository ReviewReadRepository { get; }
    public IReviewWriteRepository ReviewWriteRepository { get; }
    
    public IRoomReadRepository RoomReadRepository { get; }
    public IRoomWriteRepository RoomWriteRepository { get; }

    public IRoomTypeReadRepository RoomTypeReadRepository { get; }
    public IRoomTypeWriteRepository RoomTypeWriteRepository { get; }

    public IServiceReadRepository ServiceReadRepository { get; }
    public IServiceWriteRepository ServiceWriteRepository { get; } 

    public IServiceTypeReadRepository ServiceTypeReadRepository { get; }
    public IServiceTypeWriteRepository ServiceTypeWriteRepository { get; }


    Task<int> SaveAsync();
}
