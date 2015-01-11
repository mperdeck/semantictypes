using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes.SemanticTypeExamples
{
    public class NonNullable<T> : SemanticType<T>
    {
        public static implicit operator T(NonNullable<T> t) { return t.Value; }

        // force dev to know that we're going to NonNullable
        public static explicit operator NonNullable<T>(T t) { return new NonNullable<T>(t); }

        public static bool IsValid(T value)
        {
            return (value != null);
        }

        public NonNullable(T value)
            : base(IsValid, value)
        {
        }
    }
}
