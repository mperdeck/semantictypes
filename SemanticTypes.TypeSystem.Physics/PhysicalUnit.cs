using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SemanticTypes;

namespace SemanticTypes.MetricTypeSystem
{
    public class PhysicalUnit : SemanticDoubleType<PhysicalUnit>
    {
        // Note that physical units can be negative, for convenience sake.
        // For example, the difference between two distances.
        public PhysicalUnit(double value) : base(null, value) { }
    }
}
