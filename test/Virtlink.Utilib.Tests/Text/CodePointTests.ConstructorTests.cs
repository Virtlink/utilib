using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Virtlink.Utilib.Text
{
    partial class CodePointTests
    {
        /// <summary>
        /// Tests the <see cref="CodePoint"/> constructors.
        /// </summary>
        public sealed class ConstructorTests
        {
            [Fact]
            public void ShouldReturnInstance_WhenGivenValidValue()
            {
                // Arrange
                int value = 0x10FFFD;

                // Act
                var result = new CodePoint(value);

                // Assert
                Assert.Equal(value, result.Value);
            }

            [Fact]
            public void ShouldThrow_WhenGivenNegativeValue()
            {
                // Act
                var exception = Record.Exception(() =>
                {
                    // ReSharper disable once UnusedVariable
                    var result = new CodePoint(-1);
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrow_WhenGivenValueOutsideValidRange()
            {
                // Act
                var exception = Record.Exception(() =>
                {
                    // ReSharper disable once UnusedVariable
                    var result = new CodePoint(0x110000);
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }
        }
    }
}
