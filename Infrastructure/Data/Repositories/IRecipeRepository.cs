using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesSuport.Infrastructure.Data.Repositories
{
    public interface IRecipeRepository
    {
        Task<Recipe> GetRecipeWithIngredients(Guid recipeId);
    }

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
}
