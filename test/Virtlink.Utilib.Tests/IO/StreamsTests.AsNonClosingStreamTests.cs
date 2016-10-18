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
        /// Tests the <see cref="Streams.AsNonClosingStream"/> function.
        /// </summary>
        public sealed class AsNonClosingStreamTests
        {
            [Fact]
            public void ReturnedStreamAllowsReading()
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
            public void ReturnedStreamAllowsWriting()
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
            public void ReturnedStreamAllowsSeeking()
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
            public void UnderlyingStreamIsNotClosed()
            {
                // Arrange
                var stream = new MemoryStream();
                var nonClosingStream = stream.AsNonClosingStream();

                // Act
                nonClosingStream.Dispose();

                // Assert
                long p = stream.Position;       // Should not throw ObjectDisposedException

                // Cleanup
                stream.Dispose();
            }

            [Fact]
            public void ReturnsSameStreamWhenStreamIsAlreadyNonClosing()
            {
                // Arrange
                var stream = new MemoryStream().AsNonClosingStream();

                // Act
                var result = stream.AsNonClosingStream();

                // Assert
                Assert.Same(stream, result);
            }

            [Fact]
            public void ThrowsWhenStreamIsNull()
            {
                // Arrange
                Stream sut = null;

                // Act/Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    sut.AsNonClosingStream();
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
