using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib.Text
{
    partial class CodePointTests
    {
        /// <summary>
        /// Tests the <see cref="CodePoint"/> subtraction operator.
        /// </summary>
        public sealed class SubtractionTests
        {
            public static IEnumerable<object[]> SubtractionObjects => new List<object[]>
            {
                new object[] { new CodePoint(1), 1, default(CodePoint) },
                new object[] { new CodePoint(6912), 5678, new CodePoint(1234) },
                new object[] { new CodePoint(73776), 0, new CodePoint(73776) },
                new object[] { new CodePoint(0x10FFFD), -2, new CodePoint(0x10FFFF) },
            };

            [Theory]
            [MemberData(nameof(SubtractionObjects))]
            public void ShouldReturnExpectedValue_WhenAdded(CodePoint codepoint, int offset, CodePoint expected)
            {
                // Act
                var result = codepoint - offset;

                // Assert
                Assert.Equal(expected, result);
            }

            [Fact]
            public void ShouldThrow_WhenSubtractionWouldUnderflowValidRange()
            {
                // Arrange
                var codepoint = new CodePoint(2);

                // Act
                var exception = Record.Exception(() =>
                {
                    // ReSharper disable once UnusedVariable
                    var result = codepoint - 3;
                });

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }

            [Fact]
            public void ShouldThrow_WhenSubtractionWouldOverflowValidRange()
            {
                // Arrange
                var codepoint = new CodePoint(0x10FFFD);

                // Act
                var exception = Record.Exception(() =>
                {
                    // ReSharper disable once UnusedVariable
                    var result = codepoint - (-3);
                });

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }

            [Fact]
            public void ShouldThrow_WhenSubtractingFromEof()
            {
                // Arrange
                // ReSharper disable once NotAccessedVariable
                var codepoint = CodePoint.Eof;

                // Act
                var exception = Record.Exception(() =>
                {
                    // ReSharper disable once UnusedVariable
                    var result = codepoint - 3;
                });

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }
        }
    }
}
