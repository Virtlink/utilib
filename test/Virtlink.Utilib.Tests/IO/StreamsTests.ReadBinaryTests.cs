using System;
using System.IO;
using Xunit;

namespace Virtlink.Utilib.IO
{
    partial class StreamsTests
    {
        /// <summary>
        /// Tests the <see cref="Streams.ReadBinary"/> function.
        /// </summary>
        public sealed class ReadBinaryTests
        {
            [Fact]
            public void ShouldReturnABinaryReader()
            {
                // Arrange
                var input = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD};
                var stream = new MemoryStream(input);

                // Act
                var reader = stream.ReadBinary();

                // Assert
                Assert.Equal(input, reader.ReadBytes(input.Length));

                // Cleanup
                reader.Dispose();
                stream.Dispose();
            }

            [Fact]
            public void ShouldNotCloseStream_WhenClosingTheReader()
            {
                // Arrange
                var stream = new MemoryStream();
                var reader = stream.ReadBinary();

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
                    sut.ReadBinary();
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }
        }
    }
}
