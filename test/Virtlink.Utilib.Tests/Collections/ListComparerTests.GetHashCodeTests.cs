using System;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class ListComparerTests
    {
        /// <summary>
        /// Tests the <see cref="ListComparer{T}.GetHashCode"/> method.
        /// </summary>
        public sealed class GetHashCodeTests
        {
            [Fact]
            public void ShouldHaveSameHashCode_WhenGivenSameLists()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = c1;

                // Act
                int h1 = ListComparer<String>.Default.GetHashCode(c1);
                int h2 = ListComparer<String>.Default.GetHashCode(c2);

                // Assert
                Assert.Equal(h1, h2);
            }

            [Fact]
            public void ShouldHaveSameHashCode_WhenGivenEqualLists()
            {
                // Arrange
                var c1 = new[] {"a", "b", "b", "c"};
                var c2 = new[] {"a", "b", "b", "c"};

                // Act
                int h1 = ListComparer<String>.Default.GetHashCode(c1);
                int h2 = ListComparer<String>.Default.GetHashCode(c2);

                // Assert
                Assert.Equal(h1, h2);
            }
        }
    }
}
