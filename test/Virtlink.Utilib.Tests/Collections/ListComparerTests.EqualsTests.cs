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
        /// Tests the <see cref="ListComparer{T}.Equals"/> method.
        /// </summary>
        [TestFixture]
        public sealed class EqualsTests
        {
            [Test]
            public void SameListsAreEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = c1;

                // Act
                bool result = ListComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void EqualListsAreEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "b", "c"};

                // Act
                bool result = ListComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void ListsWithDifferentlyOrderedElementsAreNotEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"c", "b", "a", "b"};

                // Act
                bool result = ListComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void EmptyListsAreEqual()
            {
                // Arrange
                var set0 = new int[0];
                var set1 = new List<int>();
                var sut = new ListComparer<int>();

                // Act
                bool result = sut.Equals(set0, set1);

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void NullsAreEqual()
            {
                // Arrange
                var sut = new ListComparer<int>();

                // Act
                bool result = sut.Equals(null, null);

                // Assert
                Assert.That(result, Is.True);
            }

            [Test]
            public void ListsWithDifferentElementsAreNotEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "d", "e"};

                // Act
                bool result = ListComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void ListsWithDifferentMultiplesOfElementsAreNotEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "c", "c"};

                // Act
                bool result = ListComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void ListsWithDifferentCountsAreNotEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "c"};

                // Act
                bool result = ListComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void ListsAndNullAreNotEqual()
            {
                // Arrange
                var list0 = new int[0];
                var sut = new ListComparer<int>();

                // Act
                bool result = sut.Equals(list0, null);

                // Assert
                Assert.That(result, Is.False);
            }

            [Test]
            public void ComparerIsUsedForComparison()
            {
                // Arrange
                var list0 = new[] { "B", "D", "g", "g", "A", "C", "E", "e", "E" };
                var list1 = new[] { "b", "d", "G", "G", "A", "C", "e", "e", "e" };
                var sut = new ListComparer<string>(StringComparer.OrdinalIgnoreCase);

                // Act
                bool result = sut.Equals(list0, list1);

                // Assert
                Assert.That(result, Is.True);
            }
        }
    }
}
