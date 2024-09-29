using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config;

public class ManufacturerConfiguration : IEntityTypeConfiguration<Manufacturer>
{
    public void Configure(EntityTypeBuilder<Manufacturer> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        
        // Creating a unique index on the 'Name' property
        builder.HasIndex(m => m.Name).IsUnique();

        builder.Property(x => x.Originated).HasMaxLength(100);
    }
}