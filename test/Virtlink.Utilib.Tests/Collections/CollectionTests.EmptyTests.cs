using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class CollectionTests
    {
        /// <summary>
        /// Tests the <see cref="Collection.Empty"/> function.
        /// </summary>
        public sealed class EmptyTests
        {
            [Fact]
            public void ReturnsAnEmptyArray()
            {
                // Act
                var result = Collection.Empty<String>();

                // Assert
                Assert.IsAssignableFrom<IReadOnlyCollection<String>>(result);
            }

            [Fact]
            public void ReturnedEmptyArrayCannotBeModified()
            {
                // Act
                var result = (ICollection<String>)Collection.Empty<String>();

                // Assert
                Assert.Throws<NotSupportedException>(() =>
                {
                    result.Add("test");
                });
            }
        }
    }
}
