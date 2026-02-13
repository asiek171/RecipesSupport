namespace RecipesSupport.Domain.Search
{
    public sealed record RecipeSearchCriteria
    {
        public string Query { get; init; } = default!;
        public int? MaxCalories { get; init; }
        public TimeSpan? MaxPreparationTime { get; init; }
        public IReadOnlyCollection<string> Ingredients { get; init; } = [];
    }
}
