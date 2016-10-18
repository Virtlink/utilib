using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.Collections
{
    partial class StacksTests
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
                var stack = new Stack<String>(new[] { "a", "b", "c" });

                // Act
                var element = stack.PeekOrDefault();

                // Assert
                Assert.That(element, Is.EqualTo("c"));
            }

            [Test]
            public void OnAnEmptyQueueReturnsDefault()
            {
                // Arrange
                var stack = new Stack<String>();

                // Act
                var element = stack.PeekOrDefault();

                // Assert
                Assert.That(element, Is.Null);
            }

            [Test]
            public void ThrowsWhenStackIsNull()
            {
                // Arrange
                Stack<String> sut = null;

                // Act/Assert
                Assert.That(() =>
                {
                    sut.PeekOrDefault();
                }, Throws.ArgumentNullException);
            }
        }
    }
}
