using Xunit;

namespace Virtlink.Utilib
{
	partial class BinaryMathTests
	{
		/// <summary>
		/// Unit tests for the <see cref="BinaryMath.SetMostSignificantBit"/> functions.
		/// </summary>
		public sealed class SetMostSignificantBitTests
		{
		    [Theory]
		    [InlineData(0,          0)]
			[InlineData(1,          1)]
			[InlineData(2,          2)]
			[InlineData(3,          2)]
			[InlineData(4,          4)]
			[InlineData(15,         8)]
			[InlineData(16,         16)]
			[InlineData(17,         16)]
			[InlineData(0x40000000, 0x40000000)]
			public void Int32_ShouldReturnExpectedResult(int input, int expected)
			{
                // Act
				var actual = BinaryMath.SetMostSignificantBit(input);

                // Assert
                Assert.Equal(expected, actual);
			}

		    [Theory]
		    [InlineData(0,                  0)]
			[InlineData(1,                  1)]
			[InlineData(2,                  2)]
			[InlineData(3,                  2)]
			[InlineData(4,                  4)]
			[InlineData(15,                 8)]
			[InlineData(16,                 16)]
			[InlineData(17,                 16)]
			[InlineData(0x4000000000000000, 0x4000000000000000)]
			public void Int64_ShouldReturnExpectedResult(long input, long expected)
		    {
		        // Act
		        var actual = BinaryMath.SetMostSignificantBit(input);

		        // Assert
		        Assert.Equal(expected, actual);
		    }

		    [Theory]
		    [InlineData((uint)0,          (uint)0)]
			[InlineData((uint)1,          (uint)1)]
			[InlineData((uint)2,          (uint)2)]
			[InlineData((uint)3,          (uint)2)]
			[InlineData((uint)4,          (uint)4)]
			[InlineData((uint)15,         (uint)8)]
			[InlineData((uint)16,         (uint)16)]
			[InlineData((uint)17,         (uint)16)]
			[InlineData((uint)0x80000000, (uint)0x80000000)]
			public void UInt32_ShouldReturnExpectedResult(uint input, uint expected)
		    {
		        // Act
		        var actual = BinaryMath.SetMostSignificantBit(input);

		        // Assert
		        Assert.Equal(expected, actual);
		    }
			
            [Theory]
			[InlineData((ulong)0,                  (ulong)0)]
			[InlineData((ulong)1,                  (ulong)1)]
			[InlineData((ulong)2,                  (ulong)2)]
			[InlineData((ulong)3,                  (ulong)2)]
			[InlineData((ulong)4,                  (ulong)4)]
			[InlineData((ulong)15,                 (ulong)8)]
			[InlineData((ulong)16,                 (ulong)16)]
			[InlineData((ulong)17,                 (ulong)16)]
			[InlineData((ulong)0x8000000000000000, (ulong)0x8000000000000000)]
			public void UInt64_ShouldReturnExpectedResult(ulong input, ulong expected)
            {
                // Act
                var actual = BinaryMath.SetMostSignificantBit(input);

                // Assert
                Assert.Equal(expected, actual);
            }
		}

	}
}
