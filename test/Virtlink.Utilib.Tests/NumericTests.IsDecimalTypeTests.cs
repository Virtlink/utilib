using System;
using Xunit;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.IsDecimalType"/> function.
        /// </summary>
        public sealed class IsDecimalTypeTests
        {
            [Fact]
            public void ShouldThrowArgumentNullException_WhenTypeArgumentIsNull()
            {
                // Act
                var exception = Record.Exception(() =>
                {
                    Numeric.IsDecimalType(null);
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }

            [Theory]
            [InlineData(typeof(String))]
            [InlineData(typeof(Object))]
            [InlineData(typeof(DateTime))]
            [InlineData(typeof(SByte))]
            [InlineData(typeof(Byte))]
            [InlineData(typeof(Int16))]
            [InlineData(typeof(UInt16))]
            [InlineData(typeof(Int32))]
            [InlineData(typeof(UInt32))]
            [InlineData(typeof(Int64))]
            [InlineData(typeof(UInt64))]
            [InlineData(typeof(Single))]
            [InlineData(typeof(Double))]
            public void ShouldReturnFalse_WhenTypeArgumentIsNotDecimal(Type type)
            {
                // Act
                bool result = Numeric.IsDecimalType(type);

                // Assert
                Assert.False(result);
            }

            [Theory]
            [InlineData(typeof(Decimal))]
            public void ShouldReturnTrue_WhenTypeArgumentIsDecimal(Type type)
            {
                // Act
                bool result = Numeric.IsDecimalType(type);

                // Assert
                Assert.True(result);
            }
        }
    }
}
