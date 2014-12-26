using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticTypes
{
    public class SemanticDoubleType : SemanticType<double, SemanticDoubleType>
    {
        public SemanticDoubleType(double value)
            : base(value)
        {
        }

        // -----------------------------------------------------------------
        // Binary operator 

        public static SemanticDoubleType operator +(SemanticDoubleType b, SemanticDoubleType c)
        {
            if (EitherNull(b,c)) { return null; }
            return new SemanticDoubleType(b.Value + c.Value);
        }

        public static SemanticDoubleType operator -(SemanticDoubleType b, SemanticDoubleType c)
        {
            if (EitherNull(b, c)) { return null; }
            return new SemanticDoubleType(b.Value - c.Value);
        }

        public static SemanticDoubleType operator *(double b, SemanticDoubleType c)
        {
            if (c == null) { return null; }
            return new SemanticDoubleType(b * c.Value);
        }

        public static SemanticDoubleType operator *(SemanticDoubleType c, double b)
        {
            if (c == null) { return null; }
            return new SemanticDoubleType(b * c.Value);
        }

        public static SemanticDoubleType operator /(SemanticDoubleType c, double b)
        {
            if (c == null) { return null; }
            return new SemanticDoubleType(c.Value / b);
        }

        // -----------------------------------------------------------------
        // Unary operator 

        public static SemanticDoubleType operator -(SemanticDoubleType c)
        {
            if (c == null) { return null; }
            return new SemanticDoubleType(-1 * c.Value);
        }

        // -----------------------------------------------------------------
        // Comparisons

        public static bool operator <(SemanticDoubleType b, SemanticDoubleType c)
        {
            if (EitherNull(b, c)) { return false; }
            return (b.Value < c.Value);
        }

        public static bool operator <=(SemanticDoubleType b, SemanticDoubleType c)
        {
            if (EitherNull(b, c)) { return false; }
            return (b.Value <= c.Value);
        }

        public static bool operator >(SemanticDoubleType b, SemanticDoubleType c)
        {
            if (EitherNull(b, c)) { return false; }
            return (b.Value > c.Value);
        }

        public static bool operator >=(SemanticDoubleType b, SemanticDoubleType c)
        {
            if (EitherNull(b, c)) { return false; }
            return (b.Value >= c.Value);
        }
    }
}
