using Application.Enums;
using RecipesSupport.Domain.Search;

namespace RecipesSupport.Application.Providers
{
    public interface IRecipeProvider
    {
        SystemType Name { get; }

        Task<ProviderResult> SearchAsync(
            RecipeSearchCriteria criteria,
            CancellationToken token);
    }
}
