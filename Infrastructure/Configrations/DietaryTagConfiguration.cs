using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configrations;

public class DietaryTagConfiguration : IEntityTypeConfiguration<DietaryTag>
{
    public void Configure(EntityTypeBuilder<DietaryTag> builder)
    {
        
    }
}
