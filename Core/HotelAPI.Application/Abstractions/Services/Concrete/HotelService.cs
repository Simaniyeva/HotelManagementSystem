namespace HotelAPI.Application.Abstractions.Services.Concrete;

public class HotelService : IHotelService
{
    private readonly IHotelReadRepository _hotelReadRepository;
    private readonly IHotelWriteRepository _hotelWriteRepository;
    private readonly IMapper _mapper;

    public HotelService(IHotelReadRepository HotelReadRepository, IHotelWriteRepository HotelWriteRepository, IMapper mapper)
    {
        _hotelReadRepository = HotelReadRepository;
        _hotelWriteRepository = HotelWriteRepository;
        _mapper = mapper;
    }
    #region Get Requests

    public async Task<IDataResult<List<HotelGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<Hotel> cities = getDeleted
            ? await _hotelReadRepository.GetAllAsync(includes: includes)
            : await _hotelReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active, includes);
        if (cities is null)
        {
            return new ErrorDataResult<List<HotelGetDto>>(Messages.NotFound(Messages.Hotel));
        }
        return new SuccessDataResult<List<HotelGetDto>>(_mapper.Map<List<HotelGetDto>>(cities));
    }

    public async Task<IDataResult<HotelGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        Hotel Hotel = await _hotelReadRepository.GetAsync(c => c.Id == id, includes);
        if (Hotel is null)
        {
            return new ErrorDataResult<HotelGetDto>(Messages.NotFound(Messages.Hotel));

        }
        return new SuccessDataResult<HotelGetDto>(_mapper.Map<HotelGetDto>(Hotel));

    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(HotelPostDto dto)
    {
        Hotel Hotel = _mapper.Map<Hotel>(dto);
        await _hotelWriteRepository.CreateAsync(Hotel);
        int result = await _hotelWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<HotelGetDto>(Messages.NotFound(Messages.Hotel));
        }
        return new SuccessDataResult<HotelGetDto>(_mapper.Map<HotelGetDto>(Hotel));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(HotelUpdateDto dto)
    {
        Hotel Hotel = await _hotelReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active);
        Hotel = _mapper.Map<Hotel>(dto);
        _hotelWriteRepository.Update(Hotel);
        int result = await _hotelWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.Hotel));
        }
        return new SuccessResult(Messages.Updated(Messages.Hotel));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        Hotel Hotel = await _hotelReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        Hotel.entityStatus = EntityStatus.Active;
        _hotelWriteRepository.Update(Hotel);
        int result = await _hotelWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.Hotel));
        }
        return new SuccessResult(Messages.Recovered(Messages.Hotel));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        Hotel Hotel = await _hotelReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        _hotelWriteRepository.Delete(Hotel);
        int result = await _hotelWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Hotel));
        }
        return new SuccessResult(Messages.Deleted(Messages.Hotel));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        Hotel Hotel = await _hotelReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        Hotel.entityStatus = EntityStatus.Active;
        _hotelWriteRepository.Update(Hotel);
        int result = await _hotelWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Hotel));
        }
        return new SuccessResult(Messages.Deleted(Messages.Hotel));
    }
    #endregion


}
