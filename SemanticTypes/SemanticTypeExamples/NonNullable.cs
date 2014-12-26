using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticTypes.SemanticTypeExamples
{
    public class NonNullable<T> : SemanticType<T, NonNullable<T>>
    {
        public static implicit operator T(NonNullable<T> t) { return t.Value; }

        // force dev to know that we're going to NonNullable
        public static explicit operator NonNullable<T>(T t) { return new NonNullable<T>(t); }

        static NonNullable()
        {
            InvalidMessage = "Value cannot be null.";
            IsValid = v => v != null;
        }

        public NonNullable(T value)
            : base(value)
        {
        }
    }
}
