using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Virtlink.Utilib.IO
{
    partial class DataBufferTests
    {
        /// <summary>
        /// Tests the <see cref="DataBuffer.ToString"/> method.
        /// </summary>
        public sealed class ToStringTests
        {
            [Fact]
            public void ShouldReturnEmptyString_WhenBufferIsEmpty()
            {
                // Arrange
                var buffer = new DataBuffer();

                // Act
                var result = buffer.ToString(Encoding.UTF8);

                // Assert
                Assert.Equal(0, result.Length);
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
                var result = buffer.ToString(Encoding.UTF8);

                // Assert
                Assert.Equal("YZ", result);
            }

            [Fact]
            public void ShouldHonorEncoding_WhenGivenEncoding()
            {
                // Arrange
                var data = Encoding.UTF32.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer();
                buffer.Write(data, 0, data.Length);
                buffer.Advance(24 * 4);

                // Act
                var result = buffer.ToString(Encoding.UTF32);

                // Assert
                Assert.Equal("YZ", result);
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
                var result = buffer.ToString(Encoding.UTF8, 2);

                // Assert
                Assert.Equal("WX", result);
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
                    buffer.ToString(Encoding.UTF8, -2);
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
                    buffer.ToString(Encoding.UTF8, 200);
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }
        }
    }
}
