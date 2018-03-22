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
        /// Tests the <see cref="CodePointSet.TryGetValue"/> method.
        /// </summary>
        public sealed class TryGetValueTests
        {
            [Fact]
            public void ShouldReturnFalseAndTheDefaultCodePoint_WhenTheSetIsEmpty()
            {
                // Arrange
                var set = new CodePointSet();
                var test = new CodePoint(42);

                // Act
                var present = set.TryGetValue(test, out CodePoint result);

                // Assert
                Assert.False(present);
                Assert.Equal(default(CodePoint), result);
            }

            [Fact]
            public void ShouldReturnFalseAndTheDefaultCodePoint_WhenTheElementIsNotInTheSet()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010)
                });
                var test = new CodePoint(100);

                // Act
                var present = set.TryGetValue(test, out CodePoint result);

                // Assert
                Assert.False(present);
                Assert.Equal(default(CodePoint), result);
            }

            [Fact]
            public void ShouldReturnTrueAndTheGivenCodePoint_WhenEofIsInTheSet()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010),
                    CodePoint.Eof
                });
                var test = CodePoint.Eof;

                // Act
                var present = set.TryGetValue(test, out CodePoint result);

                // Assert
                Assert.True(present);
                Assert.Equal(test, result);
            }

            [Fact]
            public void ShouldReturnTrueAndTheGivenCodePoint_WhenTheLowElementIsInTheSet()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010)
                });
                var test = new CodePoint(43);

                // Act
                var present = set.TryGetValue(test, out CodePoint result);

                // Assert
                Assert.True(present);
                Assert.Equal(test, result);
            }

            [Fact]
            public void ShouldReturnTrueAndTheGivenCodePoint_WhenTheHighElementIsInTheSet_1()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010)
                });
                var test = new CodePoint(1000);

                // Act
                var present = set.TryGetValue(test, out CodePoint result);

                // Assert
                Assert.True(present);
                Assert.Equal(test, result);
            }

            [Fact]
            public void ShouldReturnTrueAndTheGivenCodePoint_WhenTheHighElementIsInTheSet_2()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010)
                });
                var test = new CodePoint(1001);

                // Act
                var present = set.TryGetValue(test, out CodePoint result);

                // Assert
                Assert.True(present);
                Assert.Equal(test, result);
            }

            [Fact]
            public void ShouldReturnTrueAndTheGivenCodePoint_WhenTheHighElementIsInTheSet_3()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010)
                });
                var test = new CodePoint(1002);

                // Act
                var present = set.TryGetValue(test, out CodePoint result);

                // Assert
                Assert.True(present);
                Assert.Equal(test, result);
            }
        }
    }
}
