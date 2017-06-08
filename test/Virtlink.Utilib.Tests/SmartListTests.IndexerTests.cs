using System;
using System.Collections.Generic;
using System.Text;
using Virtlink.Utilib.Collections;
using Xunit;

namespace Virtlink.Utilib
{
    partial class SmartListTests
    {
        public sealed class IndexerTests
        {
            [Fact]
            public void ShouldEnumerateAndReturnSecondElement_WhenEnumerable()
            {
                // Arrange
                IEnumerable<string> Singleton() {
                    yield return "a";
                    yield return "b";
                    yield return "c";
                }
                var enumerable = new CheckingEnumerable<string>(Singleton());
                var smartList = new SmartList<string>(enumerable);

                // Act
                var second = smartList[1];

                // Assert
                Assert.Equal("b", second);
                Assert.True(enumerable.Enumerated);
                Assert.Equal(2, enumerable.NextIndex);
            }

            [Fact]
            public void ShouldNotEnumerateAndReturnSecondElement_WhenList()
            {
                // Arrange
                var list = new CheckingList<string>(new[]
                {
                    "a",
                    "b",
                    "c"
                });
                var smartList = new SmartList<string>(list);

                // Act
                var second = smartList[1];

                // Assert
                Assert.Equal("b", second);
                Assert.False(list.Enumerated);
            }

            [Fact]
            public void ShouldEnumerateOnlyOnceAndReturnSecondElement_WhenEnumerableAndAskingForSameElement()
            {
                // Arrange
                IEnumerable<string> Enumerable()
                {
                    yield return "a";
                    yield return "b";
                    yield return "c";
                }
                var enumerable = new CheckingEnumerable<string>(Enumerable());
                var smartList = new SmartList<string>(enumerable);

                // Act
                var second0 = smartList[1];
                var second1 = smartList[1];
                var second2 = smartList[1];

                // Assert
                Assert.Equal("b", second0);
                Assert.Equal("b", second1);
                Assert.Equal("b", second2);
                Assert.True(enumerable.Enumerated);
                Assert.Equal(2, enumerable.NextIndex);
            }

            [Fact]
            public void ShouldContinueEnumerating_WhenAskingSubsequentIndices()
            {
                // Arrange
                IEnumerable<string> Enumerable()
                {
                    yield return "a";
                    yield return "b";
                    yield return "c";
                    yield return "d";
                    yield return "e";
                }
                var enumerable = new CheckingEnumerable<string>(Enumerable());
                var smartList = new SmartList<string>(enumerable);

                // Act
                var second = smartList[1];
                var fourth = smartList[3];
                var fifth = smartList[4];

                // Assert
                Assert.Equal("b", second);
                Assert.Equal("d", fourth);
                Assert.Equal("e", fifth);
                Assert.True(enumerable.Enumerated);
                Assert.Equal(5, enumerable.NextIndex);
            }

            [Fact]
            public void ShouldReturnCachedValue_WhenAskingEnumeratedIndex()
            {
                // Arrange
                IEnumerable<string> Enumerable()
                {
                    yield return "a";
                    yield return "b";
                    yield return "c";
                    yield return "d";
                    yield return "e";
                }
                var enumerable = new CheckingEnumerable<string>(Enumerable());
                var smartList = new SmartList<string>(enumerable);
                var enumerator = smartList.GetEnumerator();
                enumerator.MoveNext();
                enumerator.MoveNext();
                enumerator.MoveNext();

                // Act
                var second = smartList[1];

                // Assert
                Assert.Equal("b", second);
                Assert.True(enumerable.Enumerated);
                Assert.Equal(3, enumerable.NextIndex);

                // Cleanup
                enumerator.Dispose();
            }

            [Fact]
            public void ShouldContinueEnumerating_WhenAskingIndexPastEnumeratedPart()
            {
                // Arrange
                IEnumerable<string> Enumerable()
                {
                    yield return "a";
                    yield return "b";
                    yield return "c";
                    yield return "d";
                    yield return "e";
                }
                var enumerable = new CheckingEnumerable<string>(Enumerable());
                var smartList = new SmartList<string>(enumerable);
                var enumerator = smartList.GetEnumerator();
                enumerator.MoveNext();
                enumerator.MoveNext();
                enumerator.MoveNext();

                // Act
                var fifth = smartList[4];

                // Assert
                Assert.Equal("e", fifth);
                Assert.True(enumerable.Enumerated);
                Assert.Equal(5, enumerable.NextIndex);

                // Cleanup
                enumerator.Dispose();
            }

            [Fact]
            public void ShouldThrow_WhenIndexIsNegativeOnEnumerable()
            {
                // Arrange
                IEnumerable<string> Empty() { yield break; }
                var smartList = new SmartList<string>(Empty());

                // Act
                var exception = Record.Exception(() =>
                {
                    var result = smartList[-1];
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrow_WhenIndexIsOutOfBoundOnEmptyEnumerable()
            {
                // Arrange
                IEnumerable<string> Empty() { yield break; }
                var smartList = new SmartList<string>(Empty());

                // Act
                var exception = Record.Exception(() =>
                {
                    var result = smartList[0];
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrow_WhenIndexIsOutOfBoundOnNonEmptyEnumerable()
            {
                // Arrange
                IEnumerable<string> Enumerable()
                {
                    yield return "a";
                    yield return "b";
                    yield return "c";
                }
                var smartList = new SmartList<string>(Enumerable());

                // Act
                var exception = Record.Exception(() =>
                {
                    var result = smartList[7];
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }


            [Fact]
            public void ShouldThrow_WhenIndexIsNegativeOnList()
            {
                // Arrange
                var smartList = new SmartList<string>(new string[0]);

                // Act
                var exception = Record.Exception(() =>
                {
                    var result = smartList[-1];
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrow_WhenIndexIsOutOfBoundOnEmptyList()
            {
                // Arrange
                var smartList = new SmartList<string>(new string[0]);

                // Act
                var exception = Record.Exception(() =>
                {
                    var result = smartList[0];
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }

            [Fact]
            public void ShouldThrow_WhenIndexIsOutOfBoundOnNonEmptyList()
            {
                // Arrange
                var smartList = new SmartList<string>(new [] { "a", "b", "c" });

                // Act
                var exception = Record.Exception(() =>
                {
                    var result = smartList[7];
                });

                // Assert
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(exception);
            }
        }
    }
}
