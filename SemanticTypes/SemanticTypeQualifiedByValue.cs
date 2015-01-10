using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes
{
    public interface IHasQualifyingValue<T, Q>
    {
        T Value { get; }
        Q QualifyingValue { get; }
    }

    public class SemanticTypeQualifiedByValue<T, Q, S> : IHasQualifyingValue<T, Q>, IEquatable<S> where S : IHasQualifyingValue<T, Q>
    {
        public T Value { get; private set; }
        public Q QualifyingValue { get; private set; }

        private static Func<T, bool> _isValid = v => true;
        public static Func<T, bool> IsValid 
        { 
            get
            {
                return _isValid;
            }
                
            protected set
            {
                _isValid = value;
            } 
        }

        protected SemanticTypeQualifiedByValue(T value, Q qualifyingValue)
        {
            if (!IsValid(value))
            {
                throw new ArgumentException(string.Format("Trying to set a {0} to {1} which is invalid", typeof(T), value));
            }

            Value = value;
            QualifyingValue = qualifyingValue;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types. 
            if ((obj == null) || (!(obj is S)))
            {
                return false;
            }

            return ((Value.Equals(((S)obj).Value)) && 
                    (QualifyingValue.Equals(((S)obj).QualifyingValue)));
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode() + QualifyingValue.GetHashCode();
        }

        public bool Equals(S other)
        {
            if (other == null) { return false; }
            
            return (Value.Equals(other.Value) && QualifyingValue.Equals(other.QualifyingValue));
        }

        public static bool operator ==(SemanticTypeQualifiedByValue<T, Q, S> a, SemanticTypeQualifiedByValue<T, Q, S> b)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            // Have to cast to object, otherwise you recursively call this == operator.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.Equals(b);
        }

        public static bool operator !=(SemanticTypeQualifiedByValue<T, Q, S> a, SemanticTypeQualifiedByValue<T, Q, S> b)
        {
            return !(a == b);
        }

        /// <summary>
        /// When comparing two items, and the comparison is not == or != but for example >=
        /// then this method returns true if the comparison definitely returns false.
        /// 
        /// This happens if either item is null (even if both are null),
        /// and when they have different qualifying values.
        /// 
        /// This is based on the behaviour of int?
        /// When comparing two int?, if either is null, the result is always false - even if both are null.
        /// Only exception: == comparison when both are null, or != when one is null and the other isn't.
        /// That is:
        /// null == null   // true
        /// null >= null   // false
        ///  
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        protected static bool EitherNullOrDifferentQualifyingValue(SemanticTypeQualifiedByValue<T, Q, S> a, SemanticTypeQualifiedByValue<T, Q, S> b)
        {
            if (((object)a == null) || ((object)b == null))
            {
                return true;
            }

            bool qualifyingValuesDiffer = 
                !a.QualifyingValue.Equals(b.QualifyingValue);

            return qualifyingValuesDiffer;
        }
    }
}
