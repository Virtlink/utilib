using System;
using System.IO;
using System.Text;
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
            public void ShouldReturnATextWriter()
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
            public void ShouldNotCloseStream_WhenClosingTheWriter()
            {
                // Arrange
                var stream = new MemoryStream();
                var writer = stream.WriteText();

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
                    sut.WriteText();
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
