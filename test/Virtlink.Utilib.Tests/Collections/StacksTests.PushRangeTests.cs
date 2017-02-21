using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class StacksTests
    {
        /// <summary>
        /// Tests the <see cref="Stacks.PushRange"/> method.
        /// </summary>
        public sealed class PushRangeTests
        {
            [Fact]
            public void ShouldPushNothing_WhenRangeIsEmpty()
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
            public void ShouldPushFirstToLast_WhenRangeIsNotEmpty()
            {
                // Arrange
                var input = new[] {"b", "c", "d"};
                var stack = new Stack<String>(new [] {"a"});

                // Act
                stack.PushRange(input);

                // Assert
                Assert.Equal(new[] { "d", "c", "b", "a" }, stack);
            }
            
            [Fact]
            public void ShouldThrowArgumentNullException_WhenStackIsNull()
            {
                // Arrange
                Stack<String> sut = null;

                // Act
                var exception = Record.Exception(() =>
                {
                    sut.PushRange(new String[0]);
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }
        }
    }
}
