using System;
using System.IO;
using Xunit;

namespace Virtlink.Utilib.IO
{
    partial class StreamsTests
    {
        /// <summary>
        /// Tests the <see cref="Streams.ResetPosition"/> function.
        /// </summary>
        public sealed class ResetPositionTests
        {
            [Fact]
            public void ShouldResetThePositionToZero()
            {
                // Arrange
                var input = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD};
                var stream = new MemoryStream();
                stream.Write(input, 0, input.Length);

                // Act
                long oldPosition = stream.Position;
                stream.ResetPosition();
                long newPosition = stream.Position;

                // Assert
                Assert.Equal(4, oldPosition);
                Assert.Equal(0, newPosition);

                // Cleanup
                stream.Dispose();
            }

            [Fact]
            public void ShouldReturnTheInputStream()
            {
                // Arrange
                var stream = new MemoryStream();

                // Act
                var result = stream.ResetPosition();

                // Assert
                Assert.Same(stream, result);

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
                    sut.ResetPosition();
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }
        }
    }
}
