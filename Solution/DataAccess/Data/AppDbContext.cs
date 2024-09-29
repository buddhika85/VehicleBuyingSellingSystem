using DataAccess.Entities;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data;


// -- create new migration command
// dotnet ef migrations add initialCreate -s API -p DataAccess
// s means start up project of solution
// p means where to apply the migration, this is the project which contains DBContext

// -- update data
//dotnet ef database update -s API -p DataAccess

// dotnet ef migrations remove -s API -p DataAccess


public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    // tables
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<VehicleImage> VehicleImages { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // entity configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleConfiguration).Assembly);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManufacturerConfiguration).Assembly);
    }
}
