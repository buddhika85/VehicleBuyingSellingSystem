using DataAccess.Entities;

namespace DataAccess.Data.Specifications;

public class VehiclesWithManufacturerSpecification : BaseSpecifications<Vehicle>
{

    public VehiclesWithManufacturerSpecification()
    {
        AddInclude(x => x.Manufacturer);
        AddInclude(x => x.VehicleImages);
    }

    public VehiclesWithManufacturerSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.Manufacturer);
        AddInclude(x => x.VehicleImages);
    }
}
