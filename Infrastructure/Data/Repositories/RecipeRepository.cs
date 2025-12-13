using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ReciesSupport.Application.Interfaces;

namespace RecipesSuport.Infrastructure.Data.Repositories;

public class RecipeRepository(RecipesSupportDbContext context) : IRecipeRepository
{
    public async Task<Recipe> GetRecipeWithIngredients(Guid recipeId)
    {
        return await context.Recipes.AsNoTracking()
            .Include(r => r.Ingredients)
            .ThenInclude(r => r.UnitOfMeasure)
            .Where(r => r.Id == recipeId)
            .SingleAsync();
    }
}
