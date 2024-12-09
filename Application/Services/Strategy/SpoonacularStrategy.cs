using Application.Services.Strategy.Interfaces;
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
        public async Task<string> FetchRecipes(string query)
        {
            return await _service.SearchRecipesByIngredients(query);
        }
    }
}
