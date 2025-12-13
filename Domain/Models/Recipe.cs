namespace Domain.Models
{
    public class Recipe : BaseEntity
    {
        public required string Title { get; set; }
        public required string PrepTime { get; set; }
        public required decimal Servings { get; set; }
        public required string Instructions { get; set; }
        public string? SourceUrl { get; set; }
        public required List<RecipeIngredient> Ingredients { get; set; }
    }
}
