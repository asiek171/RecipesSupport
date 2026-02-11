using Application.Services.Strategy.Interfaces;
using EdamamClient;
using RecipesSupport.Application.Providers;

namespace Application.Services.Strategy
{
    public class EdamamStrategy : IIntegrationStrategy
    {
        private readonly IEdamamService _service;
        public EdamamStrategy(IEdamamService service)
        {
            _service = service;
        }
        public async Task<ProviderResult> FetchRecipes(string query, CancellationToken ct)
        {
            var result = await _service.Recipes(query, ct);

            var ingredients = new List<ProviderRecipeIngredientDto>();

            return new ProviderResult
            {
                IsSuccess = result != null,
                Recipes = new List<ProviderRecipeDto>
                {
                    new ProviderRecipeDto
                    {
                        Title = result!.Hits[0].Recipe.Label
                    }
                },
                Error = result == null ? "Failed to fetch data from Edamam." : null
            };
        }
    }
}
