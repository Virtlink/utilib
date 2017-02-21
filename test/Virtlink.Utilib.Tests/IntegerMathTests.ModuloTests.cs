using Xunit;
using System;

namespace Virtlink.Utilib
{
	partial class IntegerMathTests
	{
		/// <summary>
        /// Tests the <see cref="IntegerMath.Modulo"/> functions.
        /// </summary>
		public sealed class ModuloTests
		{
            [Theory]
			[InlineData(Int32.MinValue, (int)3,  (int)1)]
			[InlineData((int)-17,       (int)7,  (int)4)]
			[InlineData((int)-16,       (int)4,  (int)0)]
			[InlineData((int)-15,       (int)8,  (int)1)]
			[InlineData((int)-4,        (int)3,  (int)2)]
			[InlineData((int)-3,        (int)3,  (int)0)]
			[InlineData((int)-2,        (int)1,  (int)0)]
			[InlineData((int)-1,        (int)2,  (int)1)]
			[InlineData((int)0,         (int)1,  (int)0)]
			[InlineData((int)1,         (int)2,  (int)1)]
			[InlineData((int)2,         (int)1,  (int)0)]
			[InlineData((int)3,         (int)3,  (int)0)]
			[InlineData((int)4,         (int)3,  (int)1)]
			[InlineData((int)15,        (int)8,  (int)7)]
			[InlineData((int)16,        (int)4,  (int)0)]
			[InlineData((int)17,        (int)7,  (int)3)]
			[InlineData(Int32.MaxValue, (int)3,  (int)1)]
			[InlineData(Int32.MinValue, (int)-3, (int)1)]
			[InlineData((int)-17,       (int)-7, (int)4)]
			[InlineData((int)-16,       (int)-4, (int)0)]
			[InlineData((int)-15,       (int)-8, (int)1)]
			[InlineData((int)-4,        (int)-3, (int)2)]
			[InlineData((int)-3,        (int)-3, (int)0)]
			[InlineData((int)-2,        (int)-1, (int)0)]
			[InlineData((int)-1,        (int)-2, (int)1)]
			[InlineData((int)0,         (int)-1, (int)0)]
			[InlineData((int)1,         (int)-2, (int)1)]
			[InlineData((int)2,         (int)-1, (int)0)]
			[InlineData((int)3,         (int)-3, (int)0)]
			[InlineData((int)4,         (int)-3, (int)1)]
			[InlineData((int)15,        (int)-8, (int)7)]
			[InlineData((int)16,        (int)-4, (int)0)]
			[InlineData((int)17,        (int)-7, (int)3)]
			[InlineData(Int32.MaxValue,      -3, (int)1)]
			public void Int32_ShouldReturnExpectedResult(int dividend, int divisor, int expected)
			{
                // Act
				var actual = IntegerMath.Modulo(dividend, divisor);

                // Assert
                Assert.Equal(expected, actual);
			}
            
		    [Fact]
		    public void Int32_ShouldThrowDivideByZeroException_WhenDivisorIsZero()
		    {
		        // Act
		        var exception = Record.Exception(() =>
		        {
		            IntegerMath.Modulo((int)10, (int)0);
		        });

		        // Assert
		        Assert.IsType<DivideByZeroException>(exception);
		    }

		    [Theory]
		    [InlineData(Int64.MinValue, (long)3,  (long)1)]
			[InlineData((long)-17,      (long)7,  (long)4)]
			[InlineData((long)-16,      (long)4,  (long)0)]
			[InlineData((long)-15,      (long)8,  (long)1)]
			[InlineData((long)-4,       (long)3,  (long)2)]
			[InlineData((long)-3,       (long)3,  (long)0)]
			[InlineData((long)-2,       (long)1,  (long)0)]
			[InlineData((long)-1,       (long)2,  (long)1)]
			[InlineData((long)0,        (long)1,  (long)0)]
			[InlineData((long)1,        (long)2,  (long)1)]
			[InlineData((long)2,        (long)1,  (long)0)]
			[InlineData((long)3,        (long)3,  (long)0)]
			[InlineData((long)4,        (long)3,  (long)1)]
			[InlineData((long)15,       (long)8,  (long)7)]
			[InlineData((long)16,       (long)4,  (long)0)]
			[InlineData((long)17,       (long)7,  (long)3)]
			[InlineData(Int64.MaxValue, (long)3,  (long)1)]
			[InlineData(Int64.MinValue, (long)-3, (long)1)]
			[InlineData((long)-17,      (long)-7, (long)4)]
			[InlineData((long)-16,      (long)-4, (long)0)]
			[InlineData((long)-15,      (long)-8, (long)1)]
			[InlineData((long)-4,       (long)-3, (long)2)]
			[InlineData((long)-3,       (long)-3, (long)0)]
			[InlineData((long)-2,       (long)-1, (long)0)]
			[InlineData((long)-1,       (long)-2, (long)1)]
			[InlineData((long)0,        (long)-1, (long)0)]
			[InlineData((long)1,        (long)-2, (long)1)]
			[InlineData((long)2,        (long)-1, (long)0)]
			[InlineData((long)3,        (long)-3, (long)0)]
			[InlineData((long)4,        (long)-3, (long)1)]
			[InlineData((long)15,       (long)-8, (long)7)]
			[InlineData((long)16,       (long)-4, (long)0)]
			[InlineData((long)17,       (long)-7, (long)3)]
			[InlineData(Int64.MaxValue,       -3, (long)1)]
			public void Int64_ShouldReturnExpectedResult(long dividend, long divisor, long expected)
		    {
		        // Act
		        var actual = IntegerMath.Modulo(dividend, divisor);

		        // Assert
		        Assert.Equal(expected, actual);
		    }

		    [Fact]
		    public void Int64_ShouldThrowDivideByZeroException_WhenDivisorIsZero()
		    {
		        // Act
		        var exception = Record.Exception(() =>
		        {
		            IntegerMath.Modulo((long)10, (long)0);
		        });

		        // Assert
		        Assert.IsType<DivideByZeroException>(exception);
		    }
		}
	}
}
