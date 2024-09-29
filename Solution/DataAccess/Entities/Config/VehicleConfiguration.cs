using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.Property(x => x.Price).HasColumnType("decimal(18,2)");
        builder.Property(x => x.Model).HasMaxLength(500);
        builder.Property(x => x.Description).IsRequired();
       
        // Define the foreign key relationship between Vehicle and Manufacturer
        // Vehicle has exactly one manufacturer and a manufacturer may have zero to many Vehicles
        builder.HasOne(c => c.Manufacturer)
           .WithMany(m => m.Vehicles)  // Manufacturer has many Vehicles
           .HasForeignKey(c => c.ManufacturerId)  // Foreign key in Vehicle entity
           .OnDelete(DeleteBehavior.Cascade); // when manufacturer deleted vehicle also gets deleted
    }
}