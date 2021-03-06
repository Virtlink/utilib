﻿using System.Collections.Generic;
using JetBrains.Annotations;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// A read-only set.
    /// </summary>
    /// <typeparam name="T">The type of elements in the set.</typeparam>
    public interface IReadOnlySet<T> : IReadOnlyCollection<T>
    {
        /// <summary>
        /// Determines whether the specified item is contained in the set.
        /// </summary>
        /// <param name="item">The item to look for.</param>
        /// <returns><see langword="true"/> when the item is in the set;
        /// otherwise, <see langword="false"/>.</returns>
        [Pure]
        bool Contains(T item);

        /// <summary>
        /// Determines whether the set contains a specified value.
        /// </summary>
        /// <param name="equalValue">The value to search for.</param>
        /// <param name="actualValue">The matching value from the set, if found;
        /// otherwise, <paramref name="equalValue"/> if there are no matches.</param>
        /// <returns><see langword="true"/> if a matching value was found;
        /// otherwise, <see langword="false"/>.</returns>
        [Pure]
        bool TryGetValue(T equalValue, out T actualValue);

        /// <summary>
        /// Determines whether the specified collection is a proper subset of this set.
        /// </summary>
        /// <param name="other">The collection.</param>
        /// <returns><see langword="true"/> when the specified collection is a proper subset
        /// of this set; otherwise, <see langword="false"/>.</returns>
        [Pure]
        bool IsProperSubsetOf(IEnumerable<T> other);

        /// <summary>
        /// Determines whether the specified collection is a proper superset of this set.
        /// </summary>
        /// <param name="other">The collection.</param>
        /// <returns><see langword="true"/> when the specified collection is a proper superset
        /// of this set; otherwise, <see langword="false"/>.</returns>
        [Pure]
        bool IsProperSupersetOf(IEnumerable<T> other);

        /// <summary>
        /// Determines whether the specified collection is a subset of this set.
        /// </summary>
        /// <param name="other">The collection.</param>
        /// <returns><see langword="true"/> when the specified collection is a subset
        /// of this set; otherwise, <see langword="false"/>.</returns>
        [Pure]
        bool IsSubsetOf(IEnumerable<T> other);

        /// <summary>
        /// Determines whether the specified collection is a superset of this set.
        /// </summary>
        /// <param name="other">The collection.</param>
        /// <returns><see langword="true"/> when the specified collection is a superset
        /// of this set; otherwise, <see langword="false"/>.</returns>
        [Pure]
        bool IsSupersetOf(IEnumerable<T> other);

        /// <summary>
        /// Determines whether the specified collection overlaps this set.
        /// </summary>
        /// <param name="other">The collection.</param>
        /// <returns><see langword="true"/> when the specified collection
        /// overlaps this set; otherwise, <see langword="false"/>.</returns>
        [Pure]
        bool Overlaps(IEnumerable<T> other);

        /// <summary>
        /// Determines whether this set and the specified collection are equal.
        /// </summary>
        /// <param name="other">The collection.</param>
        /// <returns><see langword="true"/> when the specified collection is equal
        /// to this set; otherwise, <see langword="false"/>.</returns>
        [Pure]
        bool SetEquals(IEnumerable<T> other);
    }
}