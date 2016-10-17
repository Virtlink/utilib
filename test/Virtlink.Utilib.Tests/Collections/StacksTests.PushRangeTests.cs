using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class StacksTests
    {
        /// <summary>
        /// Tests the <see cref="PushRange"/> method.
        /// </summary>
        public sealed class PushRangeTests
        {
            [Fact]
            public void EmptyRangePushesNothing()
            {
                // Arrange
                var input = new String[0];
                var stack = new Stack<String>(new[] { "a" });

                // Act
                stack.PushRange(input);

                // Assert
                Assert.Equal(new[] { "a" }, stack);
            }

            [Fact]
            public void SomeRangePushesFirstToLast()
            {
                // Arrange
                var input = new[] {"b", "c", "d"};
                var stack = new Stack<String>(new [] {"a"});

                // Act
                stack.PushRange(input);

                // Assert
                Assert.Equal(new [] { "d", "c", "b", "a" }, stack);
            }
        }
    }
}
