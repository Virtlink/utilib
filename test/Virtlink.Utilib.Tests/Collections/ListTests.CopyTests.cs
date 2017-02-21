using System;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class ListTests
    {
        /// <summary>
        /// Tests the <see cref="List.Copy"/> function.
        /// </summary>
        public sealed class CopyTests
        {
            [Fact]
            public void ShouldCopyNothing_WhenCountIsZero()
            {
                // Arrange
                var source = new int[] {1, 2, 3};
                var destination = new int[5];

                // Act
                List.Copy(source, 0, destination, 0, 0);

                // Assert
                Assert.Equal(new[] { 0, 0, 0, 0, 0 }, destination);
            }

            [Fact]
            public void ShouldCopyStuff_WhenTwoLists()
            {
                // Arrange
                var source = new int[] { 1, 2, 3 };
                var destination = new int[] { 1, 3, 5, 7, 9 };

                // Act
                List.Copy(source, 1, destination, 2, 2);

                // Assert
                Assert.Equal(new[] { 1, 3, 2, 3, 9 }, destination);
            }

            [Fact]
            public void ShouldCopyBackward_WhenSameListFromStartToLater()
            {
                // Arrange
                var list = new int[] { 1, 2, 3, 4, 5 };

                // Act
                List.Copy(list, 1, list, 3, 2);

                // Assert
                Assert.Equal(new[] { 1, 2, 3, 2, 3 }, list);
            }

            [Fact]
            public void ShouldCopyForward_WhenSameListFromLaterToStart()
            {
                // Arrange
                var list = new int[] { 1, 2, 3, 4, 5 };

                // Act
                List.Copy(list, 3, list, 1, 2);

                // Assert
                Assert.Equal(new[] { 1, 4, 5, 4, 5 }, list);
            }

            [Fact]
            public void ShouldCopyNothing_WhenSameListFromSameToSame()
            {
                // Arrange
                var list = new int[] { 1, 2, 3, 4, 5 };

                // Act
                List.Copy(list, 2, list, 2, 2);

                // Assert
                Assert.Equal(new[] { 1, 2, 3, 4, 5 }, list);
            }

            [Fact]
            public void ShouldThrowArgumentNullException_WhenSourceIsNull()
            {
                // Act
                var exception = Record.Exception(() => {
                    List.Copy(null, 0, new int[5], 0, 0);
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }

            [Fact]
            public void ShouldThrowArgumentNullException_WhenDestinationIsNull()
            {
                // Act
                var exception = Record.Exception(() => {
                    List.Copy(new int[5], 0, null, 0, 0);
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }

            [Fact]
            public void ShouldThrowArgumentOutOfRangeException_WhenSourceIndexIsNegative()
            {
                // Act
                var exception = Record.Exception(() => {
                    List.Copy(new int[5], -3, new int[5], 0, 0);
                });

                // Assert
                Assert.IsType<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrowArgumentOutOfRangeException_WhenDestinationIndexIsNegative()
            {
                // Act
                var exception = Record.Exception(() => {
                    List.Copy(new int[5], 0, new int[5], -3, 0);
                });

                // Assert
                Assert.IsType<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrowArgumentOutOfRangeException_WhenCountIsNegative()
            {
                // Act
                var exception = Record.Exception(() => {
                    List.Copy(new int[5], 0, new int[5], 0, -3);
                });

                // Assert
                Assert.IsType<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrowArgumentOutOfRangeException_WhenSourceIndexOutOfBounds()
            {
                // Act
                var exception = Record.Exception(() => {
                    List.Copy(new int[5], 6, new int[5], 0, 0);
                });

                // Assert
                Assert.IsType<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrowArgumentOutOfRangeException_WhenDestinationIndexOutOfBounds()
            {
                // Act
                var exception = Record.Exception(() => {
                    List.Copy(new int[5], 0, new int[5], 6, 0);
                });

                // Assert
                Assert.IsType<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrowArgumentOutOfRangeException_WhenCountOutOfBounds()
            {
                // Act
                var exception = Record.Exception(() => {
                    List.Copy(new int[5], 5, new int[5], 0, 1);
                });

                // Assert
                Assert.IsType<ArgumentOutOfRangeException>(exception);
            }
        }
    }
}
