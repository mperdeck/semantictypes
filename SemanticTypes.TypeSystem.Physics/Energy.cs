using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes.TypeSystem.Physics
{
    /// <summary>
    /// Encapsulates a unit of energy.
    /// For conversions, see
    /// http://www.convert-me.com/en/
    /// </summary>
    public class Energy : SemanticDoubleType<Energy>
    {
        /// <summary>
        /// Creates a new unit of energy
        /// </summary>
        /// <param name="value">
        /// Energy in KiloJoules
        /// </param>
        public Energy(double value) : base(value) { }

        private const double MegaJoulesToKiloJoules = 1000;

        /// <summary>
        /// Creates a new energy.
        /// This method is nominally a duplicate of the constructor.
        /// However, using this makes it totally clear that you're passing in a value 
        /// in kilojoules.
        /// </summary>
        /// <param name="value">
        /// Energy in meters
        /// </param>
        /// <returns></returns>
        public static Energy FromKiloJoules(double value)
        {
            return new Energy(value);
        }

        /// <summary>
        /// Creates a new distance
        /// </summary>
        /// <param name="value">
        /// Energy in MegaJoules
        /// </param>
        /// <returns></returns>
        public static Energy FromMegaJoules(double value)
        {
            return new Energy(value * MegaJoulesToKiloJoules);
        }

        /// <summary>
        /// Returns the energy in KiloJoules.
        /// </summary>
        /// <returns></returns>
        public double KiloJoules
        {
            get { return Value; }
        }

        /// <summary>
        /// Returns the energy in MegaJoules.
        /// </summary>
        /// <returns></returns>
        public double MegaJoules
        {
            get { return Value / MegaJoulesToKiloJoules; }
        }
    }
}
