using Application.Models;

namespace Application.Services.Interfaces
{
    public interface IIngredientService
    {
        List<Ingredient> Get();
        Task<bool> Add(Ingredient model);
    }
}
