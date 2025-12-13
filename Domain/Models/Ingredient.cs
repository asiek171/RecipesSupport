namespace Domain.Models
{
    public class Ingredient : BaseEntity
    {
        public string? Name { get; set; }
        public string? NormalizedName { get; set; }
        public string? Category { get; set; }
    }
}
