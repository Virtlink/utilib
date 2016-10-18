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
        /// Tests the <see cref="EnqueueRange"/> method.
        /// </summary>
        [TestFixture]
        public sealed class EnqueueRangeTests
        {
            [Test]
            public void EmptyRangeEnqueuesNothing()
            {
                // Arrange
                var input = new String[0];
                var queue = new Queue<String>(new[] { "a" });

                // Act
                queue.EnqueueRange(input);

                // Assert
                Assert.That(queue, Is.EqualTo(new[] { "a" }));
            }

            [Test]
            public void SomeRangeEnqueuesFirstToLast()
            {
                // Arrange
                var input = new[] {"b", "c", "d"};
                var queue = new Queue<String>(new [] {"a"});

                // Act
                queue.EnqueueRange(input);

                // Assert
                Assert.That(queue, Is.EqualTo(new[] { "a", "b", "c", "d" }));
            }

            [Test]
            public void ThrowsWhenQueueIsNull()
            {
                // Arrange
                Queue<String> sut = null;

                // Act/Assert
                Assert.That(() =>
                {
                    sut.EnqueueRange(new String[0]);
                }, Throws.ArgumentNullException);
            }
        }
    }
}
