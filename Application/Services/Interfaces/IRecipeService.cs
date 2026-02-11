using Application.Models;
using RecipesSupport.Application.Providers;

namespace Application.Services.Interfaces
{
    public interface IRecipeService
    {
        Task<string> GetByIngredients(string ingedients);
        Task<string> GetByRecipeId(int recipeId);
        Task<List<ProviderResult>> SearchAcrossAllSystemsAsync(string ingredient, CancellationToken ct);
    }
}
