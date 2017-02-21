using System;
using System.Collections.Generic;
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
            public void ShouldReturnEmptyArray()
            {
                // Act
                var result = Arrays.Empty<String>();

                // Assert
                Assert.Equal(new String[0], result);
            }

            [Fact]
            public void ShouldThrowNotSupportedException_WhenEmptyArrayIsModified()
            {
                // Arrange
                var result = Arrays.Empty<string>();

                // Act
                var exception = Record.Exception(() =>
                {
                    ((ICollection<string>)result).Add("str");
                });

                // Assert
                Assert.IsType<NotSupportedException>(exception);
            }
        }
    }
}
