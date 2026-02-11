namespace SpoonacularClient
{
    public interface ISpoonacularService
    {
        Task<string> SearchRecipesByIngredients(string ingredients, CancellationToken ct);
        Task<string> GetRecipeInformation(int recipeId, CancellationToken ct);
    }
}
