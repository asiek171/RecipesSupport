namespace RecipesSupport.Application.Interfaces;

public interface IUnitOfMeasureRepository
{
    /// <summary>
    /// Asynchronously retrieves a unit of measure by its name.
    /// </summary>
    /// <param name="unitName">The name of the unit of measure to retrieve. Cannot be <see langword="null"/> or empty.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains a <see
    /// cref="RecipesSupport.Application.Models.UnitOfMeasureDTO"/> representing the unit of measure if found; otherwise,
    /// <see langword="null"/>.</returns>
    Task<RecipesSupport.Application.Models.UnitOfMeasureDTO> GetByUnitNameAsync(string unitName);
}
