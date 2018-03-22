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
        /// Tests the <see cref="CodePointSet"/> constructors.
        /// </summary>
        public sealed class ConstructorTests
        {
            [Fact]
            public void ShouldCreateEmptySet_WhenGivenNoElements()
            {
                // Arrange
                var elements = Enumerable.Empty<CodePoint>();

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(new CodePoint[0], result);
            }

            [Fact]
            public void ShouldCreateSingletonSet_WhenGivenEof()
            {
                // Arrange
                var elements = new[] { CodePoint.Eof };

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(elements, result);
            }

            [Fact]
            public void ShouldCreateSingletonSet_WhenGivenLowCodePoint()
            {
                // Arrange
                var elements = new [] { new CodePoint(42) };

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(elements, result);
            }

            [Fact]
            public void ShouldCreateSingletonSet_WhenGivenHighCodePoint()
            {
                // Arrange
                var elements = new[] { new CodePoint(1000) };

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(elements, result);
            }

            [Fact]
            public void ShouldCreateSet_WhenGivenLowCodePoints()
            {
                // Arrange
                var elements = new[] { new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66) };

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(elements, result);
            }

            [Fact]
            public void ShouldCreateSet_WhenGivenHighCodePoints()
            {
                // Arrange
                var elements = new[] { new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010) };

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(elements, result);
            }

            [Fact]
            public void ShouldCreateSet_WhenGivenLowCodePointsWithEof()
            {
                // Arrange
                var elements = new[] { new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66), CodePoint.Eof };

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(elements, result);
            }

            [Fact]
            public void ShouldCreateSet_WhenGivenHighCodePointsWithEof()
            {
                // Arrange
                var elements = new[] { new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010), CodePoint.Eof };

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(elements, result);
            }

            [Fact]
            public void ShouldCreateSet_WhenGivenCodePoints()
            {
                // Arrange
                var elements = new[] { new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66), new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010) };

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(elements, result);
            }

            [Fact]
            public void ShouldCreateSet_WhenGivenCodePointsWithEof()
            {
                // Arrange
                var elements = new[] { CodePoint.Eof, new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66), new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010) };

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(elements, result);
            }

            [Fact]
            public void ShouldDiscardDuplicates_WhenGivenEof()
            {
                // Arrange
                var elements = new[] { CodePoint.Eof, new CodePoint(43), CodePoint.Eof };

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(new[] { CodePoint.Eof, new CodePoint(43) }, result);
            }

            [Fact]
            public void ShouldDiscardDuplicates_WhenGivenLowCodePoints()
            {
                // Arrange
                var elements = new[] { new CodePoint(42), new CodePoint(43), new CodePoint(42), new CodePoint(43) };

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(new [] { new CodePoint(42), new CodePoint(43) }, result);
            }

            [Fact]
            public void ShouldDiscardDuplicates_WhenGivenHighCodePoints()
            {
                // Arrange
                var elements = new[] { new CodePoint(1000), new CodePoint(1001), new CodePoint(1000), new CodePoint(1001) };

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(new[] { new CodePoint(1000), new CodePoint(1001) }, result);
            }


            [Fact]
            public void ShouldDiscardDuplicates_WhenGivenCodePoints()
            {
                // Arrange
                var elements = new[] { CodePoint.Eof, new CodePoint(1000), new CodePoint(43), new CodePoint(1000), new CodePoint(43), CodePoint.Eof };

                // Act
                var result = new CodePointSet(elements);

                // Assert
                Assert.Equivalent(new[] { new CodePoint(1000), new CodePoint(43), CodePoint.Eof }, result);
            }

            [Fact]
            public void ShouldThrow_WhenGivenNull()
            {
                // Act
                var exception = Record.Exception(() =>
                {
                    // ReSharper disable once UnusedVariable
                    var result = new CodePointSet(null);
                });
                
                // Assert
                Assert.IsAssignableFrom<ArgumentException>(exception);
            }
        }
    }
}
