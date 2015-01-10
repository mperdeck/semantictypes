using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes.MetricTypeSystem
{
    /// <summary>
    /// Distance in meters
    /// </summary>
    public class Distance: PhysicalUnit
    {
        public Distance(double value) : base(value) { }

        public static Area operator *(Distance b, Distance c)
        {
            if ((b == null) || (c == null)) { return null; }
            return new Area(b.Value * c.Value);
        }

    }
}
