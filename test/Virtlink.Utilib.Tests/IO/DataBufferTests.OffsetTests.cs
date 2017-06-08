using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Virtlink.Utilib.IO
{
    partial class DataBufferTests
    {
        /// <summary>
        /// Tests the <see cref="DataBuffer.Offset"/> property.
        /// </summary>
        public sealed class OffsetTests
        {
            [Fact]
            public void ShouldBeZero_WhenCreatingNewBuffer()
            {
                // Arrange
                var buffer = new DataBuffer();

                // Act
                var offset = buffer.Offset;

                // Assert
                Assert.Equal(0, offset);
            }

            [Fact]
            public void ShouldBeAdvancedAmount_WhenAdvancingBuffer()
            {
                // Arrange
                var buffer = new DataBuffer();
                buffer.Write(new byte[16], 0, 16);

                // Act
                buffer.Advance(2);
                buffer.Advance(5);
                var offset = buffer.Offset;

                // Assert
                Assert.Equal(7, offset);
            }
        }
    }
}
