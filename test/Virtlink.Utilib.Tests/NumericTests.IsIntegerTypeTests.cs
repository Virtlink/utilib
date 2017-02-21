using System;
using Xunit;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.IsIntegerType"/> function.
        /// </summary>
        public sealed class IsIntegerTypeTests
        {
            [Fact]
            public void ShouldThrowArgumentNullException_WhenTypeArgumentIsNull()
            {
                // Act
                var exception = Record.Exception(() =>
                {
                    Numeric.IsIntegerType(null);
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }

            [Theory]
            [InlineData(typeof(String))]
            [InlineData(typeof(Object))]
            [InlineData(typeof(DateTime))]
            [InlineData(typeof(Decimal))]
            [InlineData(typeof(Single))]
            [InlineData(typeof(Double))]
            public void ShouldReturnFalse_WhenTypeArgumentIsNotInteger(Type type)
            {
                // Act
                bool result = Numeric.IsIntegerType(type);

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
            public void ShouldReturnTrue_WhenTypeArgumentIsInteger(Type type)
            {
                // Act
                bool result = Numeric.IsIntegerType(type);

                // Assert
                Assert.True(result);
            }
        }
    }
}
