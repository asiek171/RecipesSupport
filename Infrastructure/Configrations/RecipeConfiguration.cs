using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configrations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasKey(r => r.Id);

        builder.Property(r => r.Title);

        builder.Property(r => r.PrepTime);
        
        builder.Property(r => r.Servings);

        builder.Property(r => r.Instructions);

        builder.Property(r => r.SourceUrl);

        builder.HasMany(r => r.Ingredients)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
