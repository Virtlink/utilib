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
        /// Tests the <see cref="Streams.ReadBinary"/> function.
        /// </summary>
        public sealed class ReadBinaryTests
        {
            [Fact]
            public void ReturnsABinaryReader()
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
            public void ClosingReaderDoesNotCloseStream()
            {
                // Arrange
                var stream = new MemoryStream();
                var reader = stream.ReadBinary();

                // Act
                reader.Dispose();

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
                    sut.ReadBinary();
                });
            }
        }
    }
}
