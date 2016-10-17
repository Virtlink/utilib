using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
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
            public void ReturnsCountOfICollection_T()
            {
                // Arrange
                var collection = new List<String>{ "a", "b", "c" };

                // Act
                int? result = Enumerables.TryGetCount(collection);

                // Assert
                Assert.Equal(3, result);
            }

            [Fact]
            public void ReturnsCountOfICollection()
            {
                // Arrange
                var collection = new ArrayList { "a", "b", "c" };

                // Act
                int? result = Enumerables.TryGetCount(collection);

                // Assert
                Assert.Equal(3, result);
            }

            [Fact]
            public void ReturnsNullForNonCollection()
            {
                // Arrange
                var enumerable = new [] { "a", "b", "c" }.Select(s => s);

                // Act
                int? result = Enumerables.TryGetCount(enumerable);

                // Assert
                Assert.Null(result);
            }
        }
    }
}
