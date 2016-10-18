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
        /// Tests the <see cref="PeekOrDefault"/> method.
        /// </summary>
        public sealed class PeekOrDefaultTests
        {
            [Fact]
            public void OnANonEmptyQueueReturnsTheTopElement()
            {
                // Arrange
                var queue = new Queue<String>(new[] { "a", "b", "c" });

                // Act
                var element = queue.PeekOrDefault();

                // Assert
                Assert.Equal("a", element);
            }

            [Fact]
            public void OnAnEmptyQueueReturnsDefault()
            {
                // Arrange
                var queue = new Queue<String>();

                // Act
                var element = queue.PeekOrDefault();

                // Assert
                Assert.Null(element);
            }

            [Fact]
            public void ThrowsWhenQueueIsNull()
            {
                // Arrange
                Queue<String> sut = null;

                // Act/Assert
                Assert.Throws<ArgumentNullException>(() =>
                {
                    sut.PeekOrDefault();
                });
            }
        }
    }
}
