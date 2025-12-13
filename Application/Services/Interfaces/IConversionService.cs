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
        /// <summary>
        /// Converts a specified quantity from one unit of measurement to another.
        /// </summary>
        /// <param name="quantity">The numeric value to convert. Must be greater than or equal to zero.</param>
        /// <param name="fromUnit">The unit of measurement to convert from. Cannot be <see langword="null"/> or empty.</param>
        /// <param name="toUnit">The unit of measurement to convert to. Cannot be <see langword="null"/> or empty.</param>
        /// <returns>The equivalent value of <paramref name="quantity"/> expressed in the <paramref name="toUnit"/> unit.</returns>
        Task<decimal> Convert(decimal quantity, string fromUnit, string toUnit);
        /// <summary>
        /// Calculates the adjusted quantity of an ingredient based on a change in the number of servings.
        /// </summary>
        /// <param name="curentQuanity">The original quantity of the ingredient to be scaled.</param>
        /// <param name="currentServings">The original number of servings that <paramref name="curentQuanity"/> is intended for. Must be greater than
        /// zero.</param>
        /// <param name="newServings">The desired number of servings to scale the quantity to. Must be greater than zero.</param>
        /// <returns>The scaled quantity of the ingredient for <paramref name="newServings"/> servings.</returns>
        decimal Scale(decimal curentQuanity, decimal currentServings, decimal newServings);
    }
}
