using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib.Text
{
    partial class CodePointTests
    {
        /// <summary>
        /// Tests the <see cref="CodePoint"/> increment operator.
        /// </summary>
        public sealed class IncrementTests
        {
            public static IEnumerable<object[]> IncrementObjects => new List<object[]>
            {
                new object[] { default(CodePoint), new CodePoint(1) },
                new object[] { new CodePoint(1234), new CodePoint(1235) },
                new object[] { new CodePoint(73776), new CodePoint(73777) },
                new object[] { new CodePoint(0x10FFFE), new CodePoint(0x10FFFF) },
            };

            [Theory]
            [MemberData(nameof(IncrementObjects))]
            public void ShouldReturnExpectedValue_WhenIncremented(CodePoint codepoint, CodePoint expected)
            {
                // Act
                // ReSharper disable once RedundantAssignment
                codepoint++;

                // Assert
                Assert.Equal(expected, codepoint);
            }

            [Fact]
            public void ShouldThrow_WhenIncrementingWouldOverflowValidRange()
            {
                // Arrange
                // ReSharper disable once NotAccessedVariable
                var codepoint = new CodePoint(0x10FFFF);

                // Act
                var exception = Record.Exception(() =>
                {
                    codepoint++;
                });

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }

            [Fact]
            public void ShouldThrow_WhenIncrementingEof()
            {
                // Arrange
                // ReSharper disable once NotAccessedVariable
                var codepoint = CodePoint.Eof;

                // Act
                var exception = Record.Exception(() =>
                {
                    codepoint++;
                });

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }
        }
    }
}
