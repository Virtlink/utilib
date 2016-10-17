using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            public void ReturnsAnEmptyArray()
            {
                // Act
                var result = Dictionary.Empty<String, Object>();

                // Assert
                Assert.IsAssignableFrom<IReadOnlyDictionary<String, Object>>(result);
            }

            [Fact]
            public void ReturnedEmptyArrayCannotBeModified()
            {
                // Act
                var result = (IDictionary<String, Object>)Dictionary.Empty<String, Object>();

                // Assert
                Assert.Throws<NotSupportedException>(() =>
                {
                    result.Add("test", 12);
                });
            }
        }
    }
}
