using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class StacksTests
    {
        /// <summary>
        /// Tests the <see cref="Stacks.PeekOrDefault"/> method.
        /// </summary>
        public sealed class PeekOrDefaultTests
        {
            [Fact]
            public void ShouldReturnTheTopElement_WhenTheQueueIsNotEmpty()
            {
                // Arrange
                var stack = new Stack<String>(new[] { "a", "b", "c" });

                // Act
                var element = stack.PeekOrDefault();

                // Assert
                Assert.Equal("c", element);
            }

            [Fact]
            public void ShouldReturnDefault_WhenTheQueueIsEmpty()
            {
                // Arrange
                var stack = new Stack<String>();

                // Act
                var element = stack.PeekOrDefault();

                // Assert
                Assert.Null(element);
            }

            [Fact]
            public void ShouldThrowArgumentNullException_WhenStackIsNull()
            {
                // Arrange
                Stack<String> sut = null;

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
