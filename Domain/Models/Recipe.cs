namespace Domain.Models
{
    public class Recipe : BaseEntity
    {
        public string? Name { get; set; }
        public List<Ingredient>? Ingredients { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
    }
}
