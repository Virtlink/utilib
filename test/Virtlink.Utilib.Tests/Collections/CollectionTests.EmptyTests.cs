using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class CollectionTests
    {
        /// <summary>
        /// Tests the <see cref="Collection{T}.Empty"/> function.
        /// </summary>
        public sealed class EmptyTests
        {
            [Fact]
            public void ShouldReturnIReadOnlyCollection()
            {
                // Act
                var result = Collection.Empty<String>();

                // Assert
                Assert.IsAssignableFrom<IReadOnlyCollection<String>>(result);
            }

            [Fact]
            public void ShouldThrowNotSupportedException_WhenEmptyCollectionIsModified()
            {
                // Arrange
                var result = (ICollection<String>)Collection.Empty<String>();

                // Act
                var exception = Record.Exception(() =>
                {
                    result.Add("test");
                });

                // Assert
                Assert.IsType<NotSupportedException>(exception);
            }
        }
    }
}
