using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Functions for working with lists.
    /// </summary>
    public static class List
    {
        /// <summary>
        /// Returns a read-only empty list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <returns>The read-only empty list.</returns>
        public static IReadOnlyList<T> Empty<T>() => EmptyList<T>.Instance;

        /// <summary>
        /// Copies elements from one list to another.
        /// </summary>
        /// <typeparam name="T">The type of elements in the lists.</typeparam>
        /// <param name="sourceList">The source list.</param>
        /// <param name="sourceIndex">The source index.</param>
        /// <param name="destinationList">The destination list.</param>
        /// <param name="destinationIndex">The destination index.</param>
        /// <param name="count">The number of elements to copy.</param>
        public static void Copy<T>(IReadOnlyList<T> sourceList, int sourceIndex, IList<T> destinationList,
            int destinationIndex, int count)
        {
            #region Contract
            if (sourceList == null)
                throw new ArgumentNullException(nameof(sourceList));
            if (sourceIndex < 0 || sourceIndex > sourceList.Count)
                throw new ArgumentOutOfRangeException(nameof(sourceIndex));
            if (destinationList == null)
                throw new ArgumentNullException(nameof(destinationList));
            if (destinationIndex < 0 || destinationIndex > destinationList.Count)
                throw new ArgumentOutOfRangeException(nameof(destinationIndex));
            if (count < 0 || sourceIndex + count > sourceList.Count || destinationIndex + count > destinationList.Count)
                throw new ArgumentOutOfRangeException(nameof(count));
            #endregion
            
            if (sourceIndex < destinationIndex)
            {
                for (int i = count - 1; i >= 0; i--)
                {
                    destinationList[destinationIndex + i] = sourceList[sourceIndex + i];
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    destinationList[destinationIndex + i] = sourceList[sourceIndex + i];
                }
            }
        }

        /// <summary>
        /// Copies elements from one list to another.
        /// </summary>
        /// <typeparam name="T">The type of elements in the lists.</typeparam>
        /// <param name="sourceList">The source list.</param>
        /// <param name="destinationList">The destination list.</param>
        /// <param name="count">The number of elements to copy.</param>
        public static void Copy<T>(IReadOnlyList<T> sourceList, IList<T> destinationList, int count)
            => Copy(sourceList, 0, destinationList, 0, count);


        /// <summary>
        /// A read-only empty list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <remarks>
        /// This list can be cast to a <see cref="IList{T}"/> and <see cref="ICollection{T}"/>,
        /// but is read-only.
        /// </remarks>
        private sealed class EmptyList<T> : IList<T>, ISet<T>, IReadOnlyList<T>, IReadOnlySet<T>
        {
            /// <summary>
            /// The empty list instance.
            /// </summary>
            // ReSharper disable once CollectionNeverUpdated.Local
            public static EmptyList<T> Instance { get; } = new EmptyList<T>();

            /// <inheritdoc />
            int ICollection<T>.Count => 0;

            /// <inheritdoc />
            public int Count => 0;

            /// <inheritdoc />
            public bool IsReadOnly => true;

            /// <inheritdoc cref="IReadOnlyList{T}.this" />
            public T this[int index]
            {
                get => throw new ArgumentOutOfRangeException(nameof(index));
                set => throw new ArgumentOutOfRangeException(nameof(index));
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="EmptyList{T}"/> class.
            /// </summary>
            private EmptyList() { }

            /// <inheritdoc cref="IReadOnlySet{T}.Contains" />
            public bool Contains(T item)
                => false;

            /// <inheritdoc />
            public bool TryGetValue(T equalValue, out T actualValue)
            {
                actualValue = equalValue;
                return false;
            }

            /// <inheritdoc cref="IReadOnlySet{T}.IsProperSubsetOf" />
            public bool IsProperSubsetOf(IEnumerable<T> other)
                => other.Any();

            /// <inheritdoc cref="IReadOnlySet{T}.IsProperSupersetOf" />
            public bool IsProperSupersetOf(IEnumerable<T> other)
                => false;

            /// <inheritdoc cref="IReadOnlySet{T}.IsSubsetOf" />
            public bool IsSubsetOf(IEnumerable<T> other)
                => true;

            /// <inheritdoc cref="IReadOnlySet{T}.IsSupersetOf" />
            public bool IsSupersetOf(IEnumerable<T> other)
                => !other.Any();

            /// <inheritdoc cref="IReadOnlySet{T}.Overlaps" />
            public bool Overlaps(IEnumerable<T> other)
                => false;

            /// <inheritdoc cref="IReadOnlySet{T}.SetEquals" />
            public bool SetEquals(IEnumerable<T> other)
                => !other.Any();

            /// <inheritdoc />
            public void Add(T item)
                => throw new NotSupportedException();

            /// <inheritdoc />
            bool ISet<T>.Add(T item)
                => throw new NotSupportedException();

            /// <inheritdoc />
            public int IndexOf(T item)
                => -1;

            /// <inheritdoc />
            public bool Remove(T item)
                => throw new NotSupportedException();

            /// <inheritdoc />
            public void Insert(int index, T item)
            {
                #region Contract
                if (index != 0)
                    throw new ArgumentOutOfRangeException(nameof(index));
                #endregion

                throw new NotSupportedException();
            }

            /// <inheritdoc />
            public void RemoveAt(int index)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            /// <inheritdoc />
            public void SymmetricExceptWith(IEnumerable<T> other)
                => throw new NotSupportedException();

            /// <inheritdoc />
            public void UnionWith(IEnumerable<T> other)
                => throw new NotSupportedException();

            /// <inheritdoc />
            public void IntersectWith(IEnumerable<T> other)
                => throw new NotSupportedException();

            /// <inheritdoc />
            public void Clear()
                => throw new NotSupportedException();

            /// <inheritdoc />
            public void ExceptWith(IEnumerable<T> other)
                => throw new NotSupportedException();

            /// <inheritdoc />
            public void CopyTo(T[] array, int arrayIndex)
            {
                #region Contract
                if (array == null)
                    throw new ArgumentNullException(nameof(array));
                if (arrayIndex < 0 || arrayIndex > array.Length)
                    throw new ArgumentOutOfRangeException(nameof(arrayIndex));
                #endregion

                // Nothing to do.
            }

            /// <inheritdoc />
            public IEnumerator<T> GetEnumerator()
                => Enumerable.Empty<T>().GetEnumerator();

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();
        }
    }
}