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
    }
}
