using Application.Services.Strategy.Interfaces;
using RecipesSupport.Application.Providers;
using SpoonacularClient;

namespace Application.Services.Strategy
{
    public class SpoonacularStrategy : IIntegrationStrategy
    {
        private readonly ISpoonacularService _service;
        public SpoonacularStrategy(ISpoonacularService service)
        {
            _service = service;
        }
        public async Task<ProviderResult> FetchRecipes(string query, CancellationToken ct)
        {
            var response = await _service.SearchRecipesByIngredients(query, ct);
            return new ProviderResult()
            {
                IsSuccess = response != null,
                Recipes = new List<ProviderRecipeDto> { new ProviderRecipeDto { Title = " spoonacular" } }
            };
        }
    }
}
