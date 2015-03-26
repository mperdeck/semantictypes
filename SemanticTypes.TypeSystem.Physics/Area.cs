using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes.MetricTypeSystem
{
    /// <summary>
    /// Area in square meters 
    /// </summary>
    public class Area: PhysicalUnit<Area>
    {
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
