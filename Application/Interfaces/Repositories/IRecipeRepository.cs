using Domain.Models;

namespace RecipesSupport.Application.Interfaces.Repositories;

public interface IRecipeRepository
{
    /// <summary>
    /// Retrieves a recipe along with its associated ingredients by the specified recipe identifier.
    /// </summary>
    /// <param name="recipeId">The unique identifier of the recipe to retrieve.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the <see cref="Recipe"/> with its
    /// ingredients if found; otherwise, <see langword="null"/>.</returns>
    Task<Recipe> GetRecipeWithIngredients(Guid recipeId);
}
