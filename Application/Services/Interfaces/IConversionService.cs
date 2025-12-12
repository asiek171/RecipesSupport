using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciesSupport.Application.Services.Interfaces
{
    public interface IConversionService
    {
        decimal Convert(decimal quantity, string fromUnit, string toUnit);
        decimal Scale(decimal curentQuanity, decimal currentServings, decimal newServings);
    }
}
