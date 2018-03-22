using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Virtlink.Utilib.Collections;
using Xunit;

namespace Virtlink.Utilib.Text
{
    partial class CodePointSetTests
    {
        /// <summary>
        /// Tests the <see cref="CodePointSet.Clear"/> method.
        /// </summary>
        public sealed class ClearTests
        {
            [Fact]
            public void ShouldReturnAnEmptySet()
            {
                // Arrange
                var set = new CodePointSet(new [] { new CodePoint(42), new CodePoint(1000), CodePoint.Eof });

                // Act
                set.Clear();

                // Assert
                Assert.Equal(Enumerable.Empty<CodePoint>(), set);
            }
        }
    }
}
