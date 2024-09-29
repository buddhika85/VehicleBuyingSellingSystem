using DataAccess.Entities;

namespace DataAccess.BusinessLogic.Services.Interfaces;

public interface IVehiclesService
{
    public Task<IReadOnlyList<Vehicle>> GetAll();
    public Task<Vehicle?> GetById(int id);
}
