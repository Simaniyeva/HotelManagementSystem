
using IResult = HotelAPI.Application.Utilities.Results.IResult;
namespace HotelAPI.API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize(Roles = "Admin,SuperAdmin")]

public class EquipmentController : ControllerBase
{
    private readonly IEquipmentService _equipmentService;
    private readonly IMapper _mapper;

    public EquipmentController(IEquipmentService EquipmentService, IMapper mapper)
    {
        _equipmentService = EquipmentService;
        _mapper = mapper;
    }
    [HttpGet("GetEquipments")]
    public async Task<IActionResult> GetEquipments()
    {
        IDataResult<List<EquipmentGetDto>> result = await _equipmentService.GetAllAsync(true);
        return Ok(result);

    }
    [HttpGet("GetEquipmentById/{id}")]
    public async Task<IActionResult> GetEquipmentById(int id)
    {
        IDataResult<EquipmentGetDto> result = await _equipmentService.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpPost("AddEquipment")]
    public async Task<IActionResult> AddEquipment(EquipmentPostDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(dto);
        }
        IResult result = await _equipmentService.CreateAsync(dto);
        return Ok(result);
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(EquipmentUpdateDto dto)
    {
        await _equipmentService.UpdateAsync(dto);
        return Ok();
    }
    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(int id)
    {
        EquipmentGetDto result = (await _equipmentService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _equipmentService.SoftDeleteByIdAsync(id);
        return Ok();
    }

    [HttpPost("Recover")]

    public async Task<IActionResult> Recover(int id)
    {
        EquipmentGetDto result = (await _equipmentService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _equipmentService.RecoverByIdAsync(id);
        return Ok();
    }


    [HttpPost("HardDelete")]
    public async Task<IActionResult> HardDelete(int id)
    {
        EquipmentGetDto result = (await _equipmentService.GetByIdAsync(id)).Data;
        if (result == null) { return BadRequest(); }
        await _equipmentService.HardDeleteByIdAsync(id);
        return Ok();
    }

}
