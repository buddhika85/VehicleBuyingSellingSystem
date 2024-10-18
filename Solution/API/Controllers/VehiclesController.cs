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
            return NotFound($"Vehicle with such Id: {id} not found");
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
            // REST convention - Return 201 Created with URI to the new resource
            return CreatedAtAction(nameof(Get), new { id = result.CreatedEntityId }, vehicleToCreateDto);           
        }
        return BadRequest(result);
    }

    // PUT api/Vehicles/5
    // Full update on a resource / replace
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, VehicleToUpdateDto vehicleToUpdate)
    {
        if (vehicleToUpdate == null || vehicleToUpdate.Id != id)
        {
            return UnprocessableEntity("The provided Id does not match the resource Id.");
        }

        var result = await _vehiclesService.UpdateAsync(vehicleToUpdate);
        if (result.IsSuccess)
        {
            // REST conventions
            return NoContent();  // Return 204 No Content on successful update 
        }
        return BadRequest(result);
    }

    // Patch api/Vehicles
    // Partial update on a resource
    [HttpPatch("{id}")]
    public async Task<ActionResult> Patch(int id, VehicleToUpdateDto vehicleToUpdate)
    {
        // Fetch the existing vehicle from the database
        var vehicleFromDb = await _vehiclesService.GetByIdAsync(id);
        if (vehicleFromDb == null)
        {
            return NotFound($"Vehicle with Id {id} not found.");
        }

        var result = await _vehiclesService.UpdateAsync(vehicleToUpdate);
        if (result.IsSuccess)
        {
            return NoContent();     // Return 204 No Content on successful update 
        }
        return BadRequest(result);
    }

    // DELETE api/Vehicles/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var result = await _vehiclesService.DeleteAsync(id);
        if (result.IsSuccess)
        {
            return NoContent();     // Return 204 No Content on successful deletion 
        }
        return BadRequest(result);
    }
}
