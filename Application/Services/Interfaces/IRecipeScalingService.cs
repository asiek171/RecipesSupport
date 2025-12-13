using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciesSupport.Application.Services.Interfaces
{
    public record ScaledIngredient(string Name, decimal Quantity, string UnitName);
    public interface IRecipeScalingService
    {
        Task<List<ScaledIngredient>> ScaleRecipeAsync(Guid recipeId, decimal newSerwings);
    }
}

  