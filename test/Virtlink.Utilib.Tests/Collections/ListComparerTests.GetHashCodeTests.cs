using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.Collections
{
    partial class ListComparerTests
    {
        /// <summary>
        /// Tests the <see cref="ListComparer{T}.GetHashCode"/> method.
        /// </summary>
        [TestFixture]
        public sealed class GetHashCodeTests
        {
            [Test]
            public void SameListsHaveSameHashCode()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = c1;

                // Act
                int h1 = ListComparer<String>.Default.GetHashCode(c1);
                int h2 = ListComparer<String>.Default.GetHashCode(c2);

                // Assert
                Assert.That(h1, Is.EqualTo(h2));
            }

            [Test]
            public void EqualListsHaveSameHashCode()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "b", "c"};

                // Act
                int h1 = ListComparer<String>.Default.GetHashCode(c1);
                int h2 = ListComparer<String>.Default.GetHashCode(c2);

                // Assert
                Assert.That(h1, Is.EqualTo(h2));
            }
        }
    }
}
