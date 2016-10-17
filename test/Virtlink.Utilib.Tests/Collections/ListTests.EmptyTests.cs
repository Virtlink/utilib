using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class ListTests
    {
        /// <summary>
        /// Tests the <see cref="List.Empty"/> function.
        /// </summary>
        public sealed class EmptyTests
        {
            [Fact]
            public void ReturnsAnEmptyArray()
            {
                // Act
                var result = List.Empty<String>();

                // Assert
                Assert.IsAssignableFrom<IReadOnlyList<String>>(result);
            }

            [Fact]
            public void ReturnedEmptyArrayCannotBeModified()
            {
                // Act
                var result = (IList<String>)List.Empty<String>();

                // Assert
                Assert.Throws<NotSupportedException>(() =>
                {
                    result.Add("test");
                });
            }
        }
    }
}
