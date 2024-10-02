using DataAccess.Enums;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities;

public class Vehicle : BaseEntity
{
    public int ManufacturerId { get; set; }
    public Manufacturer Manufacturer { get; set; } = null!;


    [Range(1900, 2024)]
    public int MakeYear { get; set; }
    public required string Model { get; set; }
    public VehicleType Type { get; set; }
    public VehicleCondition VehicleCondition { get; set; }
    public decimal? Price { get; set; }                 // nullable
    public StateLocated StateLocated { get; set; }
    public int Views { get; set; }
    public string? Description { get; set; }


    public required IEnumerable<VehicleImage> VehicleImages { get; set; }
}