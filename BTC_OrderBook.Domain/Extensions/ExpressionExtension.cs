using System.Linq.Expressions;
using System.Reflection;

namespace BTC_OrderBook.Domain.Extensions
{
    /// <summary>
    /// Extentions from expression
    /// </summary>
    public static class ExpressionExtension
    {
        /// <summary>
        /// Return type for <see cref="Nullable"/> value.
        /// If type is not <see cref="Nullable"/>, return type.
        /// </summary>
        /// <param name="type"></param>
        public static Type GetNullableUnderlyingType(this Type type)
        {
            return Nullable.GetUnderlyingType(type) ?? type;
        }
    }
}