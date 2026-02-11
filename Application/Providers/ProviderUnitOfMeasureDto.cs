namespace RecipesSupport.Application.Providers
{
    public class ProviderUnitOfMeasureDto
    {
        public string? Name { get; set; }
        public string? UnitType { get; set; }
        public decimal? BaseConversionFactor { get; set; }
    }
}
