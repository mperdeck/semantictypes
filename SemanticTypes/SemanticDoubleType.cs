using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes
{
    /// <summary>
    /// When deriving from this type, pass in the derived type in parameter Q.
    /// If you don't do that, then the static elements inside this class will be 
    /// shared by all object of all classes derived from this base class.
    /// </summary>
    /// <typeparam name="Q"></typeparam>
    public class SemanticDoubleType<Q> : SemanticType<double>
    {
        private static Func<double, bool> _isValidLambda = null;
        private static Type _derivedType = null;

        public SemanticDoubleType(Func<double, bool> isValidLambda, Type derivedType, double value)
            : base(isValidLambda, derivedType, value)
        {
            _isValidLambda = isValidLambda;
            _derivedType = derivedType;
        }

        // -----------------------------------------------------------------
        // Binary operator 

        public static SemanticDoubleType<Q> operator +(SemanticDoubleType<Q> b, SemanticDoubleType<Q> c)
        {
            if (EitherNull(b,c)) { return null; }
            return new SemanticDoubleType<Q>(_isValidLambda, _derivedType, b.Value + c.Value);
        }

        public static SemanticDoubleType<Q> operator -(SemanticDoubleType<Q> b, SemanticDoubleType<Q> c)
        {
            if (EitherNull(b, c)) { return null; }
            return new SemanticDoubleType<Q>(_isValidLambda, _derivedType, b.Value - c.Value);
        }

        public static SemanticDoubleType<Q> operator *(double b, SemanticDoubleType<Q> c)
        {
            if (c == null) { return null; }
            return new SemanticDoubleType<Q>(_isValidLambda, _derivedType, b * c.Value);
        }

        public static SemanticDoubleType<Q> operator *(SemanticDoubleType<Q> c, double b)
        {
            if (c == null) { return null; }
            return new SemanticDoubleType<Q>(_isValidLambda, _derivedType, b * c.Value);
        }

        public static SemanticDoubleType<Q> operator /(SemanticDoubleType<Q> c, double b)
        {
            if (c == null) { return null; }
            return new SemanticDoubleType<Q>(_isValidLambda, _derivedType, c.Value / b);
        }

        // -----------------------------------------------------------------
        // Unary operator 

        public static SemanticDoubleType<Q> operator -(SemanticDoubleType<Q> c)
        {
            if (c == null) { return null; }
            return new SemanticDoubleType<Q>(_isValidLambda, _derivedType, -1 * c.Value);
        }

        // -----------------------------------------------------------------
        // Comparisons

        public static bool operator <(SemanticDoubleType<Q> b, SemanticDoubleType<Q> c)
        {
            if (EitherNull(b, c)) { return false; }
            return (b.Value < c.Value);
        }

        public static bool operator <=(SemanticDoubleType<Q> b, SemanticDoubleType<Q> c)
        {
            if (EitherNull(b, c)) { return false; }
            return (b.Value <= c.Value);
        }

        public static bool operator >(SemanticDoubleType<Q> b, SemanticDoubleType<Q> c)
        {
            if (EitherNull(b, c)) { return false; }
            return (b.Value > c.Value);
        }

        public static bool operator >=(SemanticDoubleType<Q> b, SemanticDoubleType<Q> c)
        {
            if (EitherNull(b, c)) { return false; }
            return (b.Value >= c.Value);
        }
    }
}
