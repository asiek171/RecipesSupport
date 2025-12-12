using ReciesSupport.Application.Services.Interfaces;
using RecipesSuport.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciesSupport.Application.Services
{
    public class RecipeScallingService(
            IRecipeRepository recipeRepository,
            IConversionService converionService
        )
        : IRecipeScalingService
    {
        public async Task<List<ScaledIngredient>> ScaleRecipeAsync(Guid recipeId, decimal newSerwings)
        {
            var recipe = await recipeRepository.GetRecipeWithIngredients(recipeId);
            if (recipe == null || recipe.Ingredients == null || recipe.Servings == 0)
            {
                throw new ArgumentException("Invalid recipe or missing servings information.");
            }

            var curretServngs = recipe.Servings;
            var scaledIngredients = new List<ScaledIngredient>();

            foreach (var ingredient in recipe.Ingredients)
            {
                var newQuantity = converionService.Scale(
                    ingredient.Quantity,
                    recipe.Servings,
                    newSerwings
                );

                scaledIngredients.Add(new ScaledIngredient(
                    ingredient.Ingredient!.Name ?? "Unknown Ingredient",
                    newQuantity,
                    ingredient.UnitOfMeasure!.Name ?? "Unknown Unit"
                ));
            }

            return scaledIngredients;
        }
    }
}
