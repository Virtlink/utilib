﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Virtlink.Utilib.Diagnostics;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// A slice of a read-only list.
    /// </summary>
    [DebuggerTypeProxy(typeof(CollectionDebugView<>))]
    [DebuggerDisplay("Count = {" + nameof(Count) + "}")]
    public sealed class ListSlice<T> : IReadOnlyList<T>
    {
        /// <summary>
        /// The base list.
        /// </summary>
        private readonly IReadOnlyList<T> baseList;

        /// <summary>
        /// The offset in the base list.
        /// </summary>
        private readonly int offset;

        /// <summary>
        /// Gets the number of elements in the list.
        /// </summary>
        /// <value>The number of elements.</value>
        public int Count { get; }

        /// <summary>
        /// Gets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index.</param>
        /// <returns>The element.</returns>
        public T this[int index]
        {
            get
            {
                #region Contract
                if (index < 0 || index >= this.Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                #endregion

                return this.baseList[this.offset + index];
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ListSlice{T}"/> class.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The number of elements.</param>
        public ListSlice(IReadOnlyList<T> list, int offset, int count)
        {
            #region Contract
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (offset < 0 || offset > list.Count)
                throw new ArgumentOutOfRangeException(nameof(offset));
            if (count < 0 || offset + count > list.Count)
                throw new ArgumentOutOfRangeException(nameof(count));
            #endregion

            if (list is ListSlice<T> slice)
            {
                this.baseList = slice.baseList;
                this.offset = slice.offset + offset;
            }
            else
            {
                this.baseList = list;
                this.offset = offset;
            }
            this.Count = count;
        }
        #endregion

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this[i];
            }
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <summary>
    /// Extension methods for the <see cref="ListSlice{T}"/> class.
    /// </summary>
    public static class ListSliceExtensions
    {
        /// <summary>
        /// Takes the first elements from the list.
        /// </summary>
        /// <typeparam name="T">The type of elements.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="count">The number of elements.</param>
        /// <returns>The resulting list.</returns>
        public static IReadOnlyList<T> Take<T>(this IReadOnlyList<T> list, int count)
        {
            #region Contract
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (count < 0 || count > list.Count)
                throw new ArgumentOutOfRangeException(nameof(count));
            #endregion

            return new ListSlice<T>(list, 0, count);
        }

        /// <summary>
        /// Skips the first elements from the list.
        /// </summary>
        /// <typeparam name="T">The type of elements.</typeparam>
        /// <param name="list">The list.</param>
        /// <param name="count">The number of elements.</param>
        /// <returns>The resulting list.</returns>
        public static IReadOnlyList<T> Skip<T>(this IReadOnlyList<T> list, int count)
        {
            #region Contract
            if (list == null)
                throw new ArgumentNullException(nameof(list));
            if (count < 0 || count > list.Count)
                throw new ArgumentOutOfRangeException(nameof(count));
            #endregion

            return new ListSlice<T>(list, count, list.Count - count);
        }
    }
}
