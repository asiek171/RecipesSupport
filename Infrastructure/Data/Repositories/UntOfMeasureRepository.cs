using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RecipesSupport.Application.Mappers;
using RecipesSupport.Application.Models;
using RecipesSupport.Application.Interfaces;

namespace RecipesSupport.Infrastructure.Data.Repositories;

public class UntOfMeasureRepository(RecipesSupportDbContext context) : IUnitOfMeasureRepository
{
    private static readonly Dictionary<string, UnitOfMeasureDTO> _uomCache = new();
    public async Task<UnitOfMeasureDTO> GetByUnitNameAsync(string unitName)
    {
        if (_uomCache.TryGetValue(unitName, out var cachedUom))
        {
            return cachedUom;
        }

        await InitializeCache();

        if (_uomCache.TryGetValue(unitName, out cachedUom))
        {
            return cachedUom;
        }
        return new();
    }

    private async Task InitializeCache()
    {
        if (_uomCache.IsNullOrEmpty()) return;

        var allUnits = await context.UnitOfMeasures.AsNoTracking()
            .Select(u => u.ToDto()
        ).ToListAsync();

        foreach (var uom in allUnits)
        {
            if (uom?.Name == null) continue;
            _uomCache.TryAdd(uom!.Name, uom);
        }
    }
}

