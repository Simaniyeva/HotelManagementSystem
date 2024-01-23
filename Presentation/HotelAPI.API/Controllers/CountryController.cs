using HotelAPI.Application.Repositories.CountryRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController : ControllerBase
{
    private readonly ICountryWriteRepository _countryWriteRepository;
    private readonly ICountryReadRepository _countryReadRepository;

    public CountryController(ICountryWriteRepository countryWriteRepository, ICountryReadRepository countryReadRepository)
    {
        _countryWriteRepository = countryWriteRepository;
        _countryReadRepository = countryReadRepository;
    }



    [HttpGet]
    public async  Task Get()
    {
        await _countryWriteRepository.CreateAsync(new()
        {
            Name = "Azerbaijan",
            Continent = "Europe",

        });
        _countryWriteRepository.SaveAsync();
    }

}
