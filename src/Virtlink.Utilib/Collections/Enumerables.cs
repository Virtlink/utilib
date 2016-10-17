using System;
using System.Collections;
using System.Collections.Generic;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Functions for working with enumerables.
    /// </summary>
    public static class Enumerables
    {
        /// <summary>
        /// Attempts to get the number of elements in the enumerable,
        /// only if it can be determined efficiently.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable for which tog et the count.</param>
        /// <returns>The number of elements;
        /// or <see langword="null"/> when it could not be determined
        /// without enumerating all elements.</returns>
        public static int? TryGetCount<T>(IEnumerable<T> enumerable)
        {
            #region Contract
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            #endregion

            var collection = enumerable as ICollection<T>;
            if (collection != null)
                return collection.Count;

            var roCollection = enumerable as IReadOnlyCollection<T>;
            if (roCollection != null)
                return roCollection.Count;

            return TryGetCount((IEnumerable)enumerable);
        }

        /// <summary>
        /// Attempts to get the number of elements in the enumerable,
        /// only if it can be determined efficiently.
        /// </summary>
        /// <param name="enumerable">The enumerable for which tog et the count.</param>
        /// <returns>The number of elements;
        /// or <see langword="null"/> when it could not be determined
        /// without enumerating all elements.</returns>
        public static int? TryGetCount(IEnumerable enumerable)
        {
            #region Contract
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            #endregion

            var collection = enumerable as ICollection;
            if (collection != null)
                return collection.Count;

            return null;
        }
    }
}
