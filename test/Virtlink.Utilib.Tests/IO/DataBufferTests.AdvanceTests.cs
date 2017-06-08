using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Virtlink.Utilib.IO
{
    partial class DataBufferTests
    {
        /// <summary>
        /// Tests the <see cref="DataBuffer.Advance"/> method.
        /// </summary>
        public sealed class AdvanceTests
        {
            [Fact]
            public void ShouldDoNothing_WhenGivenZero()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer(1);
                buffer.Write(data, 0, data.Length);

                // Act
                buffer.Advance(0);

                // Assert
                Assert.Equal(0, buffer.Offset);
                Assert.Equal(26, buffer.Count);
            }

            [Fact]
            public void ShouldAdvanceOffset_WhenGivenNonZeroValue()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer(1);
                buffer.Write(data, 0, data.Length);

                // Act
                buffer.Advance(24);

                // Assert
                Assert.Equal(24, buffer.Offset);
                Assert.Equal(2, buffer.Count);
            }
            
            [Fact]
            public void ShouldThrowException_WhenOffsetIsNegative()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer(1);
                buffer.Write(data, 0, data.Length);

                // Act
                var exception = Record.Exception(() =>
                {
                    buffer.Advance(-2);
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrowException_WhenOffsetIsOutOfBounds()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer(1);
                buffer.Write(data, 0, data.Length);

                // Act
                var exception = Record.Exception(() =>
                {
                    buffer.Advance(200);
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }
        }
    }
}
