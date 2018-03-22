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
        /// Tests the <see cref="CodePoint.Value"/> property.
        /// </summary>
        public sealed class ValueTests
        {
            [Fact]
            public void ShouldReturnTheSameValueGivenToTheConstructor()
            {
                // Arrange
                int value = 0x1242B;
                var instance = new CodePoint(value);

                // Act
                var result = instance.Value;

                // Assert
                Assert.Equal(value, result);
            }

            [Fact]
            public void ShouldThrow_WhenCodePointIsEof()
            {
                // Arrange
                var instance = CodePoint.Eof;

                // Act
                var exception = Record.Exception(() =>
                {
                    // ReSharper disable once UnusedVariable
                    var result = instance.Value;
                });

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }
        }
    }
}
