using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class SetComparerTests
    {
        /// <summary>
        /// Tests the <see cref="SetComparer{T}.Equals"/> method.
        /// </summary>
        public sealed class EqualsTests
        {
            [Fact]
            public void ShouldReturnTrue_WhenGivenSameCollections()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = c1;

                // Act
                bool result = SetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenGivenEqualCollections()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "b", "c"};

                // Act
                bool result = SetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenGivenCollectionsWithDifferentlyOrderedElements()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"c", "b", "a", "b"};

                // Act
                bool result = SetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenGivenEmptyCollections()
            {
                // Arrange
                var set0 = new int[0];
                var set1 = new List<int>();
                var sut = new SetComparer<int>();

                // Act
                bool result = sut.Equals(set0, set1);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenGivenNulls()
            {
                // Arrange
                var sut = new SetComparer<int>();

                // Act
                bool result = sut.Equals(null, null);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnFalse_WhenGivenCollectionsWithDifferentElements()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "d", "e"};

                // Act
                bool result = SetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenGivenCollectionsWithDifferentMultiplesOfElements()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "c", "c"};

                // Act
                bool result = SetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenGivenCollectionsWithDifferentCounts()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "c"};

                // Act
                bool result = SetComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnFalse_WhenGivenCollectionAndNull()
            {
                // Arrange
                var set0 = new int[0];
                var sut = new SetComparer<int>();

                // Act
                bool result = sut.Equals(set0, null);

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void ShouldUseGivenComparerForComparisons()
            {
                // Arrange
                var set0 = new[] { "B", "D", "g", "g", "A", "C", "E", "e", "E" };
                var set1 = new[] { "b", "d", "G", "G", "A", "C", "e", "e", "e" };
                var sut = new SetComparer<string>(StringComparer.OrdinalIgnoreCase);

                // Act
                bool result = sut.Equals(set0, set1);

                // Assert
                Assert.True(result);
            }
        }
    }
}
