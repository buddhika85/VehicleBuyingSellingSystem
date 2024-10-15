using DTOs;
using DTOs.Vehicles;

namespace DataAccess.BusinessLogic.Services.Interfaces;

public interface IVehiclesService
{
    public Task<IReadOnlyList<VehicleToReadDto>> GetAllAsync();
    public Task<VehicleToReadDto?> GetByIdAsync(int id);

    public Task<ResultDto> CreateAsync(VehicleToCreateDto dto);



}
