using Application.Enums;
using RecipesSupport.Application.Providers;
using RecipesSupport.Domain.Search;
using SpoonacularClient;

namespace RecipesSupport.Infrastructure.Providers.Spoonacular
{
    public class SpoonacularRecipeProvider(ISpoonacularService service) : IRecipeProvider
    {
        public SystemType Name => SystemType.Spoonacular;

        public async Task<ProviderResult> SearchAsync(RecipeSearchCriteria criteria, CancellationToken ct)
        {
            var response = await service.SearchRecipesByIngredients(string.Join(',', criteria.Ingredients), ct);

            return new ProviderResult { };
        }
    }
}
