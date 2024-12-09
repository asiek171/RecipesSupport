
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using NutritionixClient.Configuration;
using NutritionixClient.Models;
using System.Collections.Specialized;
using System.Text;
using System.Text.Json;

namespace NutritionixClient
{
    public class NutritionixService : INutritionixService
    {
        private HttpClient _httpClient;
        private NutritionixSettings _settings;
    //    private IMemoryCache _cache;

        public NutritionixService(HttpClient httpClient, IOptions<NutritionixSettings> settings//, IMemoryCache cache
                                                                                               )
        {
           // _cache = cache;
            _httpClient = httpClient;
            _settings = settings.Value;
        }

        public async Task<string> GetToken()
        {
            var url = $"{_settings.BaseUrl}/v2/natural/nutrients";

            using var httpClient = GetClientWithHeaders();
            var json = JsonSerializer.Serialize(_settings.Auth);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(url, content);

            response.EnsureSuccessStatusCode();
            var contentResponse = await response.Content.ReadAsStringAsync();

            return contentResponse;
        }

        public async Task<string> SearchRecipesByIngredients(string query)
        {
            var url = $"{_settings.BaseUrl}/v2/search/instant?";
      //  https://trackapi.nutritionix.com/v2/natural/nutrients
            var httpClient = GetClientWithHeaders();
            var req = new Request() { Query = query };

            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

            queryString.Add("query", query);
            var json = JsonSerializer.Serialize(req);
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.GetAsync($"{url}{queryString.ToString()}");

            response.EnsureSuccessStatusCode();
            var contentResponse = await response.Content.ReadAsStringAsync();

            return contentResponse;
        }
        
        private HttpClient GetClientWithHeaders()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-app-id", _settings.Auth?.ApplicationID);
            httpClient.DefaultRequestHeaders.Add("x-app-key", _settings.Auth?.Secret);

            return httpClient;

        }
    }
}
