using IResult = HotelAPI.Application.Utilities.Results.IResult;
namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin,SuperAdmin")]

public class CountryController : ControllerBase
{
    private readonly ICountryService _countryService;
    private readonly IMapper _mapper;

    public CountryController(ICountryService countryService, IMapper mapper)
    {
        _countryService = countryService;
        _mapper = mapper;
    }
    [HttpGet("GetCountries")]
    public async Task<IActionResult> GetCountries()
    {
        IDataResult<List<CountryGetDto>> result = await _countryService.GetAllAsync(true,Includes.CountryIncludes);
        return Ok(result);

    }
    [HttpGet("GetCountryById/{id}")]
    public async Task<IActionResult> GetCountryById(int id)
    {
        IDataResult<CountryGetDto> result = await _countryService.GetByIdAsync(id, Includes.CountryIncludes);
        return Ok(result);
    }

    [HttpPost("AddCountry")]
    public async Task<IActionResult> AddCountry(CountryPostDto dto)
    {
        IResult result = await _countryService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(CountryUpdateDto dto)
    {
        await _countryService.UpdateAsync(dto);
        return Ok();
    }
    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        CountryGetDto result = (await _countryService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _countryService.SoftDeleteByIdAsync(id);
        return Ok();
    }

    [HttpPost("Recover")]

    public async Task<IActionResult> Recover(int id)
    {
        CountryGetDto result = (await _countryService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _countryService.RecoverByIdAsync(id);
        return Ok();
    }


    [HttpPost("HardDelete")]
    public async Task<IActionResult> HardDelete(int id)
    {
        CountryGetDto result = (await _countryService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _countryService.HardDeleteByIdAsync(id);
        return Ok();
    }

}
