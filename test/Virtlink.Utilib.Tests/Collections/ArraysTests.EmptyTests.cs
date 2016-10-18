using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class ArraysTests
    {
        /// <summary>
        /// Tests the <see cref="Arrays.Empty"/> function.
        /// </summary>
        public sealed class EmptyTests
        {
            [Fact]
            public void ReturnsAnEmptyArray()
            {
                // Act
                var result = Arrays.Empty<String>();

                // Assert
                Assert.Equal(new String[0], result);
            }

            [Fact]
            public void ReturnedArrayIsImmutable()
            {
                // Arrange
                var result = Arrays.Empty<string>();

                // Act/Assert
                Assert.Throws<NotSupportedException>(() =>
                {
                    ((ICollection<string>)result).Add("str");
                });
            }
        }
    }
}
