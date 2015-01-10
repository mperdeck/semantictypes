using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes.MetricTypeSystem
{
    /// <summary>
    /// Volume in cubic meters 
    /// </summary>
    public class Volume: PhysicalUnit
    {
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
