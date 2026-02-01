using RecipesSupport.Application.Interfaces;
using RecipesSupport.Application.Models;
using RecipesSupport.Application.Services.Interfaces;
using System.Collections.Concurrent;

namespace RecipesSupport.Application.Services
{
    public class ConversionService(
        IUnitOfMeasureRepository unitOfMeasureRepository
        ) : IConversionService
    {
        private readonly ConcurrentDictionary<string, UnitOfMeasureDTO> _uomCache = new();
        public async Task<decimal> Convert(decimal quantity, string fromUnitName, string toUnitName)
        {
            if (fromUnitName == toUnitName)
            {
                return quantity;
            }

            var fromUnit = await GetUnitData(fromUnitName);
            var toUnit = await GetUnitData(toUnitName);

            if (fromUnit.UnitType != toUnit.UnitType)
                throw new ArgumentException($"Cannot convert between different unit types: '{fromUnit.UnitType}' and '{toUnit.UnitType}'.");

            return quantity *
                fromUnit.BaseConversionFactor!.Value /
                toUnit.BaseConversionFactor!.Value;

        }

        public decimal Scale(decimal curentQuanity, decimal currentServings, decimal newServings)
        {
            if (currentServings <= 0)
            {
                throw new ArgumentException("Current servings must be greater than zero.", nameof(currentServings));
            }

            return (curentQuanity / currentServings) * newServings;
        }

        private async Task<UnitOfMeasureDTO> GetUnitData(string unitName)
        {
            if (_uomCache.TryGetValue(unitName, out var cachedUom))
            {
                return cachedUom;
            }
            var uom = await unitOfMeasureRepository.GetByUnitNameAsync(unitName);
            if (uom == null)
                throw new ArgumentException($"Unit of measure '{unitName}' not found.", nameof(unitName));

            _uomCache.TryAdd(unitName, uom);
            return uom;
        }
    }
}
