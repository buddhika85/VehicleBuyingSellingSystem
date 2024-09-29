namespace DataAccess.Entities;

public class VehicleImage : BaseEntity
{
    public required string ImagePath { get; set; }

    // FK
    public int? VehicleId { get; set; }
    public Vehicle? Vehicle { get; set; }
}