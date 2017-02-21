using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class EnumerablesTests
    {
        /// <summary>
        /// Tests the <see cref="Enumerables.TryGetCount"/> method.
        /// </summary>
        public sealed class TryGetCountTests
        {
            [Fact]
            public void ShouldReturnTheCount_WhenEnumerableIsAnICollectionOfT()
            {
                // Arrange
                var collection = new List<String>{ "a", "b", "c" };

                // Act
                int? result = Enumerables.TryGetCount(collection);

                // Assert
                Assert.Equal(3, result);
            }

            [Fact]
            public void ShouldReturnTheCount_WhenEnumerableIsAnICollection()
            {
                // Arrange
                var collection = new ArrayList { "a", "b", "c" };

                // Act
                int? result = Enumerables.TryGetCount(collection);

                // Assert
                Assert.Equal(3, result);
            }

            [Fact]
            public void ShouldReturnNull_WhenEnumerableIsNotACollection()
            {
                // Arrange
                var enumerable = new [] { "a", "b", "c" }.Select(s => s);

                // Act
                int? result = Enumerables.TryGetCount(enumerable);

                // Assert
                Assert.Null(result);
            }

            [Fact]
            public void ShouldThrowArgumentNullException_WhenEnumerableIsNull()
            {
                // Arrange
                IReadOnlyCollection<String> enumerable = null;

                // Act
                var exception = Record.Exception(() =>
                {
                    Enumerables.TryGetCount(enumerable);
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }
        }
    }
}
