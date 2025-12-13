using Domain.Models;
using ReciesSupport.Application.Models;

namespace ReciesSupport.Application.Mappers;
public static class RecipeMappingExtensions
{
    public static UnitOfMeasureDTO ToDto(this UnitOfMeasure uom)
    {
        return new UnitOfMeasureDTO
        {
            Name = uom.Name,
            UnitType = uom.UnitType,
            BaseConversionFactor = uom.BaseConversionFactor
        };
    }

}
