namespace RecipesSuport.Infrastructure.Data.Repositories
{
    public interface IUnitOfMeasureRepository
    {
        /// <summary>
        /// Gets a unit of measure by its name. Within the context of recipe scaling.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<UnitOfMeasure> GetByUnitNameAsync(string unitName);
    }
    public class UntOfMeasureRepository : IUnitOfMeasureRepository
    {
        public Task<UnitOfMeasure> GetByUnitNameAsync(string unitName)
        {
            throw new NotImplementedException();
        }
    }
}
