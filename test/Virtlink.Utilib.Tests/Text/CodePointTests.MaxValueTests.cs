using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;
// ReSharper disable InconsistentNaming

namespace Virtlink.Utilib.Text
{
    partial class CodePointTests
    {
        /// <summary>
        /// Tests the <see cref="CodePoint.MaxValue"/> static property.
        /// </summary>
        public sealed class MaxValueTests
        {
            [Fact]
            public void ShouldReturnCodePointAt0x10FFFF()
            {
                // Act
                var result = CodePoint.MaxValue;

                // Assert
                Assert.Equal(0x10FFFF, result.Value);
            }
        }
    }
}
