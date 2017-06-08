using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Virtlink.Utilib.IO
{
    partial class DataBufferTests
    {
        /// <summary>
        /// Tests the <see cref="DataBuffer.Write"/> method.
        /// </summary>
        public sealed class WriteTests
        {
            [Fact]
            public void ShouldWriteNothing_WhenWritingZeroBytes()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer(32);

                // Act
                buffer.Write(data, 10, 0);

                // Assert
                Assert.Equal(0, buffer.Count);
            }

            [Fact]
            public void ShouldWriteSpecifiedRangeOfBytes_WhenSpecifyingOffsetAndCount()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer(32);

                // Act
                buffer.Write(data, 2, 2);

                // Assert
                Assert.Equal(Encoding.UTF8.GetBytes("CD"), buffer.ToArray());
            }

            [Fact]
            public void ShouldResizeArray_WhenWritingMoreThanCapacity()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer(1);
                int capacity = buffer.BufferArray.Length;
                // Only two bytes of capacity remaining before the buffer needs to be resized.
                buffer.Write(new byte[capacity - 2], 0, capacity - 2);

                // Act
                buffer.Write(data, 0, data.Length);

                // Assert
                Assert.True(buffer.BufferArray.Length > capacity);
            }

            [Fact]
            public void ShouldMoveData_WhenWritingMoreThanCapacityButOffsetIsNonZero()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer(32);
                int capacity = buffer.BufferArray.Length;
                // Only two bytes of capacity remaining.
                buffer.Write(new byte[capacity - 2], 0, capacity - 2);
                // Only two bytes of data remaining.
                buffer.Advance(capacity - 4);

                // Act
                buffer.Write(data, 0, data.Length);

                // Assert
                Assert.Equal(0, buffer.Offset);
                Assert.Equal(capacity, buffer.BufferArray.Length);
            }

            [Fact]
            public void ShouldThrowException_WhenBufferIsNull()
            {
                // Arrange
                var buffer = new DataBuffer(32);

                // Act
                var exception = Record.Exception(() =>
                {
                    buffer.Write(null, 2, 2);
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentNullException>(exception);
            }

            [Fact]
            public void ShouldThrowException_WhenOffsetIsNegative()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer(32);

                // Act
                var exception = Record.Exception(() =>
                {
                    buffer.Write(data, -2, 2);
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrowException_WhenOffsetIsOutOfRange()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer(32);

                // Act
                var exception = Record.Exception(() =>
                {
                    buffer.Write(data, 200, 2);
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrowException_WhenCountIsNegative()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer(32);

                // Act
                var exception = Record.Exception(() =>
                {
                    buffer.Write(data, 2, -2);
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrowException_WhenCountIsOutOfRange()
            {
                // Arrange
                var data = Encoding.UTF8.GetBytes("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
                var buffer = new DataBuffer(32);

                // Act
                var exception = Record.Exception(() =>
                {
                    buffer.Write(data, 2, 200);
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }
        }
    }
}
