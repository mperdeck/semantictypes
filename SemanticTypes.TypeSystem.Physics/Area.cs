using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes.TypeSystem.Physics
{
    /// <summary>
    /// Represents an area
    /// </summary>
    public class Area : SemanticDoubleType<Area>
    {
        /// <summary>
        /// Creates an area
        /// </summary>
        /// <param name="value">
        /// Size in square meters
        /// </param>
        public Area(double value): base(value) {}

        public static Volume operator *(Area b, Distance c)
        {
            if ((b == null) || (c == null)) { return null; }
            return new Volume(b.Value * c.Value);
        }

        public static Volume operator *(Distance b, Area c)
        {
            if ((b == null) || (c == null)) { return null; }
            return new Volume(b.Value * c.Value);
        }

        public static Distance operator /(Area b, Distance c)
        {
            if ((b == null) || (c == null)) { return null; }
            return new Distance(b.Value / c.Value);
        }
    }
}
