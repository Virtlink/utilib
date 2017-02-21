using System;
using Xunit;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.IsFloatingPointType"/> function.
        /// </summary>
        public sealed class IsFloatingPointTypeTests
        {
            [Fact]
            public void ShouldThrowArgumentNullException_WhenTypeArgumentIsNull()
            {
                // Act
                var exception = Record.Exception(() =>
                {
                    Numeric.IsFloatingPointType(null);
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
            [InlineData(typeof(Decimal))]
            public void ShouldReturnFalse_WhenTypeArgumentIsNotFloatingPoint(Type type)
            {
                // Act
                bool result = Numeric.IsFloatingPointType(type);

                // Assert
                Assert.False(result);
            }

            [Theory]
            [InlineData(typeof(Single))]
            [InlineData(typeof(Double))]
            public void ShouldReturnTrue_WhenTypeArgumentIsFloatingPoint(Type type)
            {
                // Act
                bool result = Numeric.IsFloatingPointType(type);

                // Assert
                Assert.True(result);
            }
        }
    }
}
