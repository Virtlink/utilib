using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Virtlink.Utilib.IO
{
	/// <summary>
	/// Represents a 2's complement most-significant byte first data encoding.
	/// </summary>
	public class BigEndianDataEncoding : DataEncoding
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="BigEndianDataEncoding"/> class.
		/// </summary>
		public BigEndianDataEncoding()
			: base()
		{

		}
		#endregion

		#region GetByteCount(Primitive)
		/// <inheritdoc />
		public override int GetByteCount(byte value)
		{
			return sizeof(byte);
		}

		/// <inheritdoc />
		public override int GetByteCount(ushort value)
		{
			return sizeof(ushort);
		}

		/// <inheritdoc />
		public override int GetByteCount(uint value)
		{
			return sizeof(uint);
		}

		/// <inheritdoc />
		public override int GetByteCount(ulong value)
		{
			return sizeof(ulong);
		}

		/// <inheritdoc />
		public override int GetByteCount(decimal value)
		{
			return sizeof(decimal);
		}
		#endregion

		#region GetBytes(Primitive, byte[], int)
		/// <inheritdoc />
		public override int GetBytes(byte value, byte[] buffer, int index)
		{
			if (index + 1 >= buffer.Length)
				throw new BufferCapacityInsufficientException();

			buffer[index++] = value;
			return 1;
		}

		/// <inheritdoc />
		public override int GetBytes(ushort value, byte[] buffer, int index)
		{
			if (index + 2 >= buffer.Length)
				throw new BufferCapacityInsufficientException();

			buffer[index++] = unchecked((byte)(((uint)value >> 0x8) & 0xFF));
			buffer[index++] = unchecked((byte)(((uint)value >> 0x0) & 0xFF));
			return 2;
		}

		/// <inheritdoc />
		public override int GetBytes(uint value, byte[] buffer, int index)
		{
			if (index + 4 >= buffer.Length)
				throw new BufferCapacityInsufficientException();

			buffer[index++] = unchecked((byte)(((uint)value >> 0x18) & 0xFF));
			buffer[index++] = unchecked((byte)(((uint)value >> 0x10) & 0xFF));
			buffer[index++] = unchecked((byte)(((uint)value >> 0x08) & 0xFF));
			buffer[index++] = unchecked((byte)(((uint)value >> 0x00) & 0xFF));
			return 4;
		}

		/// <inheritdoc />
		public override int GetBytes(ulong value, byte[] buffer, int index)
		{
			if (index + 8 >= buffer.Length)
				throw new BufferCapacityInsufficientException();

			buffer[index++] = unchecked((byte)(((ulong)value >> 0x38) & 0xFF));
			buffer[index++] = unchecked((byte)(((ulong)value >> 0x30) & 0xFF));
			buffer[index++] = unchecked((byte)(((ulong)value >> 0x28) & 0xFF));
			buffer[index++] = unchecked((byte)(((ulong)value >> 0x20) & 0xFF));
			buffer[index++] = unchecked((byte)(((ulong)value >> 0x18) & 0xFF));
			buffer[index++] = unchecked((byte)(((ulong)value >> 0x10) & 0xFF));
			buffer[index++] = unchecked((byte)(((ulong)value >> 0x08) & 0xFF));
			buffer[index++] = unchecked((byte)(((ulong)value >> 0x00) & 0xFF));
			return 8;
		}

		/// <inheritdoc />
		public override int GetBytes(decimal value, byte[] buffer, int index)
		{
			if (index + 16 >= buffer.Length)
				throw new BufferCapacityInsufficientException();

			int[] elements = DataEncoding.RawDecimalAsInt(value);
			index += GetBytes(elements[3], buffer, index);
			index += GetBytes(elements[2], buffer, index);
			index += GetBytes(elements[1], buffer, index);
			index += GetBytes(elements[0], buffer, index);
			return 16;
		}
		#endregion
		
		#region ToPrimitive(byte[], int, out int)
		/// <inheritdoc />
		public override byte ToByte(byte[] buffer, int index, out int bytesUsed)
		{
			if (index + 1 >= buffer.Length)
				throw new DataFormatException("Not enough bytes remaining in the buffer.");

			bytesUsed = 1;
			return buffer[index];
		}

		/// <inheritdoc />
		public override ushort ToUInt16(byte[] buffer, int index, out int bytesUsed)
		{
			if (index + 2 >= buffer.Length)
				throw new DataFormatException("Not enough bytes remaining in the buffer.");

			uint value = 0;
			value |= unchecked((uint)buffer[index++] << 0x08);
			value |= unchecked((uint)buffer[index++] << 0x00);
			bytesUsed = 2;
			return unchecked((ushort)value);
		}

		/// <inheritdoc />
		public override uint ToUInt32(byte[] buffer, int index, out int bytesUsed)
		{
			if (index + 4 >= buffer.Length)
				throw new DataFormatException("Not enough bytes remaining in the buffer.");

			uint value = 0;
			value |= unchecked((uint)buffer[index++] << 0x18);
			value |= unchecked((uint)buffer[index++] << 0x10);
			value |= unchecked((uint)buffer[index++] << 0x08);
			value |= unchecked((uint)buffer[index++] << 0x00);
			bytesUsed = 4;
			return value;
		}

		/// <inheritdoc />
		public override ulong ToUInt64(byte[] buffer, int index, out int bytesUsed)
		{
			if (index + 8 >= buffer.Length)
				throw new DataFormatException("Not enough bytes remaining in the buffer.");

			ulong value = 0;
			value |= unchecked((ulong)buffer[index++] << 0x38);
			value |= unchecked((ulong)buffer[index++] << 0x30);
			value |= unchecked((ulong)buffer[index++] << 0x28);
			value |= unchecked((ulong)buffer[index++] << 0x20);
			value |= unchecked((ulong)buffer[index++] << 0x18);
			value |= unchecked((ulong)buffer[index++] << 0x10);
			value |= unchecked((ulong)buffer[index++] << 0x08);
			value |= unchecked((ulong)buffer[index++] << 0x00);
			bytesUsed = 8;
			return value;
		}

		/// <inheritdoc />
		public override decimal ToDecimal(byte[] buffer, int index, out int bytesUsed)
		{
			if (index + 16 >= buffer.Length)
				throw new DataFormatException("Not enough bytes remaining in the buffer.");

			int used;
			int[] arr = new int[4];
			arr[3] = ToInt32(buffer, index, out used);
			index += used;
			arr[2] = ToInt32(buffer, index, out used);
			index += used;
			arr[1] = ToInt32(buffer, index, out used);
			index += used;
			arr[0] = ToInt32(buffer, index, out used);
			index += used;
			bytesUsed = 16;
			return DataEncoding.RawIntAsDecimal(arr);
		}
		#endregion
	}
}
