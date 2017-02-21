using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.HasNumericType"/> function.
        /// </summary>
        public sealed class HasNumericTypeTests
        {
            [Fact]
            public void ShouldReturnFalse_WhenArgumentIsNull()
            {
                // Act
                bool result = Numeric.HasNumericType(null);

                // Assert
                Assert.False(result);
            }

            public static IEnumerable<object[]> NegativeTestCases { get; } = new[]
            {
                new object[] { String.Empty },
                new object[] { new object() },
                new object[] { new DateTime(2017, 1, 27, 11, 32, 20) },
            };
            [Theory]
            [MemberData(nameof(NegativeTestCases))]
            public void ShouldReturnFalse_WhenArgumentIsNotNumeric(object obj)
            {
                // Act
                bool result = Numeric.HasNumericType(obj);

                // Assert
                Assert.False(result);
            }

            public static IEnumerable<object[]> PositiveTestCases { get; } = new[]
            {
                new object[] { SByte.MinValue },
                new object[] { Byte.MaxValue },
                new object[] { Int16.MinValue },
                new object[] { UInt16.MaxValue },
                new object[] { Int32.MinValue },
                new object[] { UInt32.MaxValue },
                new object[] { Int64.MinValue },
                new object[] { UInt64.MaxValue },
                new object[] { Decimal.MaxValue },
                new object[] { Single.MaxValue },
                new object[] { Double.MaxValue },
            };
            [Theory]
            [MemberData(nameof(PositiveTestCases))]
            public void ShouldReturnTrue_WhenArgumentIsNumeric(object obj)
            {
                // Act
                bool result = Numeric.HasNumericType(obj);

                // Assert
                Assert.True(result);
            }
        }
    }
}
