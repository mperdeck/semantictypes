using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemanticTypes;

namespace SemanticTypes.MetricTypeSystem
{
    public class PhysicalUnit: SemanticDoubleType
    {
        static PhysicalUnit()
        {
            InvalidMessage = "PhysicalUnit must be 0 or greater.";
            IsValid = v => v >= 0;
        }

        public PhysicalUnit(double value) : base(value) { }
    }
}
