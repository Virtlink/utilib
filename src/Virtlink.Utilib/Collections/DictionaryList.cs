using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using JetBrains.Annotations;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// A list that also acts like a dictionary from its integer index to an element.
    /// </summary>
    /// <remarks>
    /// This list works for sequences of elements.
    /// </remarks>
    public sealed class DictionaryList<T> : IDictionary<Int32, T>, IList<T>
    {
        /// <summary>
        /// A list of zero-based offsets of the first element of each range in <see cref="ranges"/>.
        /// </summary>
        private readonly List<int> offsets = new List<int>();
        /// <summary>
        /// A list of ranges of elements.
        /// </summary>
        private readonly List<T[]> ranges = new List<T[]>();

        /// <summary>
        /// The next unused index.
        /// </summary>
        private int nextIndex;

        /// <summary>
        /// Gets the base index of the list.
        /// </summary>
        /// <value>The lowest allowable index in the list.</value>
        public int BaseIndex { get; }

        /// <summary>
        /// Gets the equality comparer used to compare values.
        /// </summary>
        /// <value>The equality comparer for values.</value>
        public IEqualityComparer<T> Comparer { get; }

        /// <inheritdoc cref="ICollection{T}.Count" />
        public int Count { get; }

        /// <inheritdoc />
        public ICollection<int> Keys { get; }

        /// <inheritdoc />
        public ICollection<T> Values => this;

        /// <inheritdoc />
        bool ICollection<KeyValuePair<Int32, T>>.IsReadOnly => false;

        /// <inheritdoc />
        bool ICollection<T>.IsReadOnly => false;

        /// <inheritdoc cref="IList{T}.this" />
        public T this[int index]
        {
            get
            {
                int rangeIndex = GetRangeIndex(index);
                if (rangeIndex == -1) return default(T);
                return this.ranges[rangeIndex][index - this.offsets[rangeIndex]];
            }
            set
            {
                int rangeIndex = GetRangeIndex(index);
                if (rangeIndex == -1) return;
                this.ranges[rangeIndex][index - this.offsets[rangeIndex]] = value;
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryList{T}"/> class.
        /// </summary>
        /// <param name="elements">The initial elements in the list.</param>
        public DictionaryList(IEnumerable<T> elements)
            : this((IEqualityComparer<T>)null)
        {
            #region Contract
            if (elements == null)
                throw new ArgumentNullException(nameof(elements));
            #endregion

            // TODO
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryList{T}"/> class.
        /// </summary>
        /// <param name="comparer">The element comparer; or <see langword="null"/> to use the default.</param>
        public DictionaryList([CanBeNull] IEqualityComparer<T> comparer)
            : this(comparer, 0) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DictionaryList{T}"/> class.
        /// </summary>
        /// <param name="comparer">The element comparer; or <see langword="null"/> to use the default.</param>
        /// <param name="baseIndex">The base index of the list; usually 0.</param>
        public DictionaryList([CanBeNull] IEqualityComparer<T> comparer, int baseIndex)
        {
            this.Comparer = comparer ?? EqualityComparer<T>.Default;
            this.BaseIndex = baseIndex;
            this.nextIndex = baseIndex;
        }
        #endregion

        public void Add(int index, T item)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        void ICollection<T>.Add(T item)
            => Add(this.nextIndex, item);

        /// <inheritdoc />
        void IList<T>.Insert(int index, T item)
            => Add(index, item);

        void ICollection<KeyValuePair<Int32, T>>.Add(KeyValuePair<int, T> item)
            => Add(item.Key, item.Value);

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<Int32, T>.Remove(int index)
            => RemoveAt(index);

        void IList<T>.RemoveAt(int index)
            => RemoveAt(index);

        bool ICollection<KeyValuePair<Int32, T>>.Remove(KeyValuePair<int, T> item)
        {
            // Remove only when value matches as well.
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(int index)
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<int, T> item)
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(int index, out T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<int, T>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator<KeyValuePair<int, T>> IEnumerable<KeyValuePair<int, T>>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        /// <summary>
        /// Gets the index of the range that contains the specified index.
        /// </summary>
        /// <param name="index">The index to look for.</param>
        /// <returns>The index of the range that contains the index; or -1 when not found.</returns>
        private int GetRangeIndex(int index)
        {
            // Gets the index of the range that starts at or before `index`.
            int rangeIndex = this.offsets.BinarySearch(index);
            if (rangeIndex < 0) rangeIndex = (~rangeIndex) - 1;

            if (rangeIndex < 0 || rangeIndex >= this.ranges.Count)
            {
                // Index not found.
                return -1;
            }

            if (index >= this.offsets[rangeIndex] + this.ranges[rangeIndex].Length)
            {
                // Index not in range.
                return -1;
            }

            return rangeIndex;
        }

        /// <summary>
        /// A range of subsequent elements.
        /// </summary>
        private struct ElementRange
        {
            /// <summary>
            /// Gets the zero-based offset of the first element in the range.
            /// </summary>
            /// <value>The zero-based offset of the first element.</value>
            public int Offset { get; }

            /// <summary>
            /// Gets the number of elements in the range.
            /// </summary>
            /// <value>The number of elements.</value>
            public int Length => this.Elements.Length;

            /// <summary>
            /// Gets the array of elements in the range.
            /// </summary>
            /// <value>The array.</value>
            public T[] Elements { get; }

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="ElementRange"/> class.
            /// </summary>
            /// <param name="offset">The zero-based offset of the first element in the range.</param>
            /// <param name="elements">The elements in the range.</param>
            public ElementRange(int offset, T[] elements)
            {
                #region Contract
                Debug.Assert(elements != null);
                #endregion

                this.Offset = offset;
                this.Elements = elements;
            }
            #endregion
        }
    }
}
