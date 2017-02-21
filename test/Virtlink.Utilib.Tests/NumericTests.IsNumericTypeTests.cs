using System;
using Xunit;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.IsNumericType"/> function.
        /// </summary>
        public sealed class IsNumericTypeTests
        {
            [Fact]
            public void ShouldThrowArgumentNullException_WhenTypeArgumentIsNull()
            {
                // Act
                var exception = Record.Exception(() =>
                {
                    Numeric.IsNumericType(null);
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }

            [Theory]
            [InlineData(typeof(String))]
            [InlineData(typeof(Object))]
            [InlineData(typeof(DateTime))]
            public void ShouldReturnFalse_WhenTypeArgumentIsNotNumeric(Type type)
            {
                // Act
                bool result = Numeric.IsNumericType(type);

                // Assert
                Assert.False(result);
            }

            [Theory]
            [InlineData(typeof(SByte))]
            [InlineData(typeof(Byte))]
            [InlineData(typeof(Int16))]
            [InlineData(typeof(UInt16))]
            [InlineData(typeof(Int32))]
            [InlineData(typeof(UInt32))]
            [InlineData(typeof(Int64))]
            [InlineData(typeof(UInt64))]
            [InlineData(typeof(Decimal))]
            [InlineData(typeof(Single))]
            [InlineData(typeof(Double))]
            public void ShouldReturnTrue_WhenTypeArgumentIsNumeric(Type type)
            {
                // Act
                bool result = Numeric.IsNumericType(type);

                // Assert
                Assert.True(result);
            }
        }
    }
}
