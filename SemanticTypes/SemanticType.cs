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

    /// <summary>
    /// Base type of a semantic type.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the underlying value. If your semantic type is "EmailAddress" with an underlying value of type string,
    /// then pass "string" here.
    /// </typeparam>
    /// <typeparam name="S">
    /// The semantic type itself.  If your semantic type is "EmailAddress", then pass "EmailAddress" here.
    /// </typeparam>
    public class SemanticType<T, S> : IHasValue<T>, IEquatable<S> where S : IHasValue<T>
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

        /// <summary>
        /// IsValid is a method. It returns true if the passed in value is valid
        /// for use with this semantic type.
        /// 
        /// By making this a static property, it can be set in the static
        /// constructor of a class that inherits from SemanticType.
        /// Note that by default, it always returns true.
        /// </summary>
        /// <example>
        /// <![CDATA[
        /// public class EmailAddress : SemanticType<string, EmailAddress>
        /// {
        ///    ...
        /// }
        /// 
        /// bool isValidEmailAddress = EmailAddress.IsValid("kjones@megacorp.com"); // true
        /// bool isValidEmailAddress2 = EmailAddress.IsValid("not a valid email address"); // false
        /// ]]>
        /// </example>
        private static Func<T, bool> _isValid = v => true;
        public static Func<T, bool> IsValid
        {
            get { return _isValid; }
            protected set { _isValid = value; }
        }

        protected SemanticType(T value)
        {
            if (!IsValid(value))
            {
                throw new ArgumentException(string.Format("Trying to set a {0} to {1} which is invalid", typeof(T), value));
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
            //if (EitherNull(a, b))  #######################
            if (((object)a == null) || ((object)b == null))
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
