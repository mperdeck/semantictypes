using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes
{
    /// <summary>
    /// Base type of a semantic type.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the underlying value. If your semantic type is "EmailAddress" with an underlying value of type string,
    /// then pass "string" here.
    /// </typeparam>
    public abstract class SemanticType<T> : IEquatable<SemanticType<T>>, IComparable, IComparable<SemanticType<T>>
    {
        /// <summary>
        /// The Value property allows you to get the underlying value of a semantic type
        /// (but not to set it).
        /// </summary>
        /// <example>
        /// <![CDATA[
        /// public class EmailAddress : SemanticType<string, EmailAddress>
        /// {
        ///    ...
        /// }
        /// 
        /// var validEmailAddress = new EmailAddress("kjones@megacorp.com");
        /// string emailAddressString = validEmailAddress.Value; // "kjones@megacorp.com"
        /// ]]>
        /// </example>
        public T Value { get; private set; }

        protected SemanticType(Func<T, bool> isValidLambda, T value)
        {
            if ((Object)value == null)
            {
                throw new ArgumentException(string.Format("Trying to use null as the value of a {0}", this.GetType()));
            }

            if ((isValidLambda != null) && !isValidLambda(value))
            {
                throw new ArgumentException(string.Format("Trying to set a {0} to {1} which is invalid", this.GetType(), value));
            }

            Value = value;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types. 
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            return (Value.Equals(((SemanticType<T>)obj).Value));
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(SemanticType<T> other)
        {
            if (other == null) { return false; }
            
            return (Value.Equals(other.Value));
        }

        public static bool operator ==(SemanticType<T> a, SemanticType<T> b)
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

        public static bool operator !=(SemanticType<T> a, SemanticType<T> b)
        {
            return !(a == b);
        }

        protected static bool EitherNull(SemanticType<T> a, SemanticType<T> b)
        {
            if (((object)a == null) || ((object)b == null))
            {
                return true;
            }

            return false;
        }
        int IComparable<SemanticType<T>>.CompareTo(SemanticType<T> other)
        {
            return ((IComparable)this).CompareTo(other);
        }

        int IComparable.CompareTo(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                throw new ArgumentException(String.Format("other must be of type {0}", this.GetType()));
            }
            if (this.Equals(obj))
            {
                return 0;
            }
            else
            {
                SemanticType<T> other = (SemanticType<T>)obj;
                if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
                {
                    return ((IComparable<T>)this.Value).CompareTo(other.Value);
                }
                else if (typeof(IComparable).IsAssignableFrom(typeof(IComparable)))
                {
                    return ((IComparable)this.Value).CompareTo(other.Value);
                }
                else
                {
                    throw new InvalidOperationException(string.Format("Neither IComparable<T> nor IComparable is implemented for {0}", typeof(T)));
                }
            }
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
