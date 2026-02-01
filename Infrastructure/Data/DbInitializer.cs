using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RecipesSupport.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task SeedData(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<RecipesSupportDbContext>();

            if (await context.UnitOfMeasures.AnyAsync()) return;

            var units = new List<UnitOfMeasure>{
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "gram", UnitType = "Weight", BaseConversionFactor = 1.0m },
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "dekagram", UnitType = "Weight", BaseConversionFactor = 10.0m },
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "kilogram", UnitType = "Weight", BaseConversionFactor = 1000.0m },
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "miligram", UnitType = "Weight", BaseConversionFactor = 0.001m },
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "funt (lb)", UnitType = "Weight", BaseConversionFactor = 453.59m },
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "uncja (oz)", UnitType = "Weight", BaseConversionFactor = 28.35m },

            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "mililitr", UnitType = "Volume", BaseConversionFactor = 1.0m },
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "litr", UnitType = "Volume", BaseConversionFactor = 1000.0m },
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "łyżeczka", UnitType = "Volume", BaseConversionFactor = 5.0m },
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "łyżka", UnitType = "Volume", BaseConversionFactor = 15.0m },
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "szklanka", UnitType = "Volume", BaseConversionFactor = 250.0m },
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "cup (US)", UnitType = "Volume", BaseConversionFactor = 236.59m },
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "szczypta", UnitType = "Volume", BaseConversionFactor = 0.4m },

            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "sztuka", UnitType = "Other", BaseConversionFactor = 1.0m },
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "puszka", UnitType = "Other", BaseConversionFactor = 1.0m },
            new UnitOfMeasure { Id = Guid.NewGuid(), Name = "ząbek", UnitType = "Other", BaseConversionFactor = 1.0m }
            // ... need to add all other seed data here
            };

            await context.UnitOfMeasures.AddRangeAsync(units);
            await context.SaveChangesAsync();
        }
    }
}
