using IResult = HotelAPI.Application.Utilities.Results.IResult;
namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(AuthenticationSchemes = "Bearer")]



public class CityController : ControllerBase
{
    private readonly ICityService _cityService;
    private readonly IMapper _mapper;

    public CityController(ICityService CityService, IMapper mapper)
    {
        _cityService = CityService;
        _mapper = mapper;
    }
    [HttpGet("GetCities")]
    public async Task<IActionResult> GetCities()
    {
        IDataResult<List<CityGetDto>> result = await _cityService.GetAllAsync(true,Includes.CityIncludes);
        return Ok(result);

    }
    [HttpGet("GetCityById/{id}")]
    public async Task<IActionResult> GetCityById(int id)
    {
        IDataResult<CityGetDto> result = await _cityService.GetByIdAsync(id, Includes.CityIncludes);
        return Ok(result);
    }

    [HttpPost("AddCity")]
    public async Task<IActionResult> AddCity(CityPostDto dto)
    {
        IResult result = await _cityService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(CityUpdateDto dto)
    {
        await _cityService.UpdateAsync(dto);
        return Ok();
    }
    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        CityGetDto result = (await _cityService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _cityService.SoftDeleteByIdAsync(id);
        return Ok();
    }

    [HttpPost("Recover")]

    public async Task<IActionResult> Recover(int id)
    {
        CityGetDto result = (await _cityService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _cityService.RecoverByIdAsync(id);
        return Ok();
    }


    [HttpPost("HardDelete")]
    public async Task<IActionResult> HardDelete(int id)
    {
        CityGetDto result = (await _cityService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _cityService.HardDeleteByIdAsync(id);
        return Ok();
    }

}
