using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Virtlink.Utilib.IO
{
    partial class DataBufferTests
    {
        /// <summary>
        /// Tests the <see cref="DataBuffer.Count"/> property.
        /// </summary>
        public sealed class CountTests
        {
            [Fact]
            public void ShouldBeZero_WhenCreatingNewBuffer()
            {
                // Arrange
                var buffer = new DataBuffer();

                // Act
                var count = buffer.Count;

                // Assert
                Assert.Equal(0, count);
            }

            [Fact]
            public void ShouldBeTotalAmount_WhenWritingToBuffer()
            {
                // Arrange
                var buffer = new DataBuffer();

                // Act
                buffer.Write(new byte[2], 0, 2);
                buffer.Write(new byte[5], 0, 5);
                var count = buffer.Count;

                // Assert
                Assert.Equal(7, count);
            }

            [Fact]
            public void ShouldDecrease_WhenAdvancing()
            {
                // Arrange
                var buffer = new DataBuffer();
                buffer.Write(new byte[2], 0, 2);
                buffer.Write(new byte[5], 0, 5);

                // Act
                buffer.Advance(4);
                var count = buffer.Count;

                // Assert
                Assert.Equal(3, count);
            }
        }
    }
}
