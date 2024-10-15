namespace DTOs.Vehicles;

public class VehicleToUpdateDto
{
    public int Id { get; set; }
    public int? ManufacturerId { get; set; }             // FK
    public int? MakeYear { get; set; }
    public string? Model { get; set; }

    public decimal? Price { get; set; }

    // mapped with enums
    public int? Type { get; set; }
    public int? VehicleCondition { get; set; }
    public int? StateLocated { get; set; }

   
    public string? Description { get; set; }

    // image path list
    // To Do
    public IEnumerable<string>? VehicleImages { get; set; }
}
