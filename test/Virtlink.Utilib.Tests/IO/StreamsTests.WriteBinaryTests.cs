using System;
using System.IO;
using Xunit;

namespace Virtlink.Utilib.IO
{
    partial class StreamsTests
    {
        /// <summary>
        /// Tests the <see cref="Streams.WriteBinary"/> function.
        /// </summary>
        public sealed class WriteBinaryTests
        {
            [Fact]
            public void ShouldReturnABinaryWriter()
            {
                // Arrange
                var input = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD};
                var stream = new MemoryStream();

                // Act
                var writer = stream.WriteBinary();
                writer.Write(input);

                // Assert
                Assert.Equal(input, GetBytes(stream));

                // Cleanup
                writer.Dispose();
                stream.Dispose();
            }

            [Fact]
            public void ShouldNotCloseStream_WhenClosingTheWriter()
            {
                // Arrange
                var stream = new MemoryStream();
                var writer = stream.WriteBinary();

                // Act
                writer.Dispose();
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
                    sut.WriteBinary();
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }

            private byte[] GetBytes(MemoryStream stream)
            {
                stream.Position = 0;
                return stream.ToArray();
            }
        }
    }
}
