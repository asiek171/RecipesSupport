namespace Domain.Models
{
    public class Ingredient : BaseEntity
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public double Quantity { get; set; }
    }
}
