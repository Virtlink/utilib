using System.IO;
using Xunit;

namespace Virtlink.Utilib.IO
{
    partial class TextReadersTests
    {
        /// <summary>
        /// Tests the <see cref="TextReaders.ReadString"/> method.
        /// </summary>
        public sealed class ReadStringTests
        {
            [Fact]
            public void ShouldReadAnEmptyString_WhenGiven0()
            {
                // Arrange
                var reader = new StringReader("abcdef");

                // Act
                var result = reader.ReadString(0);

                // Assert
                Assert.Equal("", result);
            }

            [Fact]
            public void ShouldReadASingleCharacter_WhenGiven1()
            {
                // Arrange
                var reader = new StringReader("abcdef");

                // Act
                var result = reader.ReadString(1);

                // Assert
                Assert.Equal("a", result);
            }

            [Fact]
            public void ShouldReadMostOfTheString_WhenGiven5()
            {
                // Arrange
                var reader = new StringReader("abcdef");

                // Act
                var result = reader.ReadString(5);

                // Assert
                Assert.Equal("abcde", result);
            }

            [Fact]
            public void ShouldReadAllOfTheString_WhenGiven6()
            {
                // Arrange
                var reader = new StringReader("abcdef");

                // Act
                var result = reader.ReadString(6);

                // Assert
                Assert.Equal("abcdef", result);
            }

            [Fact]
            public void ShouldReadJustTheString_WhenGiven10()
            {
                // Arrange
                var reader = new StringReader("abcdef");

                // Act
                var result = reader.ReadString(10);

                // Assert
                Assert.Equal("abcdef", result);
            }
        }
    }
}
