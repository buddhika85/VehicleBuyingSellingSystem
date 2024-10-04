namespace DTOs.Vehicles;

public class VehicleToCreateDto
{
    public int ManufacturerId { get; set; }             // FK
    public int MakeYear { get; set; }
    public required string Model { get; set; }
    
    public decimal? Price { get; set; }                 

    // mapped with enums
    public int Type { get; set; }                   
    public int VehicleCondition { get; set; }
    public int StateLocated { get; set; }

    public int Views = 0;
    public string? Description { get; set; }

    // image path list
    // To Do
    public required IEnumerable<string> VehicleImages { get; set; }
}
