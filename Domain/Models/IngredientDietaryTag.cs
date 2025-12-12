namespace Domain.Models
{
    public class IngredientDietaryTag : BaseEntity
    {
        public Guid IngredientId { get; set; }
        public virtual Ingredient? Ingredient { get; set; }
        public Guid DietayTagId { get; set; }
        public virtual DietaryTag? DietaryTag { get; set; }
    }
}
