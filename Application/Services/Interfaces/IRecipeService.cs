using Application.Models;

namespace Application.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<string> GetByIngredients(string ingedients);
        Task<string> GetByRecipeId(int recipeId);
    }
}
