using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configrations;

public class IngredientDietaryTagConfiguration : IEntityTypeConfiguration<IngredientDietaryTag>
{
    public void Configure(EntityTypeBuilder<IngredientDietaryTag> builder)
    {

    }
}
