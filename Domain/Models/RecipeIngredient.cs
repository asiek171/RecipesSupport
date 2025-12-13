namespace Domain.Models
{
    public class RecipeIngredient : BaseEntity
    {
        public Guid IngredientId { get; set; }
        public virtual Ingredient? Ingredient { get; set; }
        public required decimal Quantity { get; set; }
        public Guid UnitOfMeasureId { get; set; }
        public virtual UnitOfMeasure? UnitOfMeasure { get; set; }
    }
}
