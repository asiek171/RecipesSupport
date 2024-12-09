using Application.Services.Strategy.Interfaces;
using EdamamClient;

namespace Application.Services.Strategy
{
    public class EdamamStrategy : IIntegrationStrategy
    {
        private readonly IEdamamService _service;
        public EdamamStrategy(IEdamamService service)
        {
            _service = service;
        }
        public async Task<string> FetchRecipes(string query)
        {
            return await _service.NutritinData(query);
        }
    }
}
