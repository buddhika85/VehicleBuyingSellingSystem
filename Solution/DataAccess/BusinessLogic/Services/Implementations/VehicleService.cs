using DataAccess.BusinessLogic.Services.Interfaces;
using DataAccess.Data.RepositoryInterfaces;
using DataAccess.Data.Specifications;
using DataAccess.Entities;
using DTOs.Vehicles;

namespace DataAccess.BusinessLogic.Services.Implementations;

public class VehicleService : IVehiclesService
{
    private readonly IGenericRepository<Vehicle> _repository;

    public VehicleService(IGenericRepository<Vehicle> repository)
    {
        _repository = repository;
    }

    // Get all with includes
    public async Task<IReadOnlyList<Vehicle>> GetAll()
    {
        var spec = new VehiclesWithManufacturerSpecification();       
        return await _repository.ListAsync(spec);
    }

    // Get by Id, with includes
    public async Task<VehicleToReadDto?> GetById(int id)
    {
        var spec = new VehiclesWithManufacturerSpecification(id);
        var vehicleModel = await _repository.GetEntityWithSpec(spec);
        if (vehicleModel == null)
        {
            return null;
        }

        // use auto mapper
        return null;
    }
}
