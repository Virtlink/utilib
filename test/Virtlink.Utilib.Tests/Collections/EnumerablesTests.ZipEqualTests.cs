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
        /// Tests the <see cref="Enumerables.ZipEqual"/> method.
        /// </summary>
        public sealed class ZipEqualTests
        {
            [Fact]
            public void ShouldReturnZippedSequence_WhenSequencesAreEqualInLength()
            {
                // Arrange
                var first = new[] {"a", "b", "c"};
                var second = new[] {1, 2, 3};

                // Act
                var result = Enumerables.ZipEqual(first, second, (l, r) => l + r).ToArray();

                // Assert
                Assert.Equal(new[] {"a1", "b2", "c3"}, result);
            }

            [Fact]
            public void ShouldReturnEmptySequence_WhenBothSequencesAreEmpty()
            {
                // Arrange
                var first = new string[0];
                var second = new int[0];

                // Act
                var result = Enumerables.ZipEqual(first, second, (l, r) => l + r).ToArray();

                // Assert
                Assert.Empty(result);
            }

            [Fact]
            public void ShouldThrowException_WhenFirstSequenceIsLonger()
            {
                // Arrange
                var first = new[] { "a", "b", "c", "d", "e" };
                var second = new[] { 1, 2, 3 };

                // Act
                var exception = Record.Exception(() =>
                {
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    Enumerables.ZipEqual(first, second, (l, r) => l + r).ToArray();
                });
                
                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }

            [Fact]
            public void ShouldThrowException_WhenSecondSequenceIsLonger()
            {
                // Arrange
                var first = new[] { "a", "b", "c" };
                var second = new[] { 1, 2, 3, 4, 5 };

                // Act
                var exception = Record.Exception(() =>
                {
                    // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                    Enumerables.ZipEqual(first, second, (l, r) => l + r).ToArray();
                });

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }
        }
    }
}
