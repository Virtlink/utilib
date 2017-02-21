using System;
using System.IO;
using System.Text;
using Xunit;

namespace Virtlink.Utilib.IO
{
    partial class StreamsTests
    {
        /// <summary>
        /// Tests the <see cref="Streams.AsNonClosingStream"/> function.
        /// </summary>
        public sealed class AsNonClosingStreamTests
        {
            [Fact]
            public void ShouldReturnReadableStream()
            {
                // Arrange
                var input = "TEST";
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));

                // Act
                var nonClosingStream = stream.AsNonClosingStream();
                var reader = nonClosingStream.ReadText();
                var result = reader.ReadToEnd();

                // Assert
                Assert.Equal(input, result);

                // Cleanup
                reader.Dispose();
                stream.Dispose();
            }

            [Fact]
            public void ShouldReturnWritableStream()
            {
                // Arrange
                var input = "TEST";
                var stream = new MemoryStream();

                // Act
                var nonClosingStream = stream.AsNonClosingStream();
                var writer = nonClosingStream.WriteText();
                writer.Write(input);
                writer.Flush();

                // Assert
                Assert.Equal(input, GetString(stream));

                // Cleanup
                writer.Dispose();
                stream.Dispose();
            }

            [Fact]
            public void ShouldReturnSeekableStream()
            {
                // Arrange
                var input = "TEST";
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));

                // Act
                var nonClosingStream = stream.AsNonClosingStream();
                nonClosingStream.Seek(2, SeekOrigin.Begin);

                // Assert
                Assert.Equal(2, stream.Position);

                // Cleanup
                stream.Dispose();
            }

            [Fact]
            public void ShouldNotHaveAnUnderlyingStreamClosed()
            {
                // Arrange
                var stream = new MemoryStream();
                var nonClosingStream = stream.AsNonClosingStream();

                // Act
                nonClosingStream.Dispose();
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
            public void ShouldReturnSameStreamWhenStreamIsAlreadyNonClosing()
            {
                // Arrange
                var stream = new MemoryStream().AsNonClosingStream();

                // Act
                var result = stream.AsNonClosingStream();

                // Assert
                Assert.Same(stream, result);
            }

            [Fact]
            public void ShouldThrowArgumentNullException_WhenStreamIsNull()
            {
                // Arrange
                Stream sut = null;

                // Act
                var exception = Record.Exception(() =>
                {
                    sut.AsNonClosingStream();
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }

            private string GetString(MemoryStream stream)
            {
                stream.Position = 0;
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }
}
