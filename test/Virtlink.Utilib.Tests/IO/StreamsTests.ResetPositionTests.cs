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
        /// Tests the <see cref="Streams.ResetPosition"/> function.
        /// </summary>
        public sealed class ResetPositionTests
        {
            [Fact]
            public void ResetsThePositionToZero()
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
            public void ReturnsTheInputStream()
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
        }
    }
}
