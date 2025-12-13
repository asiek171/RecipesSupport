using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReciesSupport.Application.Interfaces;

namespace RecipesSuport.Infrastructure.Data.Repositories;

public class IngredientTagRepository(RecipesSupportDbContext context) : IIngredientTagRepository
{
    private static readonly Dictionary<Guid, List<string>> _itCache = new();
    public Dictionary<Guid, List<string>> GetAllTagsGroupedByIngredient()
    {
        return _itCache.ToDictionary(p => p.Key, p => p.Value);
    }

    public async Task<List<string>> GetTagsByIngredientId(Guid ingredientId)
    {
        if (_itCache.IsNullOrEmpty())
        {
            await InitializeCache();
        }
        if (_itCache.TryGetValue(ingredientId, out var tags))
        {
            return tags;
        }
        return new List<string>();
    }

    private async Task InitializeCache()
    {
        var allTags = await context.IngredientDietaryTags
            .AsNoTracking()
            .Include(it => it.DietaryTag)
            .Select(it => new
            {
                IngredientId = it.IngredientId,
                TagName = it.DietaryTag!.Name
            })
            .ToListAsync();

        var groupedTags = allTags
            .GroupBy(it => it.IngredientId)
            .ToDictionary(
                g => g.Key,
                g => g.Select(it => it.TagName).ToList()
            );

        foreach (var item in groupedTags)
        {
            _itCache.TryAdd(item.Key, item.Value);
        }
    }
}
