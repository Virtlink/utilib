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
        /// Tests the <see cref="CodePointSet.Contains"/> method.
        /// </summary>
        public sealed class ContainsTests
        {
            [Fact]
            public void ShouldReturnFalse_WhenTheSetIsEmpty()
            {
                // Arrange
                var set = new CodePointSet();

                // Act
                var result = set.Contains(new CodePoint(42));

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void ShouldReturnFalse_WhenEofElementIsNotInTheSet()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010)
                });

                // Act
                var result = set.Contains(CodePoint.Eof);

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void ShouldReturnFalse_WhenTheLowElementIsNotInTheSet()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010)
                });

                // Act
                var result = set.Contains(new CodePoint(100));

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void ShouldReturnFalse_WhenTheHighElementIsNotInTheSet()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010)
                });

                // Act
                var result = set.Contains(new CodePoint(1011));

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenEofIsInTheSet()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    CodePoint.Eof,
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010)
                });

                // Act
                var result = set.Contains(CodePoint.Eof);

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenTheLowElementIsInTheSet()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010)
                });

                // Act
                var result = set.Contains(new CodePoint(43));

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenTheHighElementIsInTheSet_1()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010), CodePoint.Eof
                });

                // Act
                var result = set.Contains(new CodePoint(1000));

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenTheHighElementIsInTheSet_2()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010), CodePoint.Eof
                });

                // Act
                var result = set.Contains(new CodePoint(1001));

                // Assert
                Assert.True(result);
            }

            [Fact]
            public void ShouldReturnTrue_WhenTheHighElementIsInTheSet_3()
            {
                // Arrange
                var set = new CodePointSet(new[]
                {
                    new CodePoint(42), new CodePoint(43), new CodePoint(44), new CodePoint(66),
                    new CodePoint(1000), new CodePoint(1001), new CodePoint(1002), new CodePoint(1010)
                });

                // Act
                var result = set.Contains(new CodePoint(1002));

                // Assert
                Assert.True(result);
            }
        }
    }
}
