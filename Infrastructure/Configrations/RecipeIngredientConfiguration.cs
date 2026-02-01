using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configrations;

public class RecipeIngredientConfiguration : IEntityTypeConfiguration<RecipeIngredient>
{
    public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.Ingredient)
            .WithMany()
            .HasForeignKey(r => r.IngredientId);

        builder.HasOne(r => r.UnitOfMeasure)
            .WithMany()
            .HasForeignKey(r => r.UnitOfMeasureId);

        builder.Property(r => r.Quantity)
            .HasColumnType("decimal(18,4)")
            .IsRequired();

        builder.HasOne(r => r.Ingredient)
            .WithMany()
            .HasForeignKey(r => r.IngredientId);

        builder.HasOne(r => r.UnitOfMeasure)
            .WithMany()
            .HasForeignKey(r => r.UnitOfMeasureId);
    }
}
