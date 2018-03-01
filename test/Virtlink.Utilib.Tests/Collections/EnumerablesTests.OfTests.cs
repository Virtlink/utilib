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
        /// Tests the <see cref="Enumerables.Of"/> method.
        /// </summary>
        public sealed class OfTests
        {
            [Fact]
            public void ShouldReturnASingleton()
            {
                // Arrange
                var value = "a";

                // Act
                var enumerable = Enumerables.Of(value);

                // Assert
                Assert.Equal(new [] { value }, enumerable);
            }
        }
    }
}
