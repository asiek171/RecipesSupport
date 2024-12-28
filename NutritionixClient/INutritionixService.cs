namespace NutritionixClient
{
    public interface INutritionixService
    {
        Task<string> SearchRecipesByIngredients(string ingredients);
    }
}
