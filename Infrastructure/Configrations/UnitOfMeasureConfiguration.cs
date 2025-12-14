using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configrations;

public class UnitOfMeasureConfiguration : IEntityTypeConfiguration<UnitOfMeasure>
{
    public void Configure(EntityTypeBuilder<UnitOfMeasure> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.UnitType)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(u => u.BaseConversionFactor)
            .HasColumnType("decimal(18,6)")
            .IsRequired()
            .HasMaxLength(50);

        builder.HasData(
            new { UnitId = 1, Name = "gram", UnitType = "Weight", BaseConversionFactor = 1.0m },
            new { UnitId = 6, Name = "mililitr", UnitType = "Volume", BaseConversionFactor = 1.0m },
            new { UnitId = 10, Name = "szklanka", UnitType = "Volume", BaseConversionFactor = 250.0m },
            new { UnitId = 12, Name = "sztuka", UnitType = "Other", BaseConversionFactor = 1.0m }
            // ... need to add all other seed data here
        );
    }
}
