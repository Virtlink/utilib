using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace Virtlink.Utilib.Text
{
    partial class CodePointTests
    {
        /// <summary>
        /// Tests the <see cref="CodePoint.MinValue"/> static property.
        /// </summary>
        public sealed class MinValueTests
        {
            [Fact]
            public void ShouldReturnCodePointAt0()
            {
                // Act
                var result = CodePoint.MinValue;

                // Assert
                Assert.Equal(0, result.Value);
            }
        }
    }
}
