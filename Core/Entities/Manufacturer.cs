namespace Core.Entities
{
    public class Manufacturer : BaseEntity
    {
        public required string Name { get; set; }
        public required string Originated { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }    
}