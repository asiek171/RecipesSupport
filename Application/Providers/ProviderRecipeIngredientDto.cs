using Domain.Models;

namespace RecipesSupport.Application.Providers
{
    public class ProviderRecipeIngredientDto
    {
        public ProviderIngredientDto? Ingredient { get; set; }
        public decimal? Quantity { get; set; }
        public ProviderUnitOfMeasureDto? UnitOfMeasure { get; set; }
    }
}
