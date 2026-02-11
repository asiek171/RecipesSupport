namespace RecipesSupport.Application.Interfaces.Repositories;

public interface IIngredientTagRepository
{
    /// <summary>
    /// Retrieves a list of tags associated with the specified ingredient.
    /// </summary>
    /// <param name="ingredientId">The unique identifier of the ingredient for which to retrieve tags.</param>
    /// <returns>A list of strings containing the tags linked to the specified ingredient. The list is empty if the ingredient has no
    /// associated tags.</returns>
    Task<List<string>> GetTagsByIngredientId(Guid ingredientId);

    /// <summary>
    /// Retrieves all tags associated with ingredients, grouped by ingredient identifier.
    /// </summary>
    /// <returns>A dictionary where each key is the unique identifier of an ingredient, and the corresponding value is a list of
    /// tags associated with that ingredient. The list will be empty if an ingredient has no tags.</returns>
    Dictionary<Guid, List<string>> GetAllTagsGroupedByIngredient();
}
