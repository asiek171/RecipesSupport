using Application.Services.Strategy.Interfaces;
using RecipesSupport.Application.Providers;
using TheMealDbClient;

namespace Application.Services.Strategy
{
    public class TheMealDbStrategy : IIntegrationStrategy
    {
        private readonly ITheMealDbService _service;
        public TheMealDbStrategy(ITheMealDbService service)
        {
            _service = service;
        }
        public async Task<ProviderResult> FetchRecipes(string query, CancellationToken ct)
        {
            var response = await _service.GetSingleRandom();
            return new ProviderResult()
            {
                IsSuccess = response != null,
                Recipes = new List<ProviderRecipeDto> { new ProviderRecipeDto { Title = " TheMealDb" } }
            };
        }
    }
}
