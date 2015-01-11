using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SemanticTypes;

namespace SemanticTypes.MetricTypeSystem
{
    public class PhysicalUnit : SemanticDoubleType<PhysicalUnit>
    {
        public static bool IsValid(double value)
        {
            return (value >= 0);
        }

        public PhysicalUnit(double value) : base(IsValid, value) { }
    }
}
