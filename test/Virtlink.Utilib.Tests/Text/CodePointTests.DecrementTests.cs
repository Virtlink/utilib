using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib.Text
{
    partial class CodePointTests
    {
        /// <summary>
        /// Tests the <see cref="CodePoint"/> decrement operator.
        /// </summary>
        public sealed class DecrementTests
        {
            public static IEnumerable<object[]> DecrementObjects => new List<object[]>
            {
                new object[] { new CodePoint(1), default(CodePoint) },
                new object[] { new CodePoint(1235), new CodePoint(1234) },
                new object[] { new CodePoint(73777), new CodePoint(73776) },
                new object[] { new CodePoint(0x10FFFF), new CodePoint(0x10FFFE) },
            };

            [Theory]
            [MemberData(nameof(DecrementObjects))]
            public void ShouldReturnExpectedValue_WhenDecremented(CodePoint codepoint, CodePoint expected)
            {
                // Act
                codepoint--;

                // Assert
                Assert.Equal(expected, codepoint);
            }

            [Fact]
            public void ShouldThrow_WhenDecrementingWouldUnderflowValidRange()
            {
                // Arrange
                // ReSharper disable once NotAccessedVariable
                var codepoint = new CodePoint(0);

                // Act
                var exception = Record.Exception(() =>
                {
                    codepoint--;
                });

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }

            [Fact]
            public void ShouldThrow_WhenDecrementingEof()
            {
                // Arrange
                // ReSharper disable once NotAccessedVariable
                var codepoint = CodePoint.Eof;

                // Act
                var exception = Record.Exception(() =>
                {
                    codepoint--;
                });

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }
        }
    }
}
