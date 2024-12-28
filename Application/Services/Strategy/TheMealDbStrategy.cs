using Application.Services.Strategy.Interfaces;
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
        public async Task<string> FetchRecipes(string query)
        {
            return await _service.GetSingleRandom();
        }
    }
}
