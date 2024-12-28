using EdamamClient.Configuration;
using EdamamClient.Models;
using Microsoft.Extensions.Options;
using System.Web;

namespace EdamamClient
{
    public class EdamamService : IEdamamService
    {
        private readonly HttpClient _httpClient;
        private readonly EdamamSettings _settings;

        public EdamamService(HttpClient httpClient, IOptions<EdamamSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<string> NutritinData(string ingredient)
        {
            var url = $"{_settings.BaseUrl}/api/nutrition-data?app_id={_settings.Auth.App_id}&app_key={_settings.Auth.App_key}&nutrition-type=cooking&ingr={HttpUtility.UrlEncode(ingredient)}";

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public Task<string> NutritinDetails(NutritionDetails model)
        {
            throw new NotImplementedException();
        }
    }
}
