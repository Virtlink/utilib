using System;
using System.IO;
using System.Text;
using Xunit;

namespace Virtlink.Utilib.IO
{
    partial class StreamsTests
    {
        /// <summary>
        /// Tests the <see cref="Streams.ReadText"/> function.
        /// </summary>
        public sealed class ReadTextTests
        {
            [Fact]
            public void ShouldReturnATextReader()
            {
                // Arrange
                var input = "TEST";
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));

                // Act
                var reader = stream.ReadText();

                // Assert
                Assert.Equal(input, reader.ReadToEnd());

                // Cleanup
                reader.Dispose();
                stream.Dispose();
            }

            [Fact]
            public void ShouldNotCloseStream_WhenClosingTheReader()
            {
                // Arrange
                var stream = new MemoryStream();
                var reader = stream.ReadText();

                // Act
                reader.Dispose();
                var exception = Record.Exception(() =>
                {
                    long p = stream.Position;
                });

                // Assert
                Assert.Null(exception);

                // Cleanup
                stream.Dispose();
            }

            [Fact]
            public void ShouldThrowArgumentNullException_WhenStreamIsNull()
            {
                // Arrange
                Stream sut = null;

                // Act
                var exception = Record.Exception(() =>
                {
                    sut.ReadText();
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }
        }
    }
}
