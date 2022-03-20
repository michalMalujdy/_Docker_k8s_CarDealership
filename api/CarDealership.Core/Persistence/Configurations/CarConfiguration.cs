using CarDealership.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealership.Core.Persistence.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder.Property(x => x.Make)
            .HasMaxLength(150);

        builder.Property(x => x.Model)
            .HasMaxLength(150);

        builder.Property(x => x.RegistrationNumber)
            .HasMaxLength(50);
    }
}