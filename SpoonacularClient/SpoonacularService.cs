using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace SpoonacularClient
{
    public class SpoonacularService : ISpoonacularService
    {
        private HttpClient _httpClient { get; set; }
        private SpoonacularSettings _settings { get; set; }
        private IMemoryCache _cache { get; set; }

        public SpoonacularService(HttpClient httpClient, IOptions<SpoonacularSettings> settings, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
            _cache = cache;

        }
        public async Task<string> SearchRecipesByIngredients(string ingredients)
        {

            var url = $"{_settings.BaseUrl}/recipes/findByIngredients?ingredients={ingredients}&apiKey={_settings.ApiKey}";
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public async Task<string> GetRecipeInformation(int recipeId)
        {
            string cacheKey = $"{nameof(GetRecipeInformation)}-{recipeId}";

            if (_cache.TryGetValue(cacheKey, out string? result))
            {
                return result ?? string.Empty;
            }

            var url = $"{_settings.BaseUrl}/recipes/{recipeId}/information?apiKey={_settings.ApiKey}";
            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            _cache.Set(cacheKey, content, TimeSpan.FromHours(12));

            return content;
        }
    }
}
