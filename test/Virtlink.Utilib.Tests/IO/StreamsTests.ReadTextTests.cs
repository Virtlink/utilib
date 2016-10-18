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
        /// Tests the <see cref="Streams.ReadText"/> function.
        /// </summary>
        public sealed class ReadTextTests
        {
            [Fact]
            public void ReturnsATextReader()
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
            public void ClosingReaderDoesNotCloseStream()
            {
                // Arrange
                var stream = new MemoryStream();
                var reader = stream.ReadText();

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
                    sut.ReadText();
                });
            }
        }
    }
}
