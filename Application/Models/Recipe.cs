namespace Application.Models
{
    public class Recipe
    {
        public string? Name { get; set; }
        public List<Ingredient>? Ingrdients { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
    }
}
