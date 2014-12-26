using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticTypes
{
    public interface IHasValue<T>
    {
        T Value { get; }
    }

    public class SemanticType<T, S> : IHasValue<T>, IEquatable<S> where S : IHasValue<T>
    {
        public T Value { get; private set; }

        public static string InvalidMessage { get; protected set; }
        public static Func<T, bool> IsValid { get; protected set; }

        protected SemanticType(T value)
        {
            if (!IsValid(value))
            {
                throw new ArgumentException(InvalidMessage + " - Value: " + value);
            }

            Value = value;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types. 
            if ((obj == null) || (!(obj is S)))
            {
                return false;
            }

            return (Value.Equals(((S)obj).Value));
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(S other)
        {
            if (other == null) { return false; }
            
            return (Value.Equals(other.Value));
        }

        public static bool operator ==(SemanticType<T, S> a, SemanticType<T, S> b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            // Have to cast to object, otherwise you recursively call this == operator.
            if (EitherNull(a, b))
            {
                return false;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        public static bool operator !=(SemanticType<T, S> a, SemanticType<T, S> b)
        {
            return !(a == b);
        }

        protected static bool EitherNull(SemanticType<T, S> a, SemanticType<T, S> b)
        {
            if (((object)a == null) || ((object)b == null))
            {
                return true;
            }

            return false;
        }
    }
}
