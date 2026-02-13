using RecipesSupport.Application.Providers;

namespace Application.Services.Strategy.Interfaces
{
    public interface IIntegrationStrategy
    {
        Task<ProviderResult> FetchRecipes(string query, CancellationToken ct);
    }
}
