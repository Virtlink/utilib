using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class QueuesTests
    {
        /// <summary>
        /// Tests the <see cref="Queues.PeekOrDefault"/> method.
        /// </summary>
        public sealed class PeekOrDefaultTests
        {
            [Fact]
            public void ShouldReturnTheTopElement_WhenQueueIsNotEmpty()
            {
                // Arrange
                var queue = new Queue<String>(new[] { "a", "b", "c" });

                // Act
                var element = queue.PeekOrDefault();

                // Assert
                Assert.Equal("a", element);
            }

            [Fact]
            public void ShouldReturnDefault_WhenQueueIsEmpty()
            {
                // Arrange
                var queue = new Queue<String>();

                // Act
                var element = queue.PeekOrDefault();

                // Assert
                Assert.Null(element);
            }

            [Fact]
            public void ShouldThrowArgumentNullException_WhenQueueIsNull()
            {
                // Arrange
                Queue<String> sut = null;

                // Act
                var exception = Record.Exception(() =>
                {
                    sut.PeekOrDefault();
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }
        }
    }
}
