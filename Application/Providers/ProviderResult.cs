using Domain.Models;

namespace RecipesSupport.Application.Providers
{
    public sealed record ProviderResult
    {
        public bool IsSuccess { get; init; }
        public IReadOnlyCollection<ProviderRecipeDto> Recipes { get; init; } = [];
        public string? Error { get; init; }
    }
}
