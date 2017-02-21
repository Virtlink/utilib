using System;
using Xunit;

namespace Virtlink.Utilib
{
	partial class BinaryMathTests
	{
		/// <summary>
		/// Unit tests for the <see cref="BinaryMath.GetPadding"/> functions.
		/// </summary>
		public sealed class GetPaddingTests
		{
            [Theory]
			[InlineData((int)0,          1, (int)0)]
			[InlineData((int)13,         1, (int)0)]
			[InlineData((int)-7,         1, (int)0)]
			[InlineData((int)4,          1, (int)0)]
			[InlineData((int)13,         4, (int)3)]
			[InlineData((int)16,         4, (int)0)]
			[InlineData((int)-7,         4, (int)3)]
			[InlineData((int)-16,        4, (int)0)]
			[InlineData((int)0,          7, (int)0)]
			[InlineData((int)13,         7, (int)1)]
			[InlineData((int)16,         7, (int)5)]
			[InlineData((int)-7,         7, (int)0)]
			[InlineData((int)-16,        7, (int)2)]
			[InlineData(Int32.MinValue,  1, (int)0)]
			[InlineData(Int32.MinValue,  7, (int)2)]
			[InlineData(Int32.MinValue, 16, (int)0)]
			[InlineData(Int32.MaxValue,  1, (int)0)]
			[InlineData(Int32.MaxValue,  7, (int)6)]
			[InlineData(Int32.MaxValue, 16, (int)1)]
			public void Int32_ShouldReturnExpectedResult(int offset, int boundary, int expected)
            {
                // Act
                var actual = BinaryMath.GetPadding(offset, boundary);

                // Assert
                Assert.Equal(expected, actual);
			}
			
            [Theory]
			[InlineData((uint)0,          1, (uint)0)]
			[InlineData((uint)13,         1, (uint)0)]
			[InlineData((uint)4,          1, (uint)0)]
			[InlineData((uint)13,         4, (uint)3)]
			[InlineData((uint)16,         4, (uint)0)]
			[InlineData((uint)0,          7, (uint)0)]
			[InlineData((uint)13,         7, (uint)1)]
			[InlineData((uint)16,         7, (uint)5)]
			[InlineData(UInt32.MinValue,  1, (uint)0)]
			[InlineData(UInt32.MinValue,  7, (uint)0)]
			[InlineData(UInt32.MinValue, 16, (uint)0)]
			[InlineData(UInt32.MaxValue,  1, (uint)0)]
			[InlineData(UInt32.MaxValue,  7, (uint)4)]
			[InlineData(UInt32.MaxValue, 16, (uint)1)]
			public void OnUInt32(uint offset, int boundary, uint expected)
            {
                // Act
                var actual = BinaryMath.GetPadding(offset, boundary);

                // Assert
                Assert.Equal(expected, actual);
            }
			
            [Theory]
			[InlineData((long)0,         1, (long)0)]
			[InlineData((long)13,        1, (long)0)]
			[InlineData((long)-7,        1, (long)0)]
			[InlineData((long)4,         1, (long)0)]
			[InlineData((long)13,        4, (long)3)]
			[InlineData((long)16,        4, (long)0)]
			[InlineData((long)-7,        4, (long)3)]
			[InlineData((long)-16,       4, (long)0)]
			[InlineData((long)0,         7, (long)0)]
			[InlineData((long)13,        7, (long)1)]
			[InlineData((long)16,        7, (long)5)]
			[InlineData((long)-7,        7, (long)0)]
			[InlineData((long)-16,       7, (long)2)]
			[InlineData(Int64.MinValue,  1, (long)0)]
			[InlineData(Int64.MinValue,  7, (long)1)]
			[InlineData(Int64.MinValue, 16, (long)0)]
			[InlineData(Int64.MaxValue,  1, (long)0)]
			[InlineData(Int64.MaxValue,  7, (long)0)]
			[InlineData(Int64.MaxValue, 16, (long)1)]
			public void OnInt64(long offset, int boundary, long expected)
            {
                // Act
                var actual = BinaryMath.GetPadding(offset, boundary);

                // Assert
                Assert.Equal(expected, actual);
            }
			
            [Theory]
			[InlineData((ulong)0,         1, (ulong)0)]
			[InlineData((ulong)13,        1, (ulong)0)]
			[InlineData((ulong)4,         1, (ulong)0)]
			[InlineData((ulong)13,        4, (ulong)3)]
			[InlineData((ulong)16,        4, (ulong)0)]
			[InlineData((ulong)0,         7, (ulong)0)]
			[InlineData((ulong)13,        7, (ulong)1)]
			[InlineData((ulong)16,        7, (ulong)5)]
			[InlineData(UInt64.MinValue,  1, (ulong)0)]
			[InlineData(UInt64.MinValue,  7, (ulong)0)]
			[InlineData(UInt64.MinValue, 16, (ulong)0)]
			[InlineData(UInt64.MaxValue,  1, (ulong)0)]
			[InlineData(UInt64.MaxValue,  7, (ulong)6)]
			[InlineData(UInt64.MaxValue, 16, (ulong)1)]
			public void OnUInt64(ulong offset, int boundary, ulong expected)
            {
                // Act
                var actual = BinaryMath.GetPadding(offset, boundary);

                // Assert
                Assert.Equal(expected, actual);
            }
		}

	}
}
