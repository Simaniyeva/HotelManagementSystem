

namespace HotelAPI.Application.Abstractions.Services.Concrete;

public class ReservationService : IReservationService
{
    private readonly IReservationReadRepository _reservationReadRepository;
    private readonly IReservationWriteRepository _reservationWriteRepository;
    private readonly IMapper _mapper;

    public ReservationService(IReservationReadRepository ReservationReadRepository, IReservationWriteRepository ReservationWriteRepository, IMapper mapper)
    {
        _reservationReadRepository = ReservationReadRepository;
        _reservationWriteRepository = ReservationWriteRepository;
        _mapper = mapper;
    }
    #region Get Requests

    public async Task<IDataResult<List<ReservationGetDto>>> GetAllAsync(bool getDeleted, params string[] includes)
    {
        List<Reservation> reservations = getDeleted
            ? await _reservationReadRepository.GetAllAsync(includes: includes)
            : await _reservationReadRepository.GetAllAsync(c => c.entityStatus == EntityStatus.Active, includes);
        if (reservations is null)
        {
            return new ErrorDataResult<List<ReservationGetDto>>(Messages.NotFound(Messages.Reservation));
        }
        return new SuccessDataResult<List<ReservationGetDto>>(_mapper.Map<List<ReservationGetDto>>(reservations));
    }

    public async Task<IDataResult<ReservationGetDto>> GetByIdAsync(int id, params string[] includes)
    {
        Reservation Reservation = await _reservationReadRepository.GetAsync(c => c.Id == id, includes);
        if (Reservation is null)
        {
            return new ErrorDataResult<ReservationGetDto>(Messages.NotFound(Messages.Reservation));

        }
        return new SuccessDataResult<ReservationGetDto>(_mapper.Map<ReservationGetDto>(Reservation));

    }
    #endregion

    #region Post Requests
    public async Task<IResult> CreateAsync(ReservationPostDto dto)
    {
        Reservation Reservation = _mapper.Map<Reservation>(dto);
        await _reservationWriteRepository.CreateAsync(Reservation);
        int result = await _reservationWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorDataResult<ReservationGetDto>(Messages.NotFound(Messages.Reservation));
        }
        return new SuccessDataResult<ReservationGetDto>(_mapper.Map<ReservationGetDto>(Reservation));
    }

    #endregion

    #region Update Requests
    public async Task<IResult> UpdateAsync(ReservationUpdateDto dto)
    {
        Reservation Reservation = await _reservationReadRepository.GetAsync(c => c.Id == dto.Id && c.entityStatus == EntityStatus.Active);
        Reservation = _mapper.Map<Reservation>(dto);
        _reservationWriteRepository.Update(Reservation);
        int result = await _reservationWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotUpdated(Messages.Reservation));
        }
        return new SuccessResult(Messages.Updated(Messages.Reservation));
    }

    public async Task<IResult> RecoverByIdAsync(int id)
    {
        Reservation Reservation = await _reservationReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        Reservation.entityStatus = EntityStatus.Active;
        _reservationWriteRepository.Update(Reservation);
        int result = await _reservationWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotRecovered(Messages.Reservation));
        }
        return new SuccessResult(Messages.Recovered(Messages.Reservation));
    }

    #endregion

    #region Delete requests
    public async Task<IResult> HardDeleteByIdAsync(int id)
    {
        Reservation Reservation = await _reservationReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.InActive);
        _reservationWriteRepository.Delete(Reservation);
        int result = await _reservationWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Reservation));
        }
        return new SuccessResult(Messages.Deleted(Messages.Reservation));
    }

    public async Task<IResult> SoftDeleteByIdAsync(int id)
    {
        Reservation Reservation = await _reservationReadRepository.GetAsync(c => c.Id == id && c.entityStatus == EntityStatus.Active);
        Reservation.entityStatus = EntityStatus.InActive;
        _reservationWriteRepository.Update(Reservation);
        int result = await _reservationWriteRepository.SaveAsync();
        if (result is 0)
        {
            return new ErrorResult(Messages.NotDeleted(Messages.Reservation));
        }
        return new SuccessResult(Messages.Deleted(Messages.Reservation));
    }
    #endregion


}
