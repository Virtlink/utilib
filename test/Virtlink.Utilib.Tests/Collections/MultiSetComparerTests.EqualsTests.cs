using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.Collections
{
    partial class MultiSetComparerTests
    {
        /// <summary>
        /// Tests the <see cref="MultiSetComparer{T}.Equals"/> method.
        /// </summary>
        [TestFixture]
        public sealed class EqualsTests
        {
            [Test]
            public void SameCollectionsAreEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = c1;

                // Act
                bool result = MultiSetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void EqualCollectionsAreEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "b", "c"};

                // Act
                bool result = MultiSetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void EquivalentCollectionsAreEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"c", "b", "a", "b"};

                // Act
                bool result = MultiSetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void EmptySetsAreEqual()
            {
                // Arrange
                var set0 = new int[0];
                var set1 = new List<int>();
                var sut = new MultiSetComparer<int>();

                // Act
                bool result = sut.Equals(set0, set1);

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void NullsAreEqual()
            {
                // Arrange
                var sut = new MultiSetComparer<int>();

                // Act
                bool result = sut.Equals(null, null);

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void CollectionsWithDifferentElementsAreNotEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "d", "e"};

                // Act
                bool result = MultiSetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void CollectionsWithDifferentMultiplesOfElementsAreNotEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "c", "c"};

                // Act
                bool result = MultiSetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void CollectionsWithDifferentCountsAreNotEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "c"};

                // Act
                bool result = MultiSetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void SetsAndNullAreNotEqual()
            {
                // Arrange
                var set0 = new int[0];
                var sut = new MultiSetComparer<int>();

                // Act
                bool result = sut.Equals(set0, null);

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void ComparerIsUsedForComparison()
            {
                // Arrange
                var set0 = new[] { "B", "D", "g", "g", "A", "C", "E", "e", "E" };
                var set1 = new[] { "b", "d", "G", "G", "A", "C", "e", "e", "e" };
                var sut = new MultiSetComparer<string>(StringComparer.OrdinalIgnoreCase);

                // Act
                bool result = sut.Equals(set0, set1);

                // Assert
                Assert.That(result, Is.True);
            }
        }
    }
}
