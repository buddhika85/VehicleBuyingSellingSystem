using DataAccess.BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
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
        var items = await _vehiclesService.GetAll();
        return Ok(items);
    }

    // GET api/Vehicles/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Vehicle>> Get(int id)
    {
        var item = await _vehiclesService.GetById(id);
        if (item == null)
        {
            return Ok($"Vehicle with such Id: {id} not found");
        }
        return Ok(item);
    }

    // POST api/Vehicles
    [HttpPost]
    public void Post([FromBody] string value)
    {
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
