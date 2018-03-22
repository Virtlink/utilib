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
        /// Tests the <see cref="CodePointSet.Count"/> property.
        /// </summary>
        public sealed class CountTests
        {
            [Fact]
            public void ShouldReturnZero_WhenTheSetIsEmpty()
            {
                // Arrange
                var set = new CodePointSet();

                // Act
                var result = set.Count;

                // Assert
                Assert.Equal(0, result);
            }

            [Fact]
            public void ShouldReturnOne_WhenTheSetHasEof()
            {
                // Arrange
                var set = new CodePointSet(new[] { CodePoint.Eof });

                // Act
                var result = set.Count;

                // Assert
                Assert.Equal(1, result);
            }

            [Fact]
            public void ShouldReturnOne_WhenTheSetHasOneLowCodePoint()
            {
                // Arrange
                var set = new CodePointSet(new []{ new CodePoint(42) });

                // Act
                var result = set.Count;

                // Assert
                Assert.Equal(1, result);
            }

            [Fact]
            public void ShouldReturnOne_WhenTheSetHasOneHighCodePoint()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(1000) });

                // Act
                var result = set.Count;

                // Assert
                Assert.Equal(1, result);
            }

            [Fact]
            public void ShouldReturnTheNumberOfCodePoints_WhenTheSetHasLowCodePoints()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66) });

                // Act
                var result = set.Count;

                // Assert
                Assert.Equal(4, result);
            }

            [Fact]
            public void ShouldReturnTheNumberOfCodePoints_WhenTheSetHasHighCodePoints()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010) });

                // Act
                var result = set.Count;

                // Assert
                Assert.Equal(4, result);
            }

            [Fact]
            public void ShouldReturnTheNumberOfCodePoints_WhenTheSetHasCodePoints()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010)
                });

                // Act
                var result = set.Count;

                // Assert
                Assert.Equal(8, result);
            }

            [Fact]
            public void ShouldReturnTheNumberOfCodePoints_WhenTheSetHasLowCodePointsWithEof()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66), CodePoint.Eof });

                // Act
                var result = set.Count;

                // Assert
                Assert.Equal(5, result);
            }

            [Fact]
            public void ShouldReturnTheNumberOfCodePoints_WhenTheSetHasHighCodePointsWithEof()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010), CodePoint.Eof });

                // Act
                var result = set.Count;

                // Assert
                Assert.Equal(5, result);
            }

            [Fact]
            public void ShouldReturnTheNumberOfCodePoints_WhenTheSetHasCodePointsWithEof()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010),
                    CodePoint.Eof
                });

                // Act
                var result = set.Count;

                // Assert
                Assert.Equal(9, result);
            }
        }
    }
}
