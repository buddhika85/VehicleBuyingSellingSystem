using Core.Entities;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    // -- create new migration command
    // dotnet ef migrations add initialCreate -s API -p Infrastructure
    // s means start up project of solution
    // p means where to apply the migration

    // -- update data
    //dotnet ef database update -s API -p Infrastructure

    // dotnet ef migrations remove
    public class StoreContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<VehicleImage> VehicleImages { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VehicleConfiguration).Assembly);
        }

    }
}