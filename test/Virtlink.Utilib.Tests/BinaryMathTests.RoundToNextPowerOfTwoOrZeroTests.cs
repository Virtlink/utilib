using Xunit;
using System;

namespace Virtlink.Utilib
{
	partial class BinaryMathTests
	{
        /// <summary>
        /// Tests the <see cref="BinaryMath.RoundToNextPowerOfTwoOrZero"/> functions.
        /// </summary>
        public sealed class RoundToNextPowerOfTwoOrZeroTests
		{
            [Theory]
			[InlineData(Int32.MinValue,     Int32.MinValue)]
			[InlineData(Int32.MinValue + 1, Int32.MinValue)]
			[InlineData(-17,                -32)]
			[InlineData(-16,                -16)]
			[InlineData(-15,                -16)]
			[InlineData(-4,                 -4)]
			[InlineData(-3,                 -4)]
			[InlineData(-2,                 -2)]
			[InlineData(-1,                 -1)]
			[InlineData(0,                  0)]
			[InlineData(1,                  1)]
			[InlineData(2,                  2)]
			[InlineData(3,                  4)]
			[InlineData(4,                  4)]
			[InlineData(15,                 16)]
			[InlineData(16,                 16)]
			[InlineData(17,                 32)]
			[InlineData(0x40000000,         0x40000000)]
			public void Int32_ShouldReturnExpectedResult(int input, int expected)
			{
                // Act
				var actual = BinaryMath.RoundToNextPowerOfTwoOrZero(input);

                // Assert
                Assert.Equal(expected, actual);
			}

		    [Fact]
		    public void Int32_ShouldThrowOverflowException_OnOverflow()
		    {
		        // Arrange
		        int input = Int32.MaxValue;

		        // Act
                var exception = Record.Exception(() =>
			    {
			        BinaryMath.RoundToNextPowerOfTwoOrZero(input);
			    });

			    // Assert
			    Assert.IsType<OverflowException>(exception);
			}

		    [Theory]
		    [InlineData(Int64.MinValue,     Int64.MinValue)]
			[InlineData(Int64.MinValue + 1, Int64.MinValue)]
			[InlineData(-17,                -32)]
			[InlineData(-16,                -16)]
			[InlineData(-15,                -16)]
			[InlineData(-4,                 -4)]
			[InlineData(-3,                 -4)]
			[InlineData(-2,                 -2)]
			[InlineData(-1,                 -1)]
			[InlineData(0,                  0)]
			[InlineData(1,                  1)]
			[InlineData(2,                  2)]
			[InlineData(3,                  4)]
			[InlineData(4,                  4)]
			[InlineData(15,                 16)]
			[InlineData(16,                 16)]
			[InlineData(17,                 32)]
			[InlineData(0x4000000000000000, 0x4000000000000000)]
			public void Int64_ShouldReturnExpectedResult(long input, long expected)
		    {
		        // Act
		        var actual = BinaryMath.RoundToNextPowerOfTwoOrZero(input);

		        // Assert
		        Assert.Equal(expected, actual);
		    }

		    [Fact]
		    public void Int64_ShouldThrowOverflowException_OnOverflow()
			{
			    // Arrange
                long input = Int64.MaxValue;

			    // Act
			    var exception = Record.Exception(() =>
			    {
			        BinaryMath.RoundToNextPowerOfTwoOrZero(input);
			    });

			    // Assert
			    Assert.IsType<OverflowException>(exception);
			}

            [Theory]
		    [InlineData((uint)0,          (uint)0)]
			[InlineData((uint)1,          (uint)1)]
			[InlineData((uint)2,          (uint)2)]
			[InlineData((uint)3,          (uint)4)]
			[InlineData((uint)4,          (uint)4)]
			[InlineData((uint)15,         (uint)16)]
			[InlineData((uint)16,         (uint)16)]
			[InlineData((uint)17,         (uint)32)]
			[InlineData((uint)0x80000000, (uint)0x80000000)]
			public void UInt32_ShouldReturnExpectedResult(uint input, uint expected)
		    {
		        // Act
		        var actual = BinaryMath.RoundToNextPowerOfTwoOrZero(input);

		        // Assert
		        Assert.Equal(expected, actual);
		    }

		    [Fact]
		    public void UInt32_ShouldThrowOverflowException_OnOverflow()
			{
				// Arrange
				uint input = UInt32.MaxValue;

			    // Act
			    var exception = Record.Exception(() =>
			    {
			        BinaryMath.RoundToNextPowerOfTwoOrZero(input);
			    });

			    // Assert
			    Assert.IsType<OverflowException>(exception);
			}

            [Theory]
		    [InlineData((ulong)0,                  (ulong)0)]
			[InlineData((ulong)1,                  (ulong)1)]
			[InlineData((ulong)2,                  (ulong)2)]
			[InlineData((ulong)3,                  (ulong)4)]
			[InlineData((ulong)4,                  (ulong)4)]
			[InlineData((ulong)15,                 (ulong)16)]
			[InlineData((ulong)16,                 (ulong)16)]
			[InlineData((ulong)17,                 (ulong)32)]
			[InlineData((ulong)0x8000000000000000, (ulong)0x8000000000000000)]
			public void UInt64_ShouldReturnExpectedResult(ulong input, ulong expected)
		    {
		        // Act
		        var actual = BinaryMath.RoundToNextPowerOfTwoOrZero(input);

		        // Assert
		        Assert.Equal(expected, actual);
		    }

			[Fact]
			public void UInt64_ShouldThrowOverflowException_OnOverflow()
			{
				// Arrange
				ulong input = UInt64.MaxValue;

			    // Act
			    var exception = Record.Exception(() =>
			    {
			        BinaryMath.RoundToNextPowerOfTwoOrZero(input);
			    });

			    // Assert
			    Assert.IsType<OverflowException>(exception);
			}
        }

	}
}
