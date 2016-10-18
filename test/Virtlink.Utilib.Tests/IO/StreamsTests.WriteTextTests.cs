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
        /// Tests the <see cref="Streams.WriteText"/> function.
        /// </summary>
        public sealed class WriteTextTests
        {
            [Fact]
            public void ReturnsATextWriter()
            {
                // Arrange
                var input = "TEST";
                var stream = new MemoryStream();

                // Act
                var writer = stream.WriteText();
                writer.Write(input);
                writer.Flush();

                // Assert
                Assert.Equal(input, GetString(stream));

                // Cleanup
                writer.Dispose();
                stream.Dispose();
            }

            [Fact]
            public void ClosingWriterDoesNotCloseStream()
            {
                // Arrange
                var stream = new MemoryStream();
                var writer = stream.WriteText();

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
                    sut.WriteText();
                });
            }

            private string GetString(MemoryStream stream)
            {
                stream.Position = 0;
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }
}
