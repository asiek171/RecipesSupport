using ReciesSupport.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReciesSupport.Application.Services
{
    public class ConversioService : IConversionService
    {
        public decimal Convert(decimal quantity, string fromUnit, string toUnit)
        {
            throw new NotImplementedException();
        }

        public decimal Scale(decimal curentQuanity, decimal currentServings, decimal newServings)
        {
            if(currentServings <= 0)
            {
                throw new ArgumentException("Current servings must be greater than zero.", nameof(currentServings));
            }

            return (curentQuanity / currentServings) * newServings;
        }
    }
}
