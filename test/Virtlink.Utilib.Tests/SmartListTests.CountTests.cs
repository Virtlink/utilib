using System;
using System.Collections.Generic;
using System.Text;
using Virtlink.Utilib.Collections;
using Xunit;

namespace Virtlink.Utilib
{
    partial class SmartListTests
    {
        public sealed class CountTests
        {
            [Fact]
            public void ShouldEnumerateAndReturnZero_WhenEnumerableIsEmpty()
            {
                // Arrange
                IEnumerable<string> Empty() { yield break; }
                var enumerable = new CheckingEnumerable<string>(Empty());
                var smartList = new SmartList<string>(enumerable);

                // Act
                var count = smartList.Count;

                // Assert
                Assert.Equal(0, count);
                Assert.True(enumerable.Enumerated);
            }

            [Fact]
            public void ShouldNotEnumerateButReturnZero_WhenCollectionIsEmpty()
            {
                // Arrange
                var collection = new CheckingCollection<string>(new string[0]);
                var smartList = new SmartList<string>(collection);

                // Act
                var count = smartList.Count;

                // Assert
                Assert.Equal(0, count);
                Assert.False(collection.Enumerated);
            }

            [Fact]
            public void ShouldEnumerateEnumerableAndReturnOne_WhenEnumerableIsSingleton()
            {
                // Arrange
                IEnumerable<string> Singleton() { yield return "a"; }
                var enumerable = new CheckingEnumerable<string>(Singleton());
                var smartList = new SmartList<string>(enumerable);

                // Act
                var count = smartList.Count;

                // Assert
                Assert.Equal(1, count);
                Assert.True(enumerable.Enumerated);
            }

            [Fact]
            public void ShouldNotEnumerateButReturnOne_WhenCollectionIsSingleton()
            {
                // Arrange
                var collection = new CheckingCollection<string>(new [] { "a" });
                var smartList = new SmartList<string>(collection);

                // Act
                var count = smartList.Count;

                // Assert
                Assert.Equal(1, count);
                Assert.False(collection.Enumerated);
            }

            [Fact]
            public void ShouldEnumerateAndReturnCount_WhenEnumerable()
            {
                // Arrange
                IEnumerable<string> Enumerable() {
                    yield return "a";
                    yield return "b";
                    yield return "c";
                }
                var enumerable = new CheckingEnumerable<string>(Enumerable());
                var smartList = new SmartList<string>(enumerable);

                // Act
                var count = smartList.Count;

                // Assert
                Assert.Equal(3, count);
                Assert.True(enumerable.Enumerated);
            }

            [Fact]
            public void ShouldNotEnumerateButReturnCount_WhenCollection()
            {
                // Arrange
                var collection = new CheckingCollection<string>(new[]
                {
                    "a",
                    "b",
                    "c"
                });
                var smartList = new SmartList<string>(collection);

                // Act
                var count = smartList.Count;

                // Assert
                Assert.Equal(3, count);
                Assert.False(collection.Enumerated);
            }

            [Fact]
            public void ShouldEnumerateRemainderAndReturnCount_WhenEnumerable()
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
                var enumerator = smartList.GetEnumerator();
                enumerator.MoveNext();
                enumerator.MoveNext();

                // Act
                var count = smartList.Count;

                // Assert
                Assert.Equal(3, count);
                Assert.True(enumerable.Enumerated);

                // Cleanup
                enumerator.Dispose();
            }

            [Fact]
            public void ShouldReturnCount_WhenFullyEnumerated()
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
                var enumerator = smartList.GetEnumerator();
                enumerator.MoveNext();
                enumerator.MoveNext();
                enumerator.MoveNext();
                enumerator.MoveNext();
                enumerator.MoveNext();

                // Act
                var count = smartList.Count;

                // Assert
                Assert.Equal(3, count);
                Assert.True(enumerable.Enumerated);

                // Cleanup
                enumerator.Dispose();
            }

            [Fact]
            public void ShouldEnumerateOnce_WhenAskingForCountMultipleTimes()
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
                var enumerator = smartList.GetEnumerator();
                enumerator.MoveNext();

                // Act
                var count0 = smartList.Count;
                var count1 = smartList.Count;
                var count2 = smartList.Count;

                // Assert
                Assert.Equal(3, count0);
                Assert.Equal(3, count1);
                Assert.Equal(3, count2);
                Assert.True(enumerable.Enumerated);

                // Cleanup
                enumerator.Dispose();
            }
        }
    }
}
