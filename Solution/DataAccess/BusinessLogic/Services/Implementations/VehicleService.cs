using AutoMapper;
using DataAccess.BusinessLogic.Services.Interfaces;
using DataAccess.Data.RepositoryInterfaces;
using DataAccess.Data.Specifications;
using DataAccess.Entities;
using DTOs.Vehicles;

namespace DataAccess.BusinessLogic.Services.Implementations;

public class VehicleService(IGenericRepository<Vehicle> repository, IMapper autoMapper) : IVehiclesService
{
    private readonly IGenericRepository<Vehicle> _repository = repository;
    private readonly IMapper _autoMapper = autoMapper;

    // Get all with includes
    public async Task<IReadOnlyList<VehicleToReadDto>> GetAll()
    {
        var spec = new VehiclesWithManufacturerSpecification();
        var vehicleModels = await _repository.ListAsync(spec);

        // use auto mapper
        return _autoMapper.Map<IReadOnlyList<Vehicle>, IReadOnlyList<VehicleToReadDto>>(vehicleModels);
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
        return _autoMapper.Map < Vehicle,  VehicleToReadDto>(vehicleModel);
    }
}
