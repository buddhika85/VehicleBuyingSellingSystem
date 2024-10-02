using DataAccess.Entities;
using DTOs.Vehicles;

namespace DataAccess.BusinessLogic.Services.Interfaces;

public interface IVehiclesService
{
    public Task<IReadOnlyList<Vehicle>> GetAll();
    public Task<VehicleToReadDto?> GetById(int id);
}
