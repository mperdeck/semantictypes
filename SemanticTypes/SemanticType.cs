using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemanticTypes
{
    /// <summary>
    /// Base type of a comparable semantic type.
    /// 
    /// Inherit from SemanticType if your underlying type does implement IComparable&lt;T>.
    /// If it does not, inherit from UncomparableSemanticType instead.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the underlying value. If your semantic type is "EmailAddress" with an underlying value of type string,
    /// then pass "string" here.
    /// </typeparam>
    public abstract class SemanticType<T> :
        SemanticTypeBase<T>, IEquatable<SemanticTypeBase<T>>, IComparable<SemanticType<T>> 
        where T: IComparable<T>
    {
        protected SemanticType(Func<T, bool> isValidLambda, T value)
            : base(isValidLambda, value)
        {
        }

        public int CompareTo(SemanticType<T> other)
        {
            if ((Object)other == null)
            {
                return 1;
            }

            if (this.Equals(other))
            {
                return 0;
            }

            return (this.Value).CompareTo(other.Value);
        }
    }
}
