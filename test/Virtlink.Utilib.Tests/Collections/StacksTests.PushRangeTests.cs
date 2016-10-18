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
        /// Tests the <see cref="PushRange"/> method.
        /// </summary>
        [TestFixture]
        public sealed class PushRangeTests
        {
            [Test]
            public void EmptyRangePushesNothing()
            {
                // Arrange
                var input = new String[0];
                var stack = new Stack<String>(new[] { "a" });

                // Act
                stack.PushRange(input);

                // Assert
                Assert.That(stack, Is.EqualTo(new[] { "a" }));
            }

            [Test]
            public void SomeRangePushesFirstToLast()
            {
                // Arrange
                var input = new[] {"b", "c", "d"};
                var stack = new Stack<String>(new [] {"a"});

                // Act
                stack.PushRange(input);

                // Assert
                Assert.That(stack, Is.EqualTo(new[] { "d", "c", "b", "a" }));
            }

            [Test]
            public void ThrowsWhenStackIsNull()
            {
                // Arrange
                Stack<String> sut = null;

                // Act/Assert
                Assert.That(() =>
                {
                    sut.PushRange(new String[0]);
                }, Throws.ArgumentNullException);
            }
        }
    }
}
