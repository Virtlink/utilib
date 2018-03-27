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
        /// Tests the <see cref="Enumerables.ToDictionary"/> method.
        /// </summary>
        public sealed class ToDictionaryTests
        {
            [Fact]
            public void ShouldReturnDictionary_WhenGivenListOfKeyValuePairs()
            {
                // Arrange
                var input = new[]
                {
                    new KeyValuePair<String, int>("a", 1),
                    new KeyValuePair<String, int>("b", 2),
                    new KeyValuePair<String, int>("c", 3)
                };

                // Act
                var dictionary = input.ToDictionary();

                // Assert
                Assert.Equal(input, dictionary);
            }
        }
    }
}
