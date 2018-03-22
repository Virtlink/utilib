using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib.Text
{
    partial class CodePointTests
    {
        /// <summary>
        /// Tests the <see cref="CodePoint"/> addition operator.
        /// </summary>
        public sealed class AdditionTests
        {
            public static IEnumerable<object[]> AdditionObjects => new List<object[]>
            {
                new object[] { default(CodePoint), 1, new CodePoint(1) },
                new object[] { new CodePoint(1234), 5678, new CodePoint(6912) },
                new object[] { new CodePoint(73776), 0, new CodePoint(73776) },
                new object[] { new CodePoint(0x10FFFF), -2, new CodePoint(0x10FFFD) },
            };

            [Theory]
            [MemberData(nameof(AdditionObjects))]
            public void ShouldReturnExpectedValue_WhenAdded(CodePoint codepoint, int offset, CodePoint expected)
            {
                // Act
                var result = codepoint + offset;

                // Assert
                Assert.Equal(expected, result);
            }

            [Fact]
            public void ShouldThrow_WhenAdditionWouldOverflowValidRange()
            {
                // Arrange
                var codepoint = new CodePoint(0x10FFFD);

                // Act
                var exception = Record.Exception(() =>
                {
                    // ReSharper disable once UnusedVariable
                    var result = codepoint + 3;
                });

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }

            [Fact]
            public void ShouldThrow_WhenAdditionWouldUnderflowValidRange()
            {
                // Arrange
                var codepoint = new CodePoint(2);

                // Act
                var exception = Record.Exception(() =>
                {
                    // ReSharper disable once UnusedVariable
                    var result = codepoint + (-3);
                });

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }

            [Fact]
            public void ShouldThrow_WhenAddingToEof()
            {
                // Arrange
                // ReSharper disable once NotAccessedVariable
                var codepoint = CodePoint.Eof;

                // Act
                var exception = Record.Exception(() =>
                {
                    // ReSharper disable once UnusedVariable
                    var result = codepoint + 3;
                });

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }
        }
    }
}
