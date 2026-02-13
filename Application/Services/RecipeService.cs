using Application.Enums;
using Application.Services.Interfaces;
using Application.Services.Strategy.Interfaces;
using Microsoft.Extensions.Logging;
using RecipesSupport.Application.Providers;

namespace Application.Services
{
    public class RecipeService(
        IIntegrationFactory strategyFactory,
        ILogger<RecipeService> logger) : IRecipeService
    {
        public async Task<string> GetByIngredients(string ingredients)
        {
            var strategy = strategyFactory.GetStrategy(Enums.SystemType.Edamam);

            var result = await strategy.FetchRecipes(ingredients, CancellationToken.None);

            if (result?.Recipes is not null && result.Recipes.Count > 0)
            {
                return string.Join(", ", result.Recipes.Select(r => r.Title ?? string.Empty));
            }

            return string.Empty;
        }

        public async Task<List<ProviderResult>> SearchAcrossAllSystemsAsync(string ingredient, CancellationToken ct)
        {
            using var cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
            cts.CancelAfter(TimeSpan.FromSeconds(3));

            var systems = new[] { SystemType.Edamam, SystemType.Spoonacular, SystemType.TheMealDb, SystemType.Nutritionix };

            var tasks = systems.Select(async type =>
            {
                try
                {
                    var strategy = strategyFactory.GetStrategy(type);

                    return await strategy.FetchRecipes(ingredient, cts.Token);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"Service error: {type}");
                    return new ProviderResult();
                }
            });

            var results = await Task.WhenAll(tasks);

            return results.Select(r => r).ToList();
        }
        public Task<string> GetByRecipeId(int recipeId)
        {
            throw new NotImplementedException();
        }


    }
}
