using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Virtlink.Utilib.IO
{
    partial class DataBufferTests
    {
        /// <summary>
        /// Tests the <see cref="DataBuffer.BufferArray"/> property.
        /// </summary>
        public sealed class BufferArrayTests
        {
            [Fact]
            public void ShouldBeNonNull_WhenCreatingNewBuffer()
            {
                // Arrange
                var buffer = new DataBuffer();

                // Act
                var bufferArray = buffer.BufferArray;

                // Assert
                Assert.NotNull(bufferArray);
            }

            [Fact]
            public void ShouldBeAtLeastTheSpecifiedCapacity_WhenCreatingNewBufferWithCapacity()
            {
                // Arrange
                int capacity = 17;
                var buffer = new DataBuffer(capacity);

                // Act
                var bufferArray = buffer.BufferArray;

                // Assert
                Assert.True(bufferArray.Length >= capacity);
            }

            [Fact]
            public void ShouldBeADifferentArray_WhenResized()
            {
                // Arrange
                var buffer = new DataBuffer(1);
                var oldBufferArray = buffer.BufferArray;
                int capacity = oldBufferArray.Length;
                // Write more bytes than the capacity of the buffer,
                // to force a reallocation.
                buffer.Write(new byte[capacity + 10], 0, capacity + 10);

                // Act
                var bufferArray = buffer.BufferArray;

                // Assert
                Assert.NotSame(oldBufferArray, bufferArray);
            }
        }
    }
}
