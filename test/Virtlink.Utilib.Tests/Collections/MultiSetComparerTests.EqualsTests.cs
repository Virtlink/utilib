using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class MultiSetComparerTests
    {
        /// <summary>
        /// Tests the <see cref="MultiSetComparer{T}.Equals"/> method.
        /// </summary>
        public sealed class EqualsTests
        {
            [Fact]
            public void SameCollectionsAreEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = c1;

                // Act
                bool result = MultiSetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void EqualCollectionsAreEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "b", "c"};

                // Act
                bool result = MultiSetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void EquivalentCollectionsAreEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"c", "b", "a", "b"};

                // Act
                bool result = MultiSetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void CollectionsWithDifferentElementsAreNotEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "d", "e"};

                // Act
                bool result = MultiSetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void CollectionsWithDifferentMultiplesOfElementsAreNotEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "c", "c"};

                // Act
                bool result = MultiSetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void CollectionsWithDifferentCountsAreNotEqual()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "c"};

                // Act
                bool result = MultiSetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.False(result);
            }
        }
    }
}
