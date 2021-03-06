﻿using System;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class MultiSetComparerTests
    {
        /// <summary>
        /// Tests the <see cref="MultiSetComparer{T}.GetHashCode"/> method.
        /// </summary>
        public sealed class GetHashCodeTests
        {
            [Fact]
            public void ShouldNotThrowAnException_WhenGivenNull()
            {
                // Act
                var exception = Record.Exception(() =>
                {
                    MultiSetComparer<String>.Default.GetHashCode(null);
                });

                // Assert
                Assert.Null(exception);
            }

            [Fact]
            public void ShouldHaveSameHashCode_WhenGivenSameCollections()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = c1;

                // Act
                int h1 = MultiSetComparer<String>.Default.GetHashCode(c1);
                int h2 = MultiSetComparer<String>.Default.GetHashCode(c2);

                // Assert
                Assert.Equal(h1, h2);
            }

            [Fact]
            public void ShouldHaveSameHashCode_WhenGivenEqualCollections()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "b", "c"};

                // Act
                int h1 = MultiSetComparer<String>.Default.GetHashCode(c1);
                int h2 = MultiSetComparer<String>.Default.GetHashCode(c2);

                // Assert
                Assert.Equal(h1, h2);
            }

            [Fact]
            public void ShouldHaveSameHashCode_WhenGivenEquivalentCollections()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"c", "b", "a", "b"};

                // Act
                int h1 = MultiSetComparer<String>.Default.GetHashCode(c1);
                int h2 = MultiSetComparer<String>.Default.GetHashCode(c2);

                // Assert
                Assert.Equal(h1, h2);
            }

            [Fact]
            public void ShouldHaveSameHashCode_WhenGivenEquivalentCollectionsAccordingToGivenComparer()
            {
                // Arrange
                var c1 = new[] { "A", "B", "C" };
                var c2 = new[] { "a", "b", "c" };
                var comparer = new MultiSetComparer<String>(StringComparer.OrdinalIgnoreCase);

                // Act
                int h1 = comparer.GetHashCode(c1);
                int h2 = comparer.GetHashCode(c2);

                // Assert
                Assert.Equal(h1, h2);
            }
        }
    }
}
