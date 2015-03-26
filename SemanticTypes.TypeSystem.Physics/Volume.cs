using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes.TypeSystem.Physics
{
    /// <summary>
    /// Encapsulates volume
    /// </summary>
    public class Volume : SemanticDoubleType<Volume>
    {
        /// <summary>
        /// Creates a volume
        /// </summary>
        /// <param name="value">
        /// Size in cubic meters
        /// </param>
        public Volume(double value) : base(value) { }

        public static Area operator /(Volume b, Distance c)
        {
            if ((b == null) || (c == null)) { return null; }
            return new Area(b.Value / c.Value);
        }

        public static Distance operator /(Volume b, Area c)
        {
            if ((b == null) || (c == null)) { return null; }
            return new Distance(b.Value / c.Value);
        }
    }
}
