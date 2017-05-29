using System;
using System.Collections.Generic;
using System.Text;
using Virtlink.Utilib.Collections;
using Xunit;

namespace Virtlink.Utilib
{
    partial class SmartListTests
    {
        public sealed class GetEnumeratorTests
        {
            [Fact]
            public void ShouldReturnEnumeratorButDoesNotEnumerate_WhenEnumerable()
            {
                // Arrange
                IEnumerable<string> Empty() { yield break; }
                var enumerable = new CheckingEnumerable<string>(Empty());
                var smartList = new SmartList<string>(enumerable);

                // Act
                var enumerator = smartList.GetEnumerator();

                // Assert
                Assert.NotNull(enumerator);
                Assert.False(enumerable.Enumerated);

                // Cleanup
                enumerator.Dispose();
            }

            [Fact]
            public void ShouldReturnEnumeratorThatImmediatelyReturnsFalse_WhenEmptyEnumerable()
            {
                // Arrange
                IEnumerable<string> Empty() { yield break; }
                var enumerable = new CheckingEnumerable<string>(Empty());
                var smartList = new SmartList<string>(enumerable);

                // Act
                var enumerator = smartList.GetEnumerator();
                bool hasNext = enumerator.MoveNext();

                // Assert
                Assert.False(hasNext);
                Assert.True(enumerable.Enumerated);
                Assert.Equal(0, enumerable.NextIndex);

                // Cleanup
                enumerator.Dispose();
            }

            [Fact]
            public void ShouldReturnEnumeratorThatCanEnumerateElements_WhenEnumerable()
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
                var enumerator = smartList.GetEnumerator();
                enumerator.MoveNext();
                enumerator.MoveNext();
                bool hasNext = enumerator.MoveNext();
                string element = enumerator.Current;
                bool hasMore = enumerator.MoveNext();

                // Assert
                Assert.True(hasNext);
                Assert.False(hasMore);
                Assert.True(enumerable.Enumerated);
                Assert.Equal("c", element);
                Assert.Equal(3, enumerable.NextIndex);

                // Cleanup
                enumerator.Dispose();
            }
        }
    }
}
