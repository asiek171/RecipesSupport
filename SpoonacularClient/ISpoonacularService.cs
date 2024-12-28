namespace SpoonacularClient
{
    public interface ISpoonacularService
    {
        Task<string> SearchRecipesByIngredients(string ingredients);
        Task<string> GetRecipeInformation(int recipeId);
    }
}
