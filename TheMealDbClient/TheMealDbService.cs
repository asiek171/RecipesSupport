using Microsoft.Extensions.Options;
using TheMealDbClient.Configuration;

namespace TheMealDbClient
{
    public class TheMealDbService : ITheMealDbService
    {
        readonly TheMealDbSettings _settings;
        readonly HttpClient _httpClient;

        public TheMealDbService(IOptions<TheMealDbSettings> settings, HttpClient httpClient)
        {
            _settings = settings.Value;
            _httpClient = httpClient;
        }

        public Task<string> FilterBy(string filer)
        {
            throw new NotImplementedException();
        }

        public Task<string> FilterByMainIngredient(string mainIngredient)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetByFirstLetter(string firstLetter)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetListOf(string type)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetSingleRandom()
        {
            var url = $"{_settings.BaseUrl}/random.php";

            var response = await _httpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            var contentResponse = await response.Content.ReadAsStringAsync();

            return contentResponse;
        }
    }
}
