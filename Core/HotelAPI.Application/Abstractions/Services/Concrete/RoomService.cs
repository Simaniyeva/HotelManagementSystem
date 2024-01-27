

namespace HotelAPI.Application.Abstractions.Services.Concrete;

public class RoomService : IRoomService
{
    private readonly IRoomReadRepository _roomReadRepository;
    private readonly IRoomWriteRepository _roomWriteRepository;
    private readonly IMapper _mapper;

    public RoomService(IRoomReadRepository RoomReadRepository, IRoomWriteRepository RoomWriteRepository, IMapper mapper)
    {
        _roomReadRepository = RoomReadRepository;
        _roomWriteRepository = RoomWriteRepository;
        _mapper = mapper;
    }
    #region Get Requests

    public async Task<IDataResult<List<RoomGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<Room> cities = getDeleted
            ? await _roomReadRepository.GetAllAsync(includes: includes)
            : await _roomReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active, includes);
        if (cities is null)
        {
            return new ErrorDataResult<List<RoomGetDto>>(Messages.NotFound(Messages.Room));
        }
        return new SuccessDataResult<List<RoomGetDto>>(_mapper.Map<List<RoomGetDto>>(cities));
    }

    public async Task<IDataResult<RoomGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        Room Room = await _roomReadRepository.GetAsync(c => c.Id == id, includes);
        if (Room is null)
        {
            return new ErrorDataResult<RoomGetDto>(Messages.NotFound(Messages.Room));

        }
        return new SuccessDataResult<RoomGetDto>(_mapper.Map<RoomGetDto>(Room));

    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(RoomPostDto dto)
    {
        Room Room = _mapper.Map<Room>(dto);
        await _roomWriteRepository.CreateAsync(Room);
        int result = await _roomWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<RoomGetDto>(Messages.NotFound(Messages.Room));
        }
        return new SuccessDataResult<RoomGetDto>(_mapper.Map<RoomGetDto>(Room));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(RoomUpdateDto dto)
    {
        Room Room = await _roomReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active);
        Room = _mapper.Map<Room>(dto);
        _roomWriteRepository.Update(Room);
        int result = await _roomWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.Room));
        }
        return new SuccessResult(Messages.Updated(Messages.Room));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        Room Room = await _roomReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        Room.entityStatus = EntityStatus.Active;
        _roomWriteRepository.Update(Room);
        int result = await _roomWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.Room));
        }
        return new SuccessResult(Messages.Recovered(Messages.Room));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        Room Room = await _roomReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        _roomWriteRepository.Delete(Room);
        int result = await _roomWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Room));
        }
        return new SuccessResult(Messages.Deleted(Messages.Room));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        Room Room = await _roomReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        Room.entityStatus = EntityStatus.Active;
        _roomWriteRepository.Update(Room);
        int result = await _roomWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Room));
        }
        return new SuccessResult(Messages.Deleted(Messages.Room));
    }
    #endregion


}
