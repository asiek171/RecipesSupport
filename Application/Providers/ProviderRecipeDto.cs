using Domain.Models;

namespace RecipesSupport.Application.Providers
{
    public class ProviderRecipeDto
    {
        public string? Title { get; set; }
        public string? PrepTime { get; set; }
        public decimal? Servings { get; set; }
        public string? Instructions { get; set; }
        public string? SourceUrl { get; set; }
        public List<ProviderRecipeIngredientDto>? Ingredients { get; set; }
    }
}
