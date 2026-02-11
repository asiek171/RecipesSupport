using EdamamClient.Models;
using System.Threading.Tasks;

namespace EdamamClient
{
    public interface IEdamamService
    {
        public Task<EdamamNutritionDataResponse> NutritionData(string ingredients, CancellationToken ct);
        public Task<EdamamRecipeResponse> Recipes(string ingredient, CancellationToken ct);
        public Task<string> NutritinDetails(NutritionDetails model, CancellationToken ct);
    }
}
