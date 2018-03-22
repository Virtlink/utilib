using Xunit;

#pragma warning disable 1574

namespace Virtlink.Utilib.Text
{
    partial class CodePointTests
    {
        /// <summary>
        /// Tests the <see cref="CodePoint.ToString"/> methods.
        /// </summary>
        public sealed class ToStringTests
        {
            [Fact]
            public void ShouldReturnCharacter_WhenGivenNoArguments()
            {
                // Arrange
                var codepoint = new CodePoint('A');

                // Act
                string result = codepoint.ToString();

                // Assert
                Assert.Equal("A", result);
            }

            [Fact]
            public void ShouldReturnCharacter_WhenGivenGFormat()
            {
                // Arrange
                var codepoint = new CodePoint('A');

                // Act
                string result = codepoint.ToString("G");

                // Assert
                Assert.Equal("A", result);
            }

            [Fact]
            public void ShouldReturnCharacter_WhenGivenNullFormat()
            {
                // Arrange
                var codepoint = new CodePoint('A');

                // Act
                string result = codepoint.ToString((string)null);

                // Assert
                Assert.Equal("A", result);
            }

            [Fact]
            public void ShouldReturnFormattedInteger_WhenGivenAnotherFormat()
            {
                // Arrange
                var codepoint = new CodePoint('A');

                // Act
                string result = codepoint.ToString("X4");

                // Assert
                Assert.Equal("0041", result);
            }

            [Fact]
            public void ShouldReturnEof_WhenGivenEof()
            {
                // Arrange
                var codepoint = CodePoint.Eof;

                // Act
                string result = codepoint.ToString();

                // Assert
                Assert.Equal("EOF", result);
            }
        }
    }
}
