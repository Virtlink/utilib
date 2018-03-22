using System;
using System.Collections.Generic;
using System.Linq;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Compares two lists (ordered collections which may contain duplicates)
    /// for equality.
    /// </summary>
    /// <typeparam name="T">The type of elements in the lists.</typeparam>
    public sealed class ListComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        private static volatile ListComparer<T> defaultComparer;

        /// <summary>
        /// The comparer to use to compare elements.
        /// </summary>
        private readonly IEqualityComparer<T> elementComparer;

        /// <summary>
        /// Returns a default instance of the <see cref="ListComparer{T}"/>.
        /// </summary>
        /// <returns>The default instance of the <see cref="ListComparer{T}"/> class for type <typeparamref name="T"/>.</returns>
        public static ListComparer<T> Default
        {
            get
            {
                // ReSharper disable once ConvertIfStatementToNullCoalescingExpression
                if (ListComparer<T>.defaultComparer == null)
                    ListComparer<T>.defaultComparer = new ListComparer<T>();
                return ListComparer<T>.defaultComparer;
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ListComparer{T}"/> class.
        /// </summary>
        public ListComparer()
            : this(EqualityComparer<T>.Default)
        {
            /* Nothing to do. */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListComparer{T}"/> class.
        /// </summary>
        /// <param name="elementComparer">The comparer used to compare elements.</param>
        public ListComparer(IEqualityComparer<T> elementComparer)
        {
            #region Contract
            if (elementComparer == null)
                throw new ArgumentNullException(nameof(elementComparer));
            #endregion

            this.elementComparer = elementComparer;
        }
        #endregion

        /// <inheritdoc />
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (x == null)
                return y == null;

            if (y == null)
                return false;

            if (Object.ReferenceEquals(x, y))
                return true;

            return x.SequenceEqual(y, this.elementComparer);
        }

        /// <inheritdoc />
        public int GetHashCode(IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return 0;

            int hash = 17;
            unchecked
            {
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (T value in enumerable)
                {
                    hash = hash * 29 + (value != null ? this.elementComparer.GetHashCode(value) : 42);
                }
            }
            return hash;
        }
    }
}