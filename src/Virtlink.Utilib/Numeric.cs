using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Virtlink.Utilib
{
    /// <summary>
    /// Methods for working with numbers.
    /// </summary>
    public static class Numeric
    {
        /// <summary>
        /// Compares two boxed numbers, regardless of their actual numeric type and signedness.
        /// </summary>
        /// <param name="x">The left-hand boxed integer to compare.</param>
        /// <param name="y">The right-hand boxed integer to compare.</param>
        /// <returns>A negative value if <paramref name="x"/> is less than <paramref name="y"/>,
        /// a positive value if <paramref name="x"/> is greater than <paramref name="y"/>,
        /// or zero if <paramref name="x"/> is equal to <paramref name="y"/>.</returns>
        [Pure]
        public static int Compare(object x, object y)
        {
            #region Contract
            if (x == null)
                throw new ArgumentNullException(nameof(x));
            if (y == null)
                throw new ArgumentNullException(nameof(y));
            if (!HasNumericType(x))
                throw new ArgumentException("The argument does not have a numeric type.", nameof(x));
            if (!HasNumericType(y))
                throw new ArgumentException("The argument does not have a numeric type.", nameof(y));
            #endregion

            return Convert.ToDecimal(x).CompareTo(Convert.ToDecimal(y));
        }

        /// <summary>
        /// Determines whether the specified type is a primitive integer type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><see langword="true"/> when the type is a integer type;
        /// otherwise, <see langword="false"/>.</returns>
        [Pure]
        public static bool IsIntegerType(this Type type)
        {
            #region Contract
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            #endregion

            return type == typeof(Byte)
                || type == typeof(SByte)
                || type == typeof(UInt16)
                || type == typeof(Int16)
                || type == typeof(UInt32)
                || type == typeof(Int32)
                || type == typeof(UInt64)
                || type == typeof(Int64);
        }

        /// <summary>
        /// Determines whether the specified type is a primitive floating-point type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><see langword="true"/> when the type is a floating-point type;
        /// otherwise, <see langword="false"/>.</returns>
        [Pure]
        public static bool IsFloatingPointType(this Type type)
        {
            #region Contract
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            #endregion

            return type == typeof(Single)
                || type == typeof(Double);
        }

        /// <summary>
        /// Determines whether the specified type is a primitive decimal type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><see langword="true"/> when the type is a decimal type;
        /// otherwise, <see langword="false"/>.</returns>
        [Pure]
        public static bool IsDecimalType(this Type type)
        {
            #region Contract
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            #endregion

            return type == typeof(Decimal)
                || type == typeof(Decimal);
        }

        /// <summary>
        /// Determines whether the specified type is a primitive numeric type.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns><see langword="true"/> when the type is a numeric type;
        /// otherwise, <see langword="false"/>.</returns>
        [Pure]
        public static bool IsNumericType(this Type type)
        {
            #region Contract
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            #endregion

            return IsIntegerType(type)
                || IsFloatingPointType(type)
                || IsDecimalType(type);
        }

        /// <summary>
        /// Determines whether the specified object's type is a primitive integer type.
        /// </summary>
        /// <param name="obj">The object whose type to check.</param>
        /// <returns><see langword="true"/> when the object's type is a integer type;
        /// otherwise, <see langword="false"/>.</returns>
        [Pure]
        public static bool HasIntegerType(object obj)
        {
            return obj != null && IsIntegerType(obj.GetType());
        }

        /// <summary>
        /// Determines whether the specified object's type is a primitive floating-point type.
        /// </summary>
        /// <param name="obj">The object whose type to check.</param>
        /// <returns><see langword="true"/> when the object's type is a floating-point type;
        /// otherwise, <see langword="false"/>.</returns>
        [Pure]
        public static bool HasFloatingPointType(object obj)
        {
            return obj != null && IsFloatingPointType(obj.GetType());
        }

        /// <summary>
        /// Determines whether the specified object's type is a primitive decimal type.
        /// </summary>
        /// <param name="obj">The object whose type to check.</param>
        /// <returns><see langword="true"/> when the object's type is a decimal type;
        /// otherwise, <see langword="false"/>.</returns>
        [Pure]
        public static bool HasDecimalType(object obj)
        {
            return obj != null && IsDecimalType(obj.GetType());
        }

        /// <summary>
        /// Determines whether the specified object's type is a primitive numeric type.
        /// </summary>
        /// <param name="obj">The object whose type to check.</param>
        /// <returns><see langword="true"/> when the object's type is a numeric type;
        /// otherwise, <see langword="false"/>.</returns>
        [Pure]
        public static bool HasNumericType(object obj)
        {
            return obj != null && IsNumericType(obj.GetType());
        }
    }
}
