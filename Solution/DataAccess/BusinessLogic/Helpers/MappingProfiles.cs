using AutoMapper;
using DataAccess.Entities;
using DTOs.Vehicles;

namespace DataAccess.BusinessLogic.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Vehicle, VehicleToReadDto>()
            .ForMember(d => d.Manufacturer, o => o.MapFrom(s => s.Manufacturer.Name))          // destinations Manufacturer is assigned with source's Name
            .ForMember(d => d.ManufacturerOrignated, o => o.MapFrom(s => s.Manufacturer.Originated));

        CreateMap<VehicleToCreateDto, Vehicle>();
    }
}
