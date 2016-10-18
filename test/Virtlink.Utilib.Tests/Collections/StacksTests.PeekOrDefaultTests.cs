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
        /// Tests the <see cref="PeekOrDefault"/> method.
        /// </summary>
        public sealed class PeekOrDefaultTests
        {
            [Fact]
            public void OnANonEmptyQueueReturnsTheTopElement()
            {
                // Arrange
                var stack = new Stack<String>(new[] { "a", "b", "c" });

                // Act
                var element = stack.PeekOrDefault();

                // Assert
                Assert.Equal("c", element);
            }

            [Fact]
            public void OnAnEmptyQueueReturnsDefault()
            {
                // Arrange
                var stack = new Stack<String>();

                // Act
                var element = stack.PeekOrDefault();

                // Assert
                Assert.Null(element);
            }

            [Fact]
            public void ThrowsWhenStackIsNull()
            {
                // Arrange
                Stack<String> sut = null;

                // Act/Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    sut.PeekOrDefault();
                });
            }
        }
    }
}
