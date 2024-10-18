namespace DTOs.Vehicles;

public class VehicleToReadDto
{
    // FK    
    public int Id { get; set; }
    public int ManufacturerId { get; set; }
    public string Manufacturer { get; set; } = null!;
    public string ManufacturerOrignated { get; set; } = null!;

    public int MakeYear { get; set; }
    public required string Model { get; set; }
    public string Type { get; set; } = null!;
    public string VehicleCondition { get; set; } = null!;
    public decimal? Price { get; set; }                 // nullable
    public string StateLocated { get; set; } = null!;
    public int Views { get; set; }
    public string? Description { get; set; }


    public required IEnumerable<string> VehicleImages { get; set; }
}
