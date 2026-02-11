using EdamamClient.Configuration;
using EdamamClient.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;
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

        public async Task<EdamamNutritionDataResponse> NutritionData(string ingredient, CancellationToken ct)
        {
            var url = $"{_settings.BaseUrl}/api/nutrition-data?app_id={_settings.Auth.App_id}&app_key={_settings.Auth.App_key}&nutrition-type=cooking&ingr={HttpUtility.UrlEncode(ingredient)}";

            var response = await _httpClient.GetAsync(url);

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<EdamamNutritionDataResponse>(content);

            if (result is null)
            {
                throw new InvalidOperationException("Failed to deserialize EdamamRecipeResponse from API response.");
            }

            return result;
        }

        public async Task<EdamamRecipeResponse> Recipes(string ingredient, CancellationToken ct)
        {
            var url = $"{_settings.BaseUrl}/api/recipes/v2?app_id={_settings.Auth.App_id}&app_key={_settings.Auth.App_key}&type=public&q={HttpUtility.UrlEncode(ingredient)}";

            var response = await _httpClient.GetAsync(url,ct);

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<EdamamRecipeResponse>(content);

            if (result is null)
            {
                throw new InvalidOperationException("Failed to deserialize EdamamRecipeResponse from API response.");
            }

            return result;
        }

        public Task<string> NutritinDetails(NutritionDetails model, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

    }
}
