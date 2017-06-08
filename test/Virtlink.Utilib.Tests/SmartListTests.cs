using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Virtlink.Utilib.Collections;
using Xunit;

namespace Virtlink.Utilib
{
    /// <summary>
    /// Tests the <see cref="SmartList{T}"/> class.
    /// </summary>
    public partial class SmartListTests
    {
        private class CheckingEnumerable<T> : IEnumerable<T>
        {
            private readonly IEnumerable<T> enumerable;

            /// <summary>
            /// Gets the number of times <see cref="GetEnumerator"/> was called.
            /// </summary>
            private int enumerationCount;

            /// <summary>
            /// Gets the next index to be returned by <see cref="GetEnumerator"/>.
            /// </summary>
            public int NextIndex { get; private set; }

            public bool Enumerated => this.enumerationCount > 0;

            public CheckingEnumerable(IEnumerable<T> enumerable)
            {
                this.enumerable = enumerable;
            }

            public IEnumerator<T> GetEnumerator()
            {
                if (this.enumerationCount != 0)
                    throw new InvalidOperationException("Multiple enumeration.");
                this.enumerationCount += 1;
                int index = 0;
                this.NextIndex = index;
                foreach (var element in this.enumerable)
                {
                    index += 1;
                    this.NextIndex = index;
                    yield return element;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private class CheckingCollection<T> : CheckingEnumerable<T>, IReadOnlyCollection<T>
        {
            private readonly IReadOnlyCollection<T> collection;

            public int Count => this.collection.Count;

            public CheckingCollection(IReadOnlyCollection<T> collection)
                : base(collection)
            {
                this.collection = collection;
            }
        }

        private class CheckingList<T> : CheckingCollection<T>, IReadOnlyList<T>
        {
            private readonly IReadOnlyList<T> list;

            public T this[int index] => this.list[index];

            public CheckingList(IReadOnlyList<T> list)
                : base(list)
            {
                this.list = list;
            }
        }
    }
}
