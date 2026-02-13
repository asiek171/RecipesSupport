using Application.Services.Strategy.Interfaces;
using NutritionixClient;
using RecipesSupport.Application.Providers;
using System.Reflection.Metadata.Ecma335;

namespace Application.Services.Strategy
{
    public class NutritionixStrategy : IIntegrationStrategy
    {
        private readonly INutritionixService _service;
        public NutritionixStrategy(INutritionixService service)
        {
            _service = service;
        }
        public async Task<ProviderResult> FetchRecipes(string query, CancellationToken ct)
        {
            var response = await _service.SearchRecipesByIngredients(query);
            return new ProviderResult()
            {
                IsSuccess = response != null,
                Recipes = new List<ProviderRecipeDto> { new ProviderRecipeDto { Title = " nutritionix" } }
            };
        }
    }
}
