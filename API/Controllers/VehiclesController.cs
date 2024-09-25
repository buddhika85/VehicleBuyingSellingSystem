using Core.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly ILogger<VehiclesController> _logger;
        private readonly StoreContext _context;

        public VehiclesController(ILogger<VehiclesController> logger, StoreContext context)
        {
            _logger = logger;
            _context = context;
        }

      
        [HttpGet] 
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            return Ok(await _context.Vehicles.ToListAsync());
        }

        [HttpGet("{id:int}")] 
        public async Task<ActionResult<Vehicle>> GetVehicle(int id)
        {
            var product = await _context.Vehicles.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Vehicle>> CreateVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            await _context.SaveChangesAsync();
            return Created();
        }
    }
}