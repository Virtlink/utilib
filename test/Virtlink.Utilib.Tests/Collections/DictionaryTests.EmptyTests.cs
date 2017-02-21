using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class DictionaryTests
    {
        /// <summary>
        /// Tests the <see cref="Dictionary.Empty"/> function.
        /// </summary>
        public sealed class EmptyTests
        {
            [Fact]
            public void ShouldReturnIReadOnlyDictionary()
            {
                // Act
                var result = Dictionary.Empty<String, Object>();

                // Assert
                Assert.IsAssignableFrom<IReadOnlyDictionary<String, Object>>(result);
            }

            [Fact]
            public void ShouldThrowNotSupportedException_WhenEmptyDictionaryIsModified()
            {
                // Arrange
                var result = (IDictionary<String, Object>)Dictionary.Empty<String, Object>();

                // Act
                var exception = Record.Exception(() =>
                {
                    result.Add("test", 12);
                });

                // Assert
                Assert.IsType<NotSupportedException>(exception);
            }
        }
    }
}
