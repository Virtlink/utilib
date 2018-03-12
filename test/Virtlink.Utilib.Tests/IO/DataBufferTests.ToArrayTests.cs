using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Virtlink.Utilib.IO
{
    partial class DataBufferTests
    {
        /// <summary>
        /// Tests the <see cref="DataBuffer.ToArray"/> method.
        /// </summary>
        public sealed class ToArrayTests
        {
            [Fact]
            public void ShouldReturnEmptyArray_WhenBufferIsEmpty()
            {
                // Arrange
                var buffer = new DataBuffer();

                // Act
                var result = buffer.ToArray();

                // Assert
                Assert.Empty(result);
            }

            [Fact]
            public void ShouldReturnSubsetOfData_WhenBufferHasBeenWrittenToAndAdvanced()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer();
                buffer.Write(data, 0, data.Length);
                buffer.Advance(24);

                // Act
                var result = buffer.ToArray();

                // Assert
                Assert.Equal(Encoding.UTF8.GetBytes("YZ"), result);
            }

            [Fact]
            public void ShouldReturnSubsetOfData_WhenGivenCount()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer();
                buffer.Write(data, 0, data.Length);
                buffer.Advance(22);

                // Act
                var result = buffer.ToArray(2);

                // Assert
                Assert.Equal(Encoding.UTF8.GetBytes("WX"), result);
            }

            [Fact]
            public void ShouldThrowException_WhenCountIsNegative()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer();
                buffer.Write(data, 0, data.Length);

                // Act
                var exception = Record.Exception(() =>
                {
                    buffer.ToArray(-2);
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrowException_WhenCountIsOutOfRange()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer();
                buffer.Write(data, 0, data.Length);

                // Act
                var exception = Record.Exception(() =>
                {
                    buffer.ToArray(200);
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }
        }
    }
}
