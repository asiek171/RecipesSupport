using Application.Services.Strategy.Interfaces;
using NutritionixClient;

namespace Application.Services.Strategy
{
    public class NutritionixStrategy : IIntegrationStrategy
    {
        private readonly INutritionixService _service;
        public NutritionixStrategy(INutritionixService service)
        {
            _service = service;
        }
        public async Task<string> FetchRecipes(string query)
        {
            return await _service.SearchRecipesByIngredients(query);
        }
    }
}
