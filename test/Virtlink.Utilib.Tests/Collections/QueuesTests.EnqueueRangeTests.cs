using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class QueuesTests
    {
        /// <summary>
        /// Tests the <see cref="Queues.EnqueueRange"/> method.
        /// </summary>
        public sealed class EnqueueRangeTests
        {
            [Fact]
            public void ShouldEnqueueNothing_WhenGivenAnEmptyRange()
            {
                // Arrange
                var input = new String[0];
                var queue = new Queue<String>(new[] { "a" });

                // Act
                queue.EnqueueRange(input);

                // Assert
                Assert.Equal(new[] { "a" }, queue);
            }

            [Fact]
            public void ShouldEnqueueFirstToLast_WhenGivenSomeRange()
            {
                // Arrange
                var input = new[] {"b", "c", "d"};
                var queue = new Queue<String>(new [] {"a"});

                // Act
                queue.EnqueueRange(input);

                // Assert
                Assert.Equal(new[] { "a", "b", "c", "d" }, queue);
            }

            [Fact]
            public void ShouldThrowArgumentNullException_WhenTheQueueIsNull()
            {
                // Arrange
                Queue<String> sut = null;

                // Act
                var exception = Record.Exception(() =>
                {
                    sut.EnqueueRange(new String[0]);
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }
        }
    }
}
