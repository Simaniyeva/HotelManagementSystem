

namespace HotelAPI.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly HotelIdentityDbContext _context;
    private ICountryReadRepository _countryReadRepository;
    private ICountryWriteRepository _countryWriteRepository;

    private ICityReadRepository _cityReadRepository;
    private ICityWriteRepository _cityWriteRepository;

    private IHotelReadRepository _hotelReadRepository;
    private IHotelWriteRepository _hotelWriteRepository;


    private IEquipmentReadRepository _equipmentReadRepository;
    private IEquipmentWriteRepository _equipmentWriteRepository;


    private IReservationReadRepository _reservationReadRepository;
    private IReservationWriteRepository _reservationWriteRepository;

    private IReservatorReadRepository _reservatorReadRepository;
    private IReservatorWriteRepository _reservatorWriteRepository;

    private IReviewReadRepository _reviewReadRepository;
    private IReviewWriteRepository _reviewWriteRepository;

    private IRoomReadRepository _roomReadRepository;
    private IRoomWriteRepository _roomWriteRepository;

    private IRoomTypeReadRepository _roomTypeReadRepository;
    private IRoomTypeWriteRepository _roomTypeWriteRepository;

    private IServiceReadRepository _serviceReadRepository;
    private IServiceWriteRepository _serviceWriteRepository;

    private IServiceTypeReadRepository _serviceTypeReadRepository;
    private IServiceTypeWriteRepository _serviceTypeWriteRepository;



    public UnitOfWork(HotelIdentityDbContext context)
    {
        _context = context;
    }
    public ICountryReadRepository CountryReadRepository => _countryReadRepository = _countryReadRepository ?? new CountryReadRepository(_context);
    public ICountryWriteRepository CountryWriteRepository => _countryWriteRepository = _countryWriteRepository ?? new CountryWriteRepository(_context);

    public ICityReadRepository CityReadRepository => _cityReadRepository = _cityReadRepository ?? new CityReadRepository(_context);
    public ICityWriteRepository CityWriteRepository => _cityWriteRepository = _cityWriteRepository ?? new CityWriteRepository(_context);

    public IEquipmentReadRepository EquipmentReadRepository => _equipmentReadRepository = _equipmentReadRepository ?? new EquipmentReadRepository(_context);
    public IEquipmentWriteRepository EquipmentWriteRepository => _equipmentWriteRepository = _equipmentWriteRepository ?? new EquipmentWriteRepository(_context);

    public IHotelReadRepository HotelReadRepository => _hotelReadRepository = _hotelReadRepository ?? new HotelReadRepository(_context);
    public IHotelWriteRepository HotelWriteRepository => _hotelWriteRepository = _hotelWriteRepository ?? new HotelWriteRepository(_context);

    public IReservationReadRepository ReservationReadRepository => _reservationReadRepository = _reservationReadRepository ?? new ReservationReadRepository(_context);
    public IReservationWriteRepository ReservationWriteRepository => _reservationWriteRepository = _reservationWriteRepository ?? new ReservationWriteRepository(_context);


    public IReservatorReadRepository ReservatorReadRepository => _reservatorReadRepository = _reservatorReadRepository ?? new ReservatorReadRepository(_context);
    public IReservatorWriteRepository ReservatorWriteRepository => _reservatorWriteRepository = _reservatorWriteRepository ?? new ReservatorWriteRepository(_context);  
    
    public IReviewReadRepository ReviewReadRepository => _reviewReadRepository = _reviewReadRepository ?? new ReviewReadRepository(_context);
    public IReviewWriteRepository ReviewWriteRepository => _reviewWriteRepository = _reviewWriteRepository ?? new ReviewWriteRepository(_context);

    public IRoomReadRepository RoomReadRepository => _roomReadRepository = _roomReadRepository ?? new RoomReadRepository(_context);
    public IRoomWriteRepository RoomWriteRepository => _roomWriteRepository = _roomWriteRepository ?? new RoomWriteRepository(_context);


    public IRoomTypeReadRepository RoomTypeReadRepository => _roomTypeReadRepository = _roomTypeReadRepository ?? new RoomTypeReadRepository(_context);
    public IRoomTypeWriteRepository RoomTypeWriteRepository => _roomTypeWriteRepository = _roomTypeWriteRepository ?? new RoomTypeWriteRepository(_context);


    public IServiceReadRepository ServiceReadRepository => _serviceReadRepository = _serviceReadRepository ?? new ServiceReadRepository(_context);
    public IServiceWriteRepository ServiceWriteRepository => _serviceWriteRepository = _serviceWriteRepository ?? new ServiceWriteRepository(_context);


    public IServiceTypeReadRepository ServiceTypeReadRepository => _serviceTypeReadRepository = _serviceTypeReadRepository ?? new ServiceTypeReadRepository(_context);
    public IServiceTypeWriteRepository ServiceTypeWriteRepository => _serviceTypeWriteRepository = _serviceTypeWriteRepository ?? new ServiceTypeWriteRepository(_context);


    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
