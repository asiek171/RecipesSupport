namespace Domain.Models;

public class UnitOfMeasure : BaseEntity
{
    public required string Name { get; set; }
    public required string UnitType { get; set; }
    public required decimal BaseConversionFactor { get; set; }
}
