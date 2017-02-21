using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class ListComparerTests
    {
        /// <summary>
        /// Tests the <see cref="ListComparer{T}.Equals"/> method.
        /// </summary>
        public sealed class EqualsTests
        {
            [Fact]
            public void ShouldReturnTrue_WhenGivenSameLists()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = c1;

                // Act
                bool result = ListComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenGivenEqualLists()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "b", "c"};

                // Act
                bool result = ListComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnFalse_WhenGivenListsWithDifferentlyOrderedElements()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"c", "b", "a", "b"};

                // Act
                bool result = ListComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenGivenEmptyLists()
            {
                // Arrange
                var set0 = new int[0];
                var set1 = new List<int>();
                var sut = new ListComparer<int>();

                // Act
                bool result = sut.Equals(set0, set1);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenGivenNulls()
            {
                // Arrange
                var sut = new ListComparer<int>();

                // Act
                bool result = sut.Equals(null, null);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnFalse_WhenGivenListsWithDifferentElements()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "d", "e"};

                // Act
                bool result = ListComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void ShouldReturnFalse_WhenGivenListsWithDifferentMultiplesOfElements()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "c", "c"};

                // Act
                bool result = ListComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void ShouldReturnFalse_WhenGivenListsWithDifferentCounts()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "c"};

                // Act
                bool result = ListComparer<String>.Default.Equals(c1, c2);

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void ShouldReturnFalse_WhenGivenListAndNull()
            {
                // Arrange
                var list0 = new int[0];
                var sut = new ListComparer<int>();

                // Act
                bool result = sut.Equals(list0, null);

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void ShouldUseGivenComparerForComparisons()
            {
                // Arrange
                var list0 = new[] { "B", "D", "g", "g", "A", "C", "E", "e", "E" };
                var list1 = new[] { "b", "d", "G", "G", "A", "C", "e", "e", "e" };
                var sut = new ListComparer<string>(StringComparer.OrdinalIgnoreCase);

                // Act
                bool result = sut.Equals(list0, list1);

                // Assert
                Assert.True(result);
            }
        }
    }
}
