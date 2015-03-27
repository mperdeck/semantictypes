using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes.TypeSystem.Physics
{
    /// <summary>
    /// Encapsulates a weight.
    /// For conversions, see
    /// http://www.convert-me.com/en/
    /// </summary>
    public class Weight : SemanticDoubleType<Weight>
    {
        /// <summary>
        /// Creates a new weight
        /// </summary>
        /// <param name="value">
        /// Energy in KiloGrams
        /// </param>
        public Weight(double value) : base(value) { }

        /// <summary>
        /// Creates a new weight.
        /// This method is nominally a duplicate of the constructor.
        /// However, using this makes it totally clear that you're passing in a value 
        /// in kilograms.
        /// </summary>
        /// <param name="value">
        /// Weight in kilograms
        /// </param>
        /// <returns></returns>
        public static Weight FromKiloGrams(double value)
        {
            return new Weight(value);
        }

        /// <summary>
        /// Returns the weight in KiloGrams.
        /// </summary>
        /// <returns></returns>
        public double KiloGrams
        {
            get { return Value; }
        }

        private const double PoundsToKiloGrams = 0.453592;
        private const double StonesToPounds = 14;

        /// <summary>
        /// Creates a new weight.
        /// </summary>
        /// <param name="value">
        /// Weight in pounds (British, US)
        /// </param>
        /// <returns></returns>
        public static Weight FromPounds(double value)
        {
            return new Weight(value * PoundsToKiloGrams);
        }

        /// <summary>
        /// Returns the weight in pounds (British, US)
        /// </summary>
        /// <returns></returns>
        public double Pounds
        {
            get { return Value / PoundsToKiloGrams; }
        }

        /// <summary>
        /// Creates a new weight, based on combination of stones and pounds
        /// </summary>
        /// <returns></returns>
        public static Weight FromImperial(double stones, double pounds)
        {
            return FromPounds((StonesToPounds * stones) + pounds);
        }

        /// <summary>
        /// Returns the weight in a combination of stones and pounds
        /// </summary>
        /// <returns></returns>
        public void ToImperial(out double stones, out double pounds)
        {
            double totalPounds = Pounds;
            stones = Math.Floor(totalPounds / StonesToPounds);
            pounds = totalPounds % StonesToPounds;
        }
    }
}
