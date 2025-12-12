namespace Application.Models
{
    public class Ingredient
    {
        public string? Name { get; set; }
        public string? Category { get; set; }
        public required string NormalizedName { get; set; }
    }
}
