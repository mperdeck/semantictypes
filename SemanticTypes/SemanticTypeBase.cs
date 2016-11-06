using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes
{
    public interface ISemanticType
    {
        object GetValue();
    }
    public interface IValue<T>
    {
        T Value { get; }
    }

    /// <summary>
    /// Internal base type of a semantic type. Do not inherit from this directly, it is infrastructure only.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the underlying value. If your semantic type is "EmailAddress" with an underlying value of type string,
    /// then pass "string" here.
    /// </typeparam>
    public abstract class SemanticTypeBase<T> : IEquatable<SemanticTypeBase<T>>, IValue<T>, ISemanticType
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

        protected SemanticTypeBase(Func<T, bool> isValidLambda, T value)
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

            return (Value.Equals(((SemanticTypeBase<T>)obj).Value));
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public bool Equals(SemanticTypeBase<T> other)
        {
            if (other == null) { return false; }
            
            return (Value.Equals(other.Value));
        }

        public static bool operator ==(SemanticTypeBase<T> a, SemanticTypeBase<T> b)
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

        public static bool operator !=(SemanticTypeBase<T> a, SemanticTypeBase<T> b)
        {
            return !(a == b);
        }

        protected static bool EitherNull(SemanticTypeBase<T> a, SemanticTypeBase<T> b)
        {
            if (((object)a == null) || ((object)b == null))
            {
                return true;
            }

            return false;
        }
        public override string ToString()
        {
            return this.Value.ToString();
        }

        public object GetValue()
        {
            return this.Value;
        }
    }


}
