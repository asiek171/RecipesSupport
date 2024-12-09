using EdamamClient.Models;

namespace EdamamClient
{
    public interface IEdamamService
    {

        public Task<string> NutritinData(string ingredients);
        public Task<string> NutritinDetails(NutritionDetails model);
    }
}
