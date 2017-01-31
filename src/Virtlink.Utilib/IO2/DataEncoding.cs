using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Virtlink.Utilib.IO;

namespace Virtlink.Utilib.IO2
{
    /// <summary>
    /// Describes how primitive data types are encoded.
    /// </summary>
    public abstract class DataEncoding
    {
        /// <summary>
        /// Gets whether the specified primitive data type is supported by this data encoding.
        /// </summary>
        /// <param name="type">The primitive data type to check.</param>
        /// <returns><see langword="true"/> when the type is supported;
        /// otherwise, <see langword="false"/>.</returns>
        [Pure]
        public virtual bool IsSupportedType(Type type)
        {
            #region Contract
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            #endregion

            return type == typeof(Byte)
                || type == typeof(UInt16)
                || type == typeof(UInt32)
                || type == typeof(UInt64)
                || type == typeof(SByte)
                || type == typeof(Int16)
                || type == typeof(Int32)
                || type == typeof(Int64)
                || type == typeof(Single)
                || type == typeof(Double)
                || type == typeof(Decimal)
                || type == typeof(Boolean);
        }

        /// <summary>
        /// Gets the minimum number of bytes used to encode the specified primitive data type.
        /// </summary>
        /// <param name="type">The primitive data type.</param>
        /// <returns>The minimum number of bytes.</returns>
        [Pure]
        public virtual int GetMinByteCount(Type type)
        {
            #region Contract
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (!IsSupportedType(type))
                throw new NotSupportedException($"The type is not supported: {type}");
            #endregion

            return 1;
        }

        /// <summary>
        /// Gets the maximum number of bytes used to encode the specified primitive data type.
        /// </summary>
        /// <param name="type">The primitive data type.</param>
        /// <returns>The minimum number of bytes.</returns>
        [Pure]
        public abstract int GetMaxByteCount(Type type);

        /// <summary>
        /// Gets the exact number of bytes used to encode the specified value.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The number of bytes.</returns>
        [Pure]
        public abstract int GetByteCount<T>(T value);
        
        /// <summary>
        /// Decodes a value by reading from the specified buffer.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="buffer">The buffer from which to read.</param>
        /// <param name="index">The zero-based index at which to start reading.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <param name="value">The decoded value.</param>
        /// <returns>The number of bytes read from the buffer.</returns>
        [Pure]
        public abstract int Decode<T>(byte[] buffer, int index, int count, out T value);

        /// <summary>
        /// Encodes a value and writes the result to the specified buffer.
        /// </summary>
        /// <typeparam name="T">The type of value.</typeparam>
        /// <param name="buffer">The buffer to which to write.</param>
        /// <param name="index">The zero-based index at which to start writing.</param>
        /// <param name="count">The maximum number of bytes to write.</param>
        /// <param name="value">The value to encode.</param>
        /// <returns>The number of bytes written to the buffer.</returns>
        [Pure]
        public abstract int Encode<T>(byte[] buffer, int index, int count, T value);
    }
}
