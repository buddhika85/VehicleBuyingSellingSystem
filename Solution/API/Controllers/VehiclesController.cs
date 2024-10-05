using DataAccess.BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using DTOs.Vehicles;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class VehiclesController(IVehiclesService vehiclesService) : ControllerBase
{
    private readonly IVehiclesService _vehiclesService = vehiclesService;

    // GET: api/Vehicles
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Vehicle>>> Get()
    {
        var items = await _vehiclesService.GetAllAsync();
        return Ok(items);
    }

    // GET api/Vehicles/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> Get(int id)
    {
        var item = await _vehiclesService.GetByIdAsync(id);
        if (item == null)
        {
            return Ok($"Vehicle with such Id: {id} not found");
        }
        return Ok(item);
    }

    // POST api/Vehicles
    [HttpPost]
    public async Task<ActionResult> Post(VehicleToCreateDto vehicleToCreateDto)
    {
        var result = await _vehiclesService.CreateAsync(vehicleToCreateDto);
        if (result.IsSuccess)
        {
            return Created();
        }
        return BadRequest(result);
    }

    // PUT api/Vehicles/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/Vehicles/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
