using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            public void ReturnsABinaryWriter()
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
            public void ClosingWriterDoesNotCloseStream()
            {
                // Arrange
                var stream = new MemoryStream();
                var writer = stream.WriteBinary();

                // Act
                writer.Dispose();

                // Assert
                long p = stream.Position;       // Should not throw ObjectDisposedException

                // Cleanup
                stream.Dispose();
            }

            [Fact]
            public void ThrowsWhenStreamIsNull()
            {
                // Arrange
                Stream sut = null;

                // Act/Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    sut.WriteBinary();
                });
            }

            private byte[] GetBytes(MemoryStream stream)
            {
                stream.Position = 0;
                return stream.ToArray();
            }
        }
    }
}
