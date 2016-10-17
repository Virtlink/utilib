using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class QueuesTests
    {
        /// <summary>
        /// Tests the <see cref="EnqueueRange"/> method.
        /// </summary>
        public sealed class EnqueueRangeTests
        {
            [Fact]
            public void EmptyRangeEnqueuesNothing()
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
            public void SomeRangeEnqueuesFirstToLast()
            {
                // Arrange
                var input = new[] {"b", "c", "d"};
                var queue = new Queue<String>(new [] {"a"});

                // Act
                queue.EnqueueRange(input);

                // Assert
                Assert.Equal(new [] { "a", "b", "c", "d" }, queue);
            }
        }
    }
}
