using AutoMapper;
using DataAccess.BusinessLogic.Services.Interfaces;
using DataAccess.Data.RepositoryInterfaces;
using DataAccess.Data.Specifications;
using DataAccess.Entities;
using DTOs;
using DTOs.Vehicles;

namespace DataAccess.BusinessLogic.Services.Implementations;

public class VehicleService(IGenericRepository<Vehicle> repository, IMapper autoMapper) : IVehiclesService
{
    private readonly IGenericRepository<Vehicle> _repository = repository;
    private readonly IMapper _autoMapper = autoMapper;


    // Get all with includes
    public async Task<IReadOnlyList<VehicleToReadDto>> GetAllAsync()
    {
        var spec = new VehiclesWithManufacturerSpecification();
        var vehicleModels = await _repository.ListAsync(spec);

        // use auto mapper
        return _autoMapper.Map<IReadOnlyList<Vehicle>, IReadOnlyList<VehicleToReadDto>>(vehicleModels);
    }


    // Get by Id, with includes
    public async Task<VehicleToReadDto?> GetByIdAsync(int id)
    {
        var spec = new VehiclesWithManufacturerSpecification(id);
        var vehicleModel = await _repository.GetEntityWithSpec(spec);
        if (vehicleModel == null)
        {
            return null;
        }

        // use auto mapper
        return _autoMapper.Map<Vehicle, VehicleToReadDto>(vehicleModel);
    }

    // Insert
    public async Task<CreatedResultDto> CreateAsync(VehicleToCreateDto dto)
    {
        var resultDto = new CreatedResultDto { FunctionPerformed = "Adding new vehicle" };
        try
        {
            var model = _autoMapper.Map<Vehicle>(dto);
            model = await _repository.CreateAsync(model);
            resultDto.CreatedEntityId = model.Id;               // for REST convetions
            return resultDto;
        }
        catch (Exception ex)
        {
            resultDto.ErrorMessage = $"Error - {ex.Message}";
            return resultDto;
        }
    }

    // Update
    public async Task<ResultDto> UpdateAsync(VehicleToUpdateDto dto)
    {
        var resultDto = new ResultDto { FunctionPerformed = $"Updating an existing vehicle with Id {dto.Id}" };
        try
        {
            var vehicle = await _repository.GetByIdAsync(dto.Id);
            if (vehicle == null)
            {
                resultDto.ErrorMessage = $"Vehicle with ID {dto.Id} not found for updating";
                return resultDto;
            }
            
            _autoMapper.Map(dto, vehicle);

            await _repository.UpdateAsync(vehicle);
            return resultDto;
        }
        catch (Exception ex)
        {
            resultDto.ErrorMessage = $"Error - {ex.Message}";
            return resultDto;
        }
    }

    // Delete
    public async Task<ResultDto> DeleteAsync(int id)
    {
        var resultDto = new ResultDto { FunctionPerformed = $"Deleting an existing vehicle with Id {id}" };
        try
        {
            var vehicle = await _repository.GetByIdAsync(id);
            if (vehicle == null)
            {
                resultDto.ErrorMessage = $"Vehicle with ID {id} not found for deleting";
                return resultDto;
            }

            await _repository.DeleteAsync(vehicle);
            return resultDto;
        }
        catch (Exception ex)
        {
            resultDto.ErrorMessage = $"Error - {ex.Message}";
            return resultDto;
        }
    }
}
