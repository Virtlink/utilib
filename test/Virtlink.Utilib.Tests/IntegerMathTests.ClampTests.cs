using System;
using Xunit;

namespace Virtlink.Utilib
{
	partial class IntegerMathTests
	{
		/// <summary>
		/// Unit tests for the <see cref="IntegerMath.Clamp"/> functions.
		/// </summary>
		public sealed class ClampTests
		{
            [Theory]
			[InlineData(Int32.MinValue, Int32.MinValue, Int32.MaxValue, Int32.MinValue)]
			[InlineData((int)-20,       (int)-30,       (int)10,        (int)-20)]
			[InlineData((int)-20,       (int)0,         (int)0,         (int)0)]
			[InlineData((int)0,         (int)0,         (int)0,         (int)0)]
			[InlineData((int)20,        (int)0,         (int)0,         (int)0)]
			[InlineData((int)20,        (int)-30,       (int)10,        (int)10)]
			[InlineData(Int32.MaxValue, Int32.MinValue, Int32.MaxValue, Int32.MaxValue)]
			public void Int32_ShouldReturnExpectedResul(int value, int lowerBound, int upperBound, int expected)
			{
                // Act
				var actual = IntegerMath.Clamp(value, lowerBound, upperBound);

                // Assert
                Assert.Equal(expected, actual);
			}
            
		    [Fact]
		    public void Int32_ShouldThrowArgumentOutOfRangeException_WhenLowerBoundIsGreaterThanUpperBound()
		    {
		        // Act
		        var exception = Record.Exception(() =>
		        {
		            IntegerMath.Clamp((int)20, (int)20, (int)0);
		        });

		        // Assert
		        Assert.IsType<ArgumentOutOfRangeException>(exception);
		    }

		    [Theory]
		    [InlineData(Int64.MinValue, Int64.MinValue, Int64.MaxValue, Int64.MinValue)]
			[InlineData((long)-20,      (long)-30,      (long)10,       (long)-20)]
			[InlineData((long)-20,      (long)0,        (long)0,        (long)0)]
			[InlineData((long)0,        (long)0,        (long)0,        (long)0)]
			[InlineData((long)20,       (long)0,        (long)0,        (long)0)]
			[InlineData((long)20,       (long)-30,      (long)10,       (long)10)]
			[InlineData(Int64.MaxValue, Int64.MinValue, Int64.MaxValue, Int64.MaxValue)]
			public void Int64_ShouldReturnExpectedResul(long value, long lowerBound, long upperBound, long expected)
		    {
		        // Act
		        var actual = IntegerMath.Clamp(value, lowerBound, upperBound);

		        // Assert
		        Assert.Equal(expected, actual);
		    }

		    [Fact]
		    public void Int64_ShouldThrowArgumentOutOfRangeException_WhenLowerBoundIsGreaterThanUpperBound()
		    {
		        // Act
		        var exception = Record.Exception(() =>
		        {
		            IntegerMath.Clamp((long)20, (long)20, (long)0);
		        });

		        // Assert
		        Assert.IsType<ArgumentOutOfRangeException>(exception);
		    }

		    [Theory]
		    [InlineData((uint)0,         (uint)0,         (uint)0,         (uint)0)]
			[InlineData((uint)20,        (uint)0,         (uint)0,         (uint)0)]
			[InlineData((uint)20,        (uint)0,         (uint)10,        (uint)10)]
			[InlineData(UInt32.MaxValue, UInt32.MinValue, UInt32.MaxValue, UInt32.MaxValue)]
			public void UInt32_ShouldReturnExpectedResul(uint value, uint lowerBound, uint upperBound, uint expected)
		    {
		        // Act
		        var actual = IntegerMath.Clamp(value, lowerBound, upperBound);

		        // Assert
		        Assert.Equal(expected, actual);
		    }

		    [Fact]
		    public void UInt32_ShouldThrowArgumentOutOfRangeException_WhenLowerBoundIsGreaterThanUpperBound()
		    {
		        // Act
		        var exception = Record.Exception(() =>
		        {
		            IntegerMath.Clamp((uint)20, (uint)20, (uint)0);
		        });

		        // Assert
		        Assert.IsType<ArgumentOutOfRangeException>(exception);
		    }

		    [Theory]
		    [InlineData((ulong)0,        (ulong)0,        (ulong)0,        (ulong)0)]
			[InlineData((ulong)20,       (ulong)0,        (ulong)0,        (ulong)0)]
			[InlineData((ulong)20,       (ulong)0,        (ulong)10,       (ulong)10)]
			[InlineData(UInt64.MaxValue, UInt64.MinValue, UInt64.MaxValue, UInt64.MaxValue)]
			public void UInt64_ShouldReturnExpectedResul(ulong value, ulong lowerBound, ulong upperBound, ulong expected)
		    {
		        // Act
		        var actual = IntegerMath.Clamp(value, lowerBound, upperBound);

		        // Assert
		        Assert.Equal(expected, actual);
		    }

		    [Fact]
		    public void UInt64_ShouldThrowArgumentOutOfRangeException_WhenLowerBoundIsGreaterThanUpperBound()
		    {
		        // Act
		        var exception = Record.Exception(() =>
		        {
		            IntegerMath.Clamp((ulong)20, (ulong)20, (ulong)0);
		        });

		        // Assert
		        Assert.IsType<ArgumentOutOfRangeException>(exception);
		    }
		}
	}
}
