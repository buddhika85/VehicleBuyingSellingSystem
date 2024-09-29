using DataAccess.BusinessLogic.Services.Interfaces;
using DataAccess.Data.RepositoryInterfaces;
using DataAccess.Entities;

namespace DataAccess.BusinessLogic.Services.Implementations;

public class VehicleService : IVehiclesService
{
    private readonly IGenericRepository<Vehicle> _repository;

    public VehicleService(IGenericRepository<Vehicle> repository)
    {
        _repository = repository;
    }
    public async Task<IReadOnlyList<Vehicle>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Vehicle?> GetById(int id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
