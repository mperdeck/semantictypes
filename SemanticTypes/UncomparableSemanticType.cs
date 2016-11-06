using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SemanticTypes
{
    /// <summary>
    /// Base type of a semantic type.
    /// 
    /// Inherit from UncomparableSemanticType if your underlying type does not implement IComparable&lt;T>.
    /// If it does, inherit from SemanticType instead.
    /// </summary>
    /// <typeparam name="T">
    /// Type of the underlying value. If your semantic type is "EmailAddress" with an underlying value of type string,
    /// then pass "string" here.
    /// </typeparam>
    public abstract class UncomparableSemanticType<T> : SemanticTypeBase<T>, IEquatable<SemanticTypeBase<T>>
    {
        protected UncomparableSemanticType(Func<T, bool> isValidLambda, T value)
            : base(isValidLambda, value)
        {
            if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
            {
                throw new InvalidOperationException(
                    string.Format(
                        "{0} implements IComparable<T>. Do not use UncomparableSemanticType<T> to create a semantic type" +
                        " with an underlying value of this type, because UncomparableSemanticType<T> does not implement IComparable<T>," +
                        " so your values will no longer be sortable. Instead of UncomparableSemanticType<T>, use SemanticType<T>.",
                        typeof(T)));
            }

            if (typeof(IComparable).IsAssignableFrom(typeof(T)))
            {
                throw new InvalidOperationException(
                    string.Format(
                        "{0} implements IComparable but not IComparable<T>. Classes that only implement IComparable are not supported" +
                        " by this library, because the semantic types it helps you implement only support IComparable<T> but not" +
                        " the non-generic IComparable. Update {0} so it implements IComparable<T> or create a new class that" +
                        " inherits from {0} and that implements IComparable<T>.",
                        typeof(T)));
            }
        }
    }
}
