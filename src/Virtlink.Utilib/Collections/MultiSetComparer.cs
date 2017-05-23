using System;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Compares two multi-sets (unordered collections which may contain duplicates)
    /// for equality.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sets.</typeparam>
    public sealed class MultiSetComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        /// <summary>
        /// Gets the default instance of the <see cref="MultiSetComparer{T}"/>.
        /// </summary>
        /// <returns>The default instance of the <see cref="MultiSetComparer{T}"/> class
        /// for type <typeparamref name="T"/>.</returns>
        public static MultiSetComparer<T> Default { get; } = new MultiSetComparer<T>();

        /// <summary>
        /// The comparer to use to compare elements.
        /// </summary>
        private readonly IEqualityComparer<T> elementComparer;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiSetComparer{T}"/> class.
        /// </summary>
        public MultiSetComparer()
            : this(EqualityComparer<T>.Default)
        {
            /* Nothing to do. */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiSetComparer{T}"/> class.
        /// </summary>
        /// <param name="elementComparer">The comparer used to compare elements.</param>
        public MultiSetComparer(IEqualityComparer<T> elementComparer)
        {
            #region Contract
            if (elementComparer == null)
                throw new ArgumentNullException(nameof(elementComparer));
            #endregion

            this.elementComparer = elementComparer;
        }
        #endregion

        /// <inheritdoc/>
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (x == null)
                return y == null;

            if (y == null)
                return false;

            if (Object.ReferenceEquals(x, y))
                return true;

            if (MultiSetComparer<T>.HaveMismatchingCounts(x, y))
                return false;

            return !HaveMismatchedElement(x, y);
        }

        /// <inheritdoc/>
        public int GetHashCode(IEnumerable<T> enumerable)
        {
            return enumerable != null ? HashCodeUtils.GetQuickHashCode(enumerable, this.elementComparer) : 0;
        }

        /// <summary>
        /// Compares the number of elements in the two collections, if possible.
        /// </summary>
        /// <param name="x">The first collection.</param>
        /// <param name="y">The second collection.</param>
        /// <returns><see langword="true"/> when the collections have a mismatching
        /// number of elements; otherwise, <see langword="false"/>.</returns>
        private static bool HaveMismatchingCounts([NoEnumeration] IEnumerable<T> x, [NoEnumeration] IEnumerable<T> y)
        {
            #region Contract
            Debug.Assert(x != null);
            Debug.Assert(y != null);
            #endregion

            var xcount = Enumerables.TryGetCount(x);
            var ycount = Enumerables.TryGetCount(y);

            return xcount != null
                   && ycount != null
                   && xcount != ycount;
        }

        /// <summary>
        /// Compares the elements in the collections.
        /// </summary>
        /// <param name="first">The first collection.</param>
        /// <param name="second">The second collection.</param>
        /// <returns><see langword="true"/> when an element does not match between the
        /// two collections; otherwise, <see langword="false"/>.</returns>
        private bool HaveMismatchedElement(IEnumerable<T> first, IEnumerable<T> second)
        {
            #region Contract
            Debug.Assert(first != null);
            Debug.Assert(second != null);
            #endregion

            int firstNullCount;
            int secondNullCount;

            var firstElementCounts = CountElements(first, out firstNullCount);
            var secondElementCounts = CountElements(second, out secondNullCount);

            if (firstNullCount != secondNullCount || firstElementCounts.Count != secondElementCounts.Count)
                return true;

            foreach (var kvp in firstElementCounts)
            {
                var firstElementCount = kvp.Value;
                int secondElementCount;
                secondElementCounts.TryGetValue(kvp.Key, out secondElementCount);

                if (firstElementCount != secondElementCount)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Counts the occurrence of each element.
        /// </summary>
        /// <param name="enumerable">The collection whose elements to count.</param>
        /// <param name="nullsCounted">The number of <see langword="null"/> references counted.</param>
        /// <returns>A dictionary that contains for each element its count.</returns>
        private Dictionary<T, int> CountElements(IEnumerable<T> enumerable, out int nullsCounted)
        {
            #region Contract
            Debug.Assert(enumerable != null);
            #endregion

            var dictionary = new Dictionary<T, int>(this.elementComparer);
            nullsCounted = 0;

            foreach (T element in enumerable)
            {
                if (element != null)
                {
                    int num;
                    dictionary.TryGetValue(element, out num);
                    dictionary[element] = num + 1;
                }
                else
                    nullsCounted += 1;
            }

            return dictionary;
        }
    }
}