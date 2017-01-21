using System;
using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace Virtlink.Utilib.IO
{
	/// <summary>
	/// Represents a data encoding.
	/// </summary>
	public abstract class DataEncoding
	{
        #region Predefined
        /// <summary>
        /// Gets the little-endian data encoding.
        /// </summary>
        public static LittleEndianDataEncoding LittleEndian { get; } = new LittleEndianDataEncoding();

        /// <summary>
        /// Gets the big-endian data encoding.
        /// </summary>
        public static BigEndianDataEncoding BigEndian { get; } = new BigEndianDataEncoding();
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataEncoding"/> class.
        /// </summary>
        protected DataEncoding()
		{

		}
		#endregion

		#region Integer/Float Reinterpretation
		/// <summary>
		/// Reinterprets the raw bits of the specified 32-bit floating-point value
		/// as a 32-bit integer value.
		/// </summary>
		/// <param name="value">The floating-point value to reinterpret.</param>
		/// <returns>An integer value that contains the exact same bits the floating-point value contained.</returns>
		[Pure]
		public static Int32 RawSingleAsInt(Single value)
		{
			var union = new IntFloat32Union(value);
			return union.Integer;
		}

		/// <summary>
		/// Reinterprets the raw bits of the specified 32-bit integer value
		/// as a 32-bit floating-point value.
		/// </summary>
		/// <param name="value">The integer value to reinterpret.</param>
		/// <returns>A floating-point value that contains the exact same bits the integer value contained.</returns>
		[Pure]
		public static Single RawIntAsSingle(Int32 value)
		{
			var union = new IntFloat32Union(value);
			return union.Float;
		}

		/// <summary>
		/// A struct used to reinterpret 32-bit integers as 32-bit floating-point values,
		/// and vice versa.
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		private struct IntFloat32Union
		{
			[FieldOffset(0)]
			private readonly float @float;
			/// <summary>
			/// Gets the floating-point value.
			/// </summary>
			/// <value>A floating-point value.</value>
			public float Float => this.@float;

		    [FieldOffset(0)]
			private readonly int integer;
			/// <summary>
			/// Gets the integer value.
			/// </summary>
			/// <value>An integer value.</value>
			public int Integer => this.integer;

		    #region Constructors
			/// <summary>
			/// Initializes a new instance of the <see cref="IntFloat32Union"/> class.
			/// </summary>
			/// <param name="value">The floating-point value.</param>
			public IntFloat32Union(float value)
			{
				this.integer = 0;		// Required: all fields must be assigned.
				this.@float = value;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="IntFloat32Union"/> class.
			/// </summary>
			/// <param name="value">The integer value.</param>
			public IntFloat32Union(int value)
			{
				this.@float = 0;		// Required: all fields must be assigned.
				this.integer = value;
			}
			#endregion
		}
		#endregion

		#region Integer/Double Reinterpretation
		/// <summary>
		/// Reinterprets the raw bits of the specified 64-bit floating-point value
		/// as a 64-bit integer value.
		/// </summary>
		/// <param name="value">The floating-point value to reinterpret.</param>
		/// <returns>An integer value that contains the exact same bits the floating-point value contained.</returns>
		[Pure]
		public static Int64 RawDoubleAsInt(Double value)
		{
			var union = new IntFloat64Union(value);
			return union.Integer;
		}

		/// <summary>
		/// Reinterprets the raw bits of the specified 64-bit integer value
		/// as a 64-bit floating-point value.
		/// </summary>
		/// <param name="value">The integer value to reinterpret.</param>
		/// <returns>A floating-point value that contains the exact same bits the integer value contained.</returns>
		[Pure]
		public static Double RawIntAsDouble(Int64 value)
		{
			var union = new IntFloat64Union(value);
			return union.Float;
		}

		/// <summary>
		/// A struct used to reinterpret 64-bit integers as 64-bit floating-point values,
		/// and vice versa.
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		private struct IntFloat64Union
		{
			[FieldOffset(0)]
			private readonly double @float;
			/// <summary>
			/// Gets the floating-point value.
			/// </summary>
			/// <value>A floating-point value.</value>
			public double Float => this.@float;

		    [FieldOffset(0)]
			private readonly long integer;
			/// <summary>
			/// Gets the integer value.
			/// </summary>
			/// <value>An integer value.</value>
			public long Integer => this.integer;

		    #region Constructors
			/// <summary>
			/// Initializes a new instance of the <see cref="IntFloat64Union"/> class.
			/// </summary>
			/// <param name="value">The floating-point value.</param>
			public IntFloat64Union(double value)
			{
				this.integer = 0;		// Required: all fields must be assigned.
				this.@float = value;
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="IntFloat64Union"/> class.
			/// </summary>
			/// <param name="value">The integer value.</param>
			public IntFloat64Union(long value)
			{
				this.@float = 0;		// Required: all fields must be assigned.
				this.integer = value;
			}
			#endregion
		}
		#endregion

		#region Integer/Decimal Reinterpretation
		/// <summary>
		/// Reinterprets the raw bits of the specified 128-bit decimal floating-point value
		/// as four 32-bit integer values.
		/// </summary>
		/// <param name="value">The decimal floating-point value to reinterpret.</param>
		/// <returns>An array of four 32-bit integers that contain the exact same bits the decimal floating-point value contained.</returns>
		[Pure]
		public static Int32[] RawDecimalAsInt(Decimal value)
		{
			return Decimal.GetBits(value);
		}

		/// <summary>
		/// Reinterprets the raw bits of the specified 32-bit integers
		/// as a 128-bit decimal floating-point value.
		/// </summary>
		/// <param name="elements">An array of four 32-bit integers to reinterpret.</param>
		/// <returns>A decimal floating-point value that contains the exact same bits the integer elements contained.</returns>
		[Pure]
		public static Decimal RawIntAsDecimal(Int32[] elements)
		{
			return new Decimal(elements);
		}
		#endregion

		#region GetByteCount(Primitive)
		/// <summary>
		/// Calculates the number of bytes required to encode the specified 8-bit unsigned integer.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The number of bytes.</returns>
		[Pure]
		public abstract int GetByteCount(Byte value);

		/// <summary>
		/// Calculates the number of bytes required to encode the specified 8-bit signed integer.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The number of bytes.</returns>
		[Pure]
		public virtual int GetByteCount(SByte value)
		{
			return GetByteCount(unchecked((byte)value));
		}

		/// <summary>
		/// Calculates the number of bytes required to encode the specified 16-bit unsigned integer.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The number of bytes.</returns>
		[Pure]
		public abstract int GetByteCount(UInt16 value);

		/// <summary>
		/// Calculates the number of bytes required to encode the specified 16-bit signed integer.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The number of bytes.</returns>
		[Pure]
		public virtual int GetByteCount(Int16 value)
		{
			return GetByteCount(unchecked((ushort)value));
		}

		/// <summary>
		/// Calculates the number of bytes required to encode the specified 32-bit unsigned integer.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The number of bytes.</returns>
		[Pure]
		public abstract int GetByteCount(UInt32 value);

		/// <summary>
		/// Calculates the number of bytes required to encode the specified 32-bit signed integer.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The number of bytes.</returns>
		[Pure]
		public virtual int GetByteCount(Int32 value)
		{
			return GetByteCount(unchecked((uint)value));
		}

		/// <summary>
		/// Calculates the number of bytes required to encode the specified 64-bit unsigned integer.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The number of bytes.</returns>
		[Pure]
		public abstract int GetByteCount(UInt64 value);

		/// <summary>
		/// Calculates the number of bytes required to encode the specified 64-bit signed integer.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The number of bytes.</returns>
		[Pure]
		public virtual int GetByteCount(Int64 value)
		{
			return GetByteCount(unchecked((ulong)value));
		}

		/// <summary>
		/// Calculates the number of bytes required to encode the specified 32-bit floating-point value.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The number of bytes.</returns>
		[Pure]
		public virtual int GetByteCount(Single value)
		{
			return GetByteCount(DataEncoding.RawSingleAsInt(value));
		}

		/// <summary>
		/// Calculates the number of bytes required to encode the specified 64-bit floating-point value.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The number of bytes.</returns>
		[Pure]
		public virtual int GetByteCount(Double value)
		{
			return GetByteCount(DataEncoding.RawDoubleAsInt(value));
		}

		/// <summary>
		/// Calculates the number of bytes required to encode the specified 128-bit decimal floating-point value.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The number of bytes.</returns>
		[Pure]
		public virtual int GetByteCount(Decimal value)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Calculates the number of bytes required to encode the specified boolean value.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The number of bytes.</returns>
		[Pure]
		public virtual int GetByteCount(bool value)
		{
			return GetByteCount(value ? (byte)1 : (byte)0);
		}
		#endregion

		#region GetBytes(Primitive)
		/// <summary>
		/// Encodes the specified 8-bit unsigned integer value as an array of bytes.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The array of bytes.</returns>
		[Pure]
		public virtual byte[] GetBytes(Byte value)
		{
			byte[] buffer = new byte[GetByteCount(value)];
			GetBytes(value, buffer, 0);
			return buffer;
		}

		/// <summary>
		/// Encodes the specified 8-bit signed integer value as an array of bytes.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The array of bytes.</returns>
		[Pure]
		public virtual byte[] GetBytes(SByte value)
		{
			byte[] buffer = new byte[GetByteCount(value)];
			GetBytes(value, buffer, 0);
			return buffer;
		}

		/// <summary>
		/// Encodes the specified 8-bit unsigned integer value as an array of bytes.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The array of bytes.</returns>
		[Pure]
		public virtual byte[] GetBytes(UInt16 value)
		{
			byte[] buffer = new byte[GetByteCount(value)];
			GetBytes(value, buffer, 0);
			return buffer;
		}

		/// <summary>
		/// Encodes the specified 16-bit signed integer value as an array of bytes.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The array of bytes.</returns>
		[Pure]
		public virtual byte[] GetBytes(Int16 value)
		{
			byte[] buffer = new byte[GetByteCount(value)];
			GetBytes(value, buffer, 0);
			return buffer;
		}

		/// <summary>
		/// Encodes the specified 32-bit unsigned integer value as an array of bytes.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The array of bytes.</returns>
		[Pure]
		public virtual byte[] GetBytes(UInt32 value)
		{
			byte[] buffer = new byte[GetByteCount(value)];
			GetBytes(value, buffer, 0);
			return buffer;
		}

		/// <summary>
		/// Encodes the specified 32-bit signed integer value as an array of bytes.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The array of bytes.</returns>
		[Pure]
		public virtual byte[] GetBytes(Int32 value)
		{
			byte[] buffer = new byte[GetByteCount(value)];
			GetBytes(value, buffer, 0);
			return buffer;
		}

		/// <summary>
		/// Encodes the specified 64-bit unsigned integer value as an array of bytes.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The array of bytes.</returns>
		[Pure]
		public virtual byte[] GetBytes(UInt64 value)
		{
			byte[] buffer = new byte[GetByteCount(value)];
			GetBytes(value, buffer, 0);
			return buffer;
		}

		/// <summary>
		/// Encodes the specified 64-bit signed integer value as an array of bytes.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The array of bytes.</returns>
		[Pure]
		public virtual byte[] GetBytes(Int64 value)
		{
			byte[] buffer = new byte[GetByteCount(value)];
			GetBytes(value, buffer, 0);
			return buffer;
		}

		/// <summary>
		/// Encodes the specified 32-bit floating-point value as an array of bytes.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The array of bytes.</returns>
		[Pure]
		public virtual byte[] GetBytes(Single value)
		{
			byte[] buffer = new byte[GetByteCount(value)];
			GetBytes(value, buffer, 0);
			return buffer;
		}

		/// <summary>
		/// Encodes the specified 64-bit floating-point value as an array of bytes.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The array of bytes.</returns>
		[Pure]
		public virtual byte[] GetBytes(Double value)
		{
			byte[] buffer = new byte[GetByteCount(value)];
			GetBytes(value, buffer, 0);
			return buffer;
		}

		/// <summary>
		/// Encodes the specified 128-bit decimal floating-point value as an array of bytes.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The array of bytes.</returns>
		[Pure]
		public virtual byte[] GetBytes(Decimal value)
		{
			byte[] buffer = new byte[GetByteCount(value)];
			GetBytes(value, buffer, 0);
			return buffer;
		}

		/// <summary>
		/// Encodes the specified boolean value as an array of bytes.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <returns>The array of bytes.</returns>
		[Pure]
		public virtual byte[] GetBytes(bool value)
		{
			byte[] buffer = new byte[GetByteCount(value)];
			GetBytes(value, buffer, 0);
			return buffer;
		}
		#endregion

		#region GetBytes(Primitive, byte[], int)
		/// <summary>
		/// Encodes the specified 16-bit unsigned integer value as an array of bytes
		/// and copies them at the specified position into the specified array.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <param name="buffer">The buffer into which the bytes are copied.</param>
		/// <param name="index">The zero-based index in <paramref name="buffer"/> at which to start copying.</param>
		/// <returns>The number of bytes copied.</returns>
		/// <exception cref="BufferCapacityInsufficientException">
		/// <paramref name="buffer"/> is not big enough.
		/// </exception>
		public abstract int GetBytes(Byte value, byte[] buffer, int index);

		/// <summary>
		/// Encodes the specified 8-bit signed integer value as an array of bytes
		/// and copies them at the specified position into the specified array.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <param name="buffer">The buffer into which the bytes are copied.</param>
		/// <param name="index">The zero-based index in <paramref name="buffer"/> at which to start copying.</param>
		/// <returns>The number of bytes copied.</returns>
		/// <exception cref="BufferCapacityInsufficientException">
		/// <paramref name="buffer"/> is not big enough.
		/// </exception>
		public virtual int GetBytes(SByte value, byte[] buffer, int index)
		{
			#region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
			#endregion

			return GetBytes(unchecked((byte)value), buffer, index);
		}

		/// <summary>
		/// Encodes the specified 8-bit unsigned integer value as an array of bytes
		/// and copies them at the specified position into the specified array.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <param name="buffer">The buffer into which the bytes are copied.</param>
		/// <param name="index">The zero-based index in <paramref name="buffer"/> at which to start copying.</param>
		/// <returns>The number of bytes copied.</returns>
		/// <exception cref="BufferCapacityInsufficientException">
		/// <paramref name="buffer"/> is not big enough.
		/// </exception>
		public abstract int GetBytes(UInt16 value, byte[] buffer, int index);

		/// <summary>
		/// Encodes the specified 16-bit signed integer value as an array of bytes
		/// and copies them at the specified position into the specified array.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <param name="buffer">The buffer into which the bytes are copied.</param>
		/// <param name="index">The zero-based index in <paramref name="buffer"/> at which to start copying.</param>
		/// <returns>The number of bytes copied.</returns>
		/// <exception cref="BufferCapacityInsufficientException">
		/// <paramref name="buffer"/> is not big enough.
		/// </exception>
		public virtual int GetBytes(Int16 value, byte[] buffer, int index)
        {
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            return GetBytes(unchecked((ushort)value), buffer, index);
		}

		/// <summary>
		/// Encodes the specified 32-bit unsigned integer value as an array of bytes
		/// and copies them at the specified position into the specified array.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <param name="buffer">The buffer into which the bytes are copied.</param>
		/// <param name="index">The zero-based index in <paramref name="buffer"/> at which to start copying.</param>
		/// <returns>The number of bytes copied.</returns>
		/// <exception cref="BufferCapacityInsufficientException">
		/// <paramref name="buffer"/> is not big enough.
		/// </exception>
		public abstract int GetBytes(UInt32 value, byte[] buffer, int index);

		/// <summary>
		/// Encodes the specified 32-bit signed integer value as an array of bytes
		/// and copies them at the specified position into the specified array.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <param name="buffer">The buffer into which the bytes are copied.</param>
		/// <param name="index">The zero-based index in <paramref name="buffer"/> at which to start copying.</param>
		/// <returns>The number of bytes copied.</returns>
		/// <exception cref="BufferCapacityInsufficientException">
		/// <paramref name="buffer"/> is not big enough.
		/// </exception>
		public virtual int GetBytes(Int32 value, byte[] buffer, int index)
        {
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            return GetBytes(unchecked((uint)value), buffer, index);
		}

		/// <summary>
		/// Encodes the specified 64-bit unsigned integer value as an array of bytes
		/// and copies them at the specified position into the specified array.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <param name="buffer">The buffer into which the bytes are copied.</param>
		/// <param name="index">The zero-based index in <paramref name="buffer"/> at which to start copying.</param>
		/// <returns>The number of bytes copied.</returns>
		/// <exception cref="BufferCapacityInsufficientException">
		/// <paramref name="buffer"/> is not big enough.
		/// </exception>
		public abstract int GetBytes(UInt64 value, byte[] buffer, int index);

		/// <summary>
		/// Encodes the specified 64-bit signed integer value as an array of bytes
		/// and copies them at the specified position into the specified array.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <param name="buffer">The buffer into which the bytes are copied.</param>
		/// <param name="index">The zero-based index in <paramref name="buffer"/> at which to start copying.</param>
		/// <returns>The number of bytes copied.</returns>
		/// <exception cref="BufferCapacityInsufficientException">
		/// <paramref name="buffer"/> is not big enough.
		/// </exception>
		public virtual int GetBytes(Int64 value, byte[] buffer, int index)
        {
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            return GetBytes(unchecked((ulong)value), buffer, index);
		}

		/// <summary>
		/// Encodes the specified 32-bit floating-point value as an array of bytes
		/// and copies them at the specified position into the specified array.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <param name="buffer">The buffer into which the bytes are copied.</param>
		/// <param name="index">The zero-based index in <paramref name="buffer"/> at which to start copying.</param>
		/// <returns>The number of bytes copied.</returns>
		/// <exception cref="BufferCapacityInsufficientException">
		/// <paramref name="buffer"/> is not big enough.
		/// </exception>
		public virtual int GetBytes(Single value, byte[] buffer, int index)
        {
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            return GetBytes(DataEncoding.RawSingleAsInt(value), buffer, index);
		}

		/// <summary>
		/// Encodes the specified 64-bit floating-point value as an array of bytes
		/// and copies them at the specified position into the specified array.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <param name="buffer">The buffer into which the bytes are copied.</param>
		/// <param name="index">The zero-based index in <paramref name="buffer"/> at which to start copying.</param>
		/// <returns>The number of bytes copied.</returns>
		/// <exception cref="BufferCapacityInsufficientException">
		/// <paramref name="buffer"/> is not big enough.
		/// </exception>
		public virtual int GetBytes(Double value, byte[] buffer, int index)
        {
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            return GetBytes(DataEncoding.RawDoubleAsInt(value), buffer, index);
		}

		/// <summary>
		/// Encodes the specified 128-bit decimal floating-point value as an array of bytes
		/// and copies them at the specified position into the specified array.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <param name="buffer">The buffer into which the bytes are copied.</param>
		/// <param name="index">The zero-based index in <paramref name="buffer"/> at which to start copying.</param>
		/// <returns>The number of bytes copied.</returns>
		/// <exception cref="BufferCapacityInsufficientException">
		/// <paramref name="buffer"/> is not big enough.
		/// </exception>
		public abstract int GetBytes(Decimal value, byte[] buffer, int index);

		/// <summary>
		/// Encodes the specified boolean value as an array of bytes
		/// and copies them at the specified position into the specified array.
		/// </summary>
		/// <param name="value">The value to encode.</param>
		/// <param name="buffer">The buffer into which the bytes are copied.</param>
		/// <param name="index">The zero-based index in <paramref name="buffer"/> at which to start copying.</param>
		/// <returns>The number of bytes copied.</returns>
		/// <exception cref="BufferCapacityInsufficientException">
		/// <paramref name="buffer"/> is not big enough.
		/// </exception>
		public virtual int GetBytes(bool value, byte[] buffer, int index)
        {
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            return GetBytes(value ? (byte)1 : (byte)0, buffer, index);
		}
		#endregion

		#region ToPrimitive(byte[], int, out int)
		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// an 8-bit unsigned integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <param name="bytesUsed">The number of bytes that were used for this conversion.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public abstract Byte ToByte(byte[] buffer, int index, out int bytesUsed);

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// an 8-bit signed integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <param name="bytesUsed">The number of bytes that were decoded.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public virtual SByte ToSByte(byte[] buffer, int index, out int bytesUsed)
        {
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            return unchecked((sbyte)ToByte(buffer, index, out bytesUsed));
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 16-bit unsigned integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <param name="bytesUsed">The number of bytes that were decoded.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public abstract UInt16 ToUInt16(byte[] buffer, int index, out int bytesUsed);

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 16-bit signed integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <param name="bytesUsed">The number of bytes that were decoded.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public virtual Int16 ToInt16(byte[] buffer, int index, out int bytesUsed)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            return unchecked((short)ToUInt16(buffer, index, out bytesUsed));
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 32-bit unsigned integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <param name="bytesUsed">The number of bytes that were decoded.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public abstract UInt32 ToUInt32(byte[] buffer, int index, out int bytesUsed);

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 32-bit signed integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <param name="bytesUsed">The number of bytes that were decoded.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public virtual Int32 ToInt32(byte[] buffer, int index, out int bytesUsed)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            return unchecked((int)ToUInt32(buffer, index, out bytesUsed));
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 64-bit unsigned integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <param name="bytesUsed">The number of bytes that were decoded.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public abstract UInt64 ToUInt64(byte[] buffer, int index, out int bytesUsed);

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 64-bit signed integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <param name="bytesUsed">The number of bytes that were decoded.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public virtual Int64 ToInt64(byte[] buffer, int index, out int bytesUsed)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            return unchecked((long)ToUInt64(buffer, index, out bytesUsed));
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 32-bit floating-point value.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <param name="bytesUsed">The number of bytes that were decoded.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public virtual Single ToSingle(byte[] buffer, int index, out int bytesUsed)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int value = ToInt32(buffer, index, out bytesUsed);
			return DataEncoding.RawIntAsSingle(value);
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 64-bit floating-point value.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <param name="bytesUsed">The number of bytes that were decoded.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public virtual Double ToDouble(byte[] buffer, int index, out int bytesUsed)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            long value = ToInt64(buffer, index, out bytesUsed);
			return DataEncoding.RawIntAsDouble(value);
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 128-bit decimal floating-point value.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <param name="bytesUsed">The number of bytes that were decoded.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public abstract Decimal ToDecimal(byte[] buffer, int index, out int bytesUsed);

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a boolean value.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <param name="bytesUsed">The number of bytes that were decoded.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public virtual bool ToBoolean(byte[] buffer, int index, out int bytesUsed)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            byte value = ToByte(buffer, index, out bytesUsed);
			return value != 0;
		}
		#endregion

		#region ToPrimitive(byte[], int)
		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// an 8-bit unsigned integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Byte ToByte(byte[] buffer, int index)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int bytesUsed;
			return ToByte(buffer, 0, out bytesUsed);
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// an 8-bit signed integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public SByte ToSByte(byte[] buffer, int index)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int bytesUsed;
			return ToSByte(buffer, 0, out bytesUsed);
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 16-bit unsigned integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public UInt16 ToUInt16(byte[] buffer, int index)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int bytesUsed;
			return ToUInt16(buffer, 0, out bytesUsed);
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 16-bit signed integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Int16 ToInt16(byte[] buffer, int index)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int bytesUsed;
			return ToInt16(buffer, 0, out bytesUsed);
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 32-bit unsigned integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public UInt32 ToUInt32(byte[] buffer, int index)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int bytesUsed;
			return ToUInt32(buffer, 0, out bytesUsed);
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 32-bit signed integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Int32 ToInt32(byte[] buffer, int index)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int bytesUsed;
			return ToInt32(buffer, 0, out bytesUsed);
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 64-bit unsigned integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public UInt64 ToUInt64(byte[] buffer, int index)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int bytesUsed;
			return ToUInt64(buffer, 0, out bytesUsed);
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 64-bit signed integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Int64 ToInt64(byte[] buffer, int index)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int bytesUsed;
			return ToInt64(buffer, 0, out bytesUsed);
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 32-bit floating-point value.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Single ToSingle(byte[] buffer, int index)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int bytesUsed;
			return ToSingle(buffer, 0, out bytesUsed);
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 64-bit floating-point value.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Double ToDouble(byte[] buffer, int index)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int bytesUsed;
			return ToDouble(buffer, 0, out bytesUsed);
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a 128-bit decimal floating-point value.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Decimal ToDecimal(byte[] buffer, int index)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int bytesUsed;
			return ToDecimal(buffer, 0, out bytesUsed);
		}

		/// <summary>
		/// Decodes the bytes starting from the specified position in the specified array to
		/// a boolean value.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <param name="index">The zero-based index at which to start reading.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public bool ToBoolean(byte[] buffer, int index)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (index < 0 || index > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(index));
            #endregion

            int bytesUsed;
			return ToBoolean(buffer, 0, out bytesUsed);
		}
		#endregion

		#region ToPrimitive(byte[])
		/// <summary>
		/// Decodes the bytes in the specified array to
		/// an 8-bit unsigned integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Byte ToByte(byte[] buffer)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            #endregion

            return ToByte(buffer, 0);
		}

		/// <summary>
		/// Decodes the bytes in the specified array to
		/// an 8-bit signed integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public SByte ToSByte(byte[] buffer)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            #endregion

            return ToSByte(buffer, 0);
		}

		/// <summary>
		/// Decodes the bytes in the specified array to
		/// a 16-bit unsigned integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public UInt16 ToUInt16(byte[] buffer)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            #endregion

            return ToUInt16(buffer, 0);
		}

		/// <summary>
		/// Decodes the bytes in the specified array to
		/// a 16-bit signed integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Int16 ToInt16(byte[] buffer)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            #endregion

            return ToInt16(buffer, 0);
		}

		/// <summary>
		/// Decodes the bytes in the specified array to
		/// a 32-bit unsigned integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public UInt32 ToUInt32(byte[] buffer)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            #endregion

            return ToUInt32(buffer, 0);
		}

		/// <summary>
		/// Decodes the bytes starion in the specified array to
		/// a 32-bit signed integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Int32 ToInt32(byte[] buffer)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            #endregion

            return ToInt32(buffer, 0);
		}

		/// <summary>
		/// Decodes the bytes in the specified array to
		/// a 64-bit unsigned integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public UInt64 ToUInt64(byte[] buffer)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            #endregion

            return ToUInt64(buffer, 0);
		}

		/// <summary>
		/// Decodes the bytes in the specified array to
		/// a 64-bit signed integer.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Int64 ToInt64(byte[] buffer)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            #endregion

            return ToInt64(buffer, 0);
		}

		/// <summary>
		/// Decodes the bytes in the specified array to
		/// a 32-bit floating-point value.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Single ToSingle(byte[] buffer)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            #endregion

            return ToSingle(buffer, 0);
		}

		/// <summary>
		/// Decodes the bytes in the specified array to
		/// a 64-bit floating-point value.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Double ToDouble(byte[] buffer)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            #endregion

            return ToDouble(buffer, 0);
		}

		/// <summary>
		/// Decodes the bytes in the specified array to
		/// a 128-bit decimal floating-point value.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public Decimal ToDecimal(byte[] buffer)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            #endregion

            return ToDecimal(buffer, 0);
		}

		/// <summary>
		/// Decodes the bytes in the specified array to
		/// a boolean value.
		/// </summary>
		/// <param name="buffer">The buffer from which to read.</param>
		/// <returns>The decoded value.</returns>
		/// <exception cref="DataFormatException">
		/// The binary format is not correct.
		/// </exception>
		[Pure]
		public bool ToBoolean(byte[] buffer)
		{
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            #endregion

            return ToBoolean(buffer, 0);
		}
		#endregion
	}
}
