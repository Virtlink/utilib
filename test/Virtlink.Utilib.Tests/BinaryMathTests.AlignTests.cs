using System;
using Xunit;

namespace Virtlink.Utilib
{
	partial class BinaryMathTests
	{
		/// <summary>
		/// Unit tests for the <see cref="BinaryMath.Align"/> functions.
		/// </summary>
		public sealed class AlignTests
		{
            [Theory]
			[InlineData((int)0,          1, (int)0)]
			[InlineData((int)13,         1, (int)13)]
			[InlineData((int)-7,         1, (int)-7)]
			[InlineData((int)4,          1, (int)4)]
			[InlineData((int)13,         4, (int)16)]
			[InlineData((int)16,         4, (int)16)]
			[InlineData((int)-7,         4, (int)-4)]
			[InlineData((int)-16,        4, (int)-16)]
			[InlineData((int)0,          7, (int)0)]
			[InlineData((int)13,         7, (int)14)]
			[InlineData((int)16,         7, (int)21)]
			[InlineData((int)-7,         7, (int)-7)]
			[InlineData((int)-16,        7, (int)-14)]
			[InlineData(Int32.MinValue,  1, Int32.MinValue)]
			[InlineData(Int32.MinValue,  7, Int32.MinValue + 2)]
			[InlineData(Int32.MinValue, 16, Int32.MinValue)]
            [InlineData(Int32.MaxValue,  1, Int32.MaxValue)]
			public void Int32_ShouldReturnExpectedResult(int offset, int boundary, int expected)
			{
                // Act
				var actual = BinaryMath.Align(offset, boundary);

                // Assert
                Assert.Equal(expected, actual);
			}

			[Fact]
			public void Int32_ShouldThrowOverflowException_OnOverflow()
			{
			    // Act
			    var exception = Record.Exception(() =>
				{
					BinaryMath.Align(Int32.MaxValue, 7);
				});

                // Assert
			    Assert.IsType<OverflowException>(exception);
			}

            [Theory]
			[InlineData((uint)0,         1, (uint)0)]
			[InlineData((uint)13,        1, (uint)13)]
			[InlineData((uint)4,         1, (uint)4)]
			[InlineData((uint)13,        4, (uint)16)]
			[InlineData((uint)16,        4, (uint)16)]
			[InlineData((uint)0,         7, (uint)0)]
			[InlineData((uint)13,        7, (uint)14)]
			[InlineData((uint)16,        7, (uint)21)]
			[InlineData(UInt32.MaxValue, 1, UInt32.MaxValue)]
			public void UInt32_ShouldReturnExpectedResult(uint offset, int boundary, uint expected)
			{
			    // Act
			    var actual = BinaryMath.Align(offset, boundary);

			    // Assert
			    Assert.Equal(expected, actual);
			}

		    [Fact]
		    public void UInt32_ShouldThrowOverflowException_OnOverflow()
		    {
		        // Act
		        var exception = Record.Exception(() =>
		        {
		            BinaryMath.Align(UInt32.MaxValue, 7);
		        });

		        // Assert
		        Assert.IsType<OverflowException>(exception);
		    }

		    [Theory]
		    [InlineData((long)0,         1, (long)0)]
			[InlineData((long)13,        1, (long)13)]
			[InlineData((long)-7,        1, (long)-7)]
			[InlineData((long)4,         1, (long)4)]
			[InlineData((long)13,        4, (long)16)]
			[InlineData((long)16,        4, (long)16)]
			[InlineData((long)-7,        4, (long)-4)]
			[InlineData((long)-16,       4, (long)-16)]
			[InlineData((long)0,         7, (long)0)]
			[InlineData((long)13,        7, (long)14)]
			[InlineData((long)16,        7, (long)21)]
			[InlineData((long)-7,        7, (long)-7)]
			[InlineData((long)-16,       7, (long)-14)]
			[InlineData(Int64.MinValue,  1, Int64.MinValue)]
			[InlineData(Int64.MinValue,  7, Int64.MinValue + 1)]
			[InlineData(Int64.MinValue, 16, Int64.MinValue)]
			[InlineData(Int64.MaxValue,  1, Int64.MaxValue)]
			public void Int64_ShouldReturnExpectedResult(long offset, int boundary, long expected)
			{
			    // Act
			    var actual = BinaryMath.Align(offset, boundary);

			    // Assert
			    Assert.Equal(expected, actual);
		    }

		    [Fact]
		    public void Int64_ShouldThrowOverflowException_OnOverflow()
		    {
		        // Act
		        var exception = Record.Exception(() =>
		        {
		            BinaryMath.Align(Int64.MaxValue, 17);
		        });

		        // Assert
		        Assert.IsType<OverflowException>(exception);
		    }

		    [Theory]
		    [InlineData((ulong)0,        1, (ulong)0)]
			[InlineData((ulong)13,       1, (ulong)13)]
			[InlineData((ulong)4,        1, (ulong)4)]
			[InlineData((ulong)13,       4, (ulong)16)]
			[InlineData((ulong)16,       4, (ulong)16)]
			[InlineData((ulong)0,        7, (ulong)0)]
			[InlineData((ulong)13,       7, (ulong)14)]
			[InlineData((ulong)16,       7, (ulong)21)]
			[InlineData(UInt64.MaxValue, 1, UInt64.MaxValue)]
			public void UInt64_ShouldReturnExpectedResult(ulong offset, int boundary, ulong expected)
		    {
		        // Act
		        var actual = BinaryMath.Align(offset, boundary);

		        // Assert
		        Assert.Equal(expected, actual);
		    }

		    [Fact]
		    public void UInt64_ShouldThrowOverflowException_OnOverflow()
		    {
		        // Act
		        var exception = Record.Exception(() =>
		        {
		            BinaryMath.Align(UInt64.MaxValue, 7);
		        });

		        // Assert
		        Assert.IsType<OverflowException>(exception);
		    }
		}
	}
}
