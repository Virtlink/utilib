using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.Collections
{
    partial class QueuesTests
    {
        /// <summary>
        /// Tests the <see cref="PeekOrDefault"/> method.
        /// </summary>
        [TestFixture]
        public sealed class PeekOrDefaultTests
        {
            [Test]
            public void OnANonEmptyQueueReturnsTheTopElement()
            {
                // Arrange
                var queue = new Queue<String>(new[] { "a", "b", "c" });

                // Act
                var element = queue.PeekOrDefault();

                // Assert
                Assert.That(element, Is.EqualTo("a"));
            }

            [Test]
            public void OnAnEmptyQueueReturnsDefault()
            {
                // Arrange
                var queue = new Queue<String>();

                // Act
                var element = queue.PeekOrDefault();

                // Assert
                Assert.That(element, Is.Null);
            }

            [Test]
            public void ThrowsWhenQueueIsNull()
            {
                // Arrange
                Queue<String> sut = null;

                // Act/Assert
                Assert.That(() =>
                {
                    sut.PeekOrDefault();
                }, Throws.ArgumentNullException);
            }
        }
    }
}
