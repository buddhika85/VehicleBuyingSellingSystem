using AutoMapper;
using DataAccess.Entities;
using DataAccess.Enums;
using DTOs.Vehicles;

namespace DataAccess.BusinessLogic.Helpers;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        // souce to destination
        CreateMap<Vehicle, VehicleToReadDto>()
            .ForMember(d => d.Manufacturer, o => o.MapFrom(s => s.Manufacturer.Name))          // destinations Manufacturer is assigned with source's Name
            .ForMember(d => d.ManufacturerOrignated, o => o.MapFrom(s => s.Manufacturer.Originated));

        CreateMap<VehicleToCreateDto, Vehicle>();

        CreateMap<VehicleToUpdateDto, Vehicle>()      
        .ForMember(dest => dest.ManufacturerId, opt =>
            opt.Condition((src, dest, srcMember) => src.ManufacturerId != null))  // Map only if ManufacturerId is not null
        .ForMember(dest => dest.MakeYear, opt =>
            opt.Condition((src, dest, srcMember) => src.MakeYear != null))
        .ForMember(dest => dest.Model, opt =>
            opt.Condition((src, dest, srcMember) => src.Model != null))
        .ForMember(dest => dest.Price, opt =>
            opt.Condition((src, dest, srcMember) => src.Price != null))

        .ForMember(dest => dest.Type, opt =>
            opt.Condition(src => src.Type != null && Enum.IsDefined(typeof(VehicleType), (int)src.Type)))      // int? to Enum mapping
        .ForMember(dest => dest.VehicleCondition, opt =>
            opt.Condition(src => src.VehicleCondition != null && Enum.IsDefined(typeof(VehicleCondition), (int)src.VehicleCondition)))
        .ForMember(dest => dest.StateLocated, opt =>
            opt.Condition(src => src.StateLocated != null && Enum.IsDefined(typeof(StateLocated), (int)src.StateLocated)));
        ;
    }
}


// notes - field names are different and conditional mapping
//CreateMap<VehicleToUpdateDto, Vehicle>()
//    .ForMember(dest => dest.ManuId, opt => 
//        opt.MapFrom(src => src.ManufacturerId))  // Map ManufacturerId to ManuId
//    .ForMember(dest => dest.ManuId, opt => 
//        opt.Condition((src, dest, srcMember) => src.ManufacturerId != null));  // Map only if ManufacturerId is not null
