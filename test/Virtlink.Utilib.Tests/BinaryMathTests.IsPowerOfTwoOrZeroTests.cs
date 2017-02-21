using Xunit;
using System;

namespace Virtlink.Utilib
{
	partial class BinaryMathTests
	{
		/// <summary>
		/// Unit tests for the <see cref="BinaryMath.IsPowerOfTwoOrZero"/> functions.
		/// </summary>
		public sealed class IsPowerOfTwoOrZeroTests
		{
		    [Theory]
		    [InlineData(Int32.MinValue,  false)]
			[InlineData((int)-1,         false)]
			[InlineData((int)0,          true)]
			[InlineData((int)1,          true)]
			[InlineData((int)2,          true)]
			[InlineData((int)3,          false)]
			[InlineData((int)4,          true)]
			[InlineData((int)15,         false)]
			[InlineData((int)16,         true)]
			[InlineData((int)17,         false)]
			[InlineData((int)0x40000000, true)]
			[InlineData(Int32.MaxValue,  false)]
			public void Int32_ShouldReturnExpectedResult(int input, bool expected)
			{
                // Act
				bool actual = BinaryMath.IsPowerOfTwoOrZero(input);

                // Assert
                Assert.Equal(expected, actual);
			}

		    [Theory]
		    [InlineData(UInt32.MinValue,  true)]
			[InlineData((uint)0,          true)]
			[InlineData((uint)1,          true)]
			[InlineData((uint)2,          true)]
			[InlineData((uint)3,          false)]
			[InlineData((uint)4,          true)]
			[InlineData((uint)15,         false)]
			[InlineData((uint)16,         true)]
			[InlineData((uint)17,         false)]
			[InlineData((uint)0x40000000, true)]
			[InlineData(UInt32.MaxValue,  false)]
			public void UInt32_ShouldReturnExpectedResult(uint input, bool expected)
			{
			    // Act
			    bool actual = BinaryMath.IsPowerOfTwoOrZero(input);

			    // Assert
			    Assert.Equal(expected, actual);
			}

		    [Theory]
		    [InlineData(Int64.MinValue,           false)]
			[InlineData((long)-1,                 false)]
			[InlineData((long)0,                  true)]
			[InlineData((long)1,                  true)]
			[InlineData((long)2,                  true)]
			[InlineData((long)3,                  false)]
			[InlineData((long)4,                  true)]
			[InlineData((long)15,                 false)]
			[InlineData((long)16,                 true)]
			[InlineData((long)17,                 false)]
			[InlineData((long)0x4000000000000000, true)]
			[InlineData(Int64.MaxValue,           false)]
			public void Int64_ShouldReturnExpectedResult(long input, bool expected)
			{
			    // Act
			    bool actual = BinaryMath.IsPowerOfTwoOrZero(input);

			    // Assert
			    Assert.Equal(expected, actual);
			}

            [Theory]
			[InlineData(UInt64.MinValue,           true)]
			[InlineData((ulong)0,                  true)]
			[InlineData((ulong)1,                  true)]
			[InlineData((ulong)2,                  true)]
			[InlineData((ulong)3,                  false)]
			[InlineData((ulong)4,                  true)]
			[InlineData((ulong)15,                 false)]
			[InlineData((ulong)16,                 true)]
			[InlineData((ulong)17,                 false)]
			[InlineData((ulong)0x4000000000000000, true)]
			[InlineData(UInt32.MaxValue,           false)]
			public void UInt64_ShouldReturnExpectedResult(ulong input, bool expected)
			{
			    // Act
			    bool actual = BinaryMath.IsPowerOfTwoOrZero(input);

			    // Assert
			    Assert.Equal(expected, actual);
			}
		}

	}
}
