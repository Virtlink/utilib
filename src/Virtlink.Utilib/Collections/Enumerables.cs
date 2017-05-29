using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Functions for working with enumerables.
    /// </summary>
    public static class Enumerables
    {
        /// <summary>
        /// Wraps the enumerable in a <see cref="SmartList{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="enumerable">The numerable to wrap.</param>
        /// <returns>The wrapped enumerable.</returns>
        /// <remarks>
        /// The smart list tries to not fully enumerate the given enumerable whenever possible,
        /// and will ensure the enumerable is enumerated only once.
        /// </remarks>
        public static SmartList<T> AsSmartList<T>(this IEnumerable<T> enumerable)
        {
            #region Contract
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            #endregion

            return new SmartList<T>(enumerable);
        }

        /// <summary>
        /// Attempts to get the number of elements in the enumerable,
        /// only if it can be determined efficiently.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable for which to get the count.</param>
        /// <returns>The number of elements;
        /// or <see langword="null"/> when it could not be determined
        /// without enumerating all elements.</returns>
        public static int? TryGetCount<T>([NoEnumeration] IEnumerable<T> enumerable)
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
        public static int? TryGetCount([NoEnumeration] IEnumerable enumerable)
        {
            #region Contract
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            #endregion

            var collection = enumerable as ICollection;
            return collection?.Count;
        }

        /// <summary>
        /// Returns the elements of the first sequence, or the elements of the second sequence when the first
        /// sequence is empty.
        /// </summary>
        /// <typeparam name="T">The type of elements in the sequences.</typeparam>
        /// <param name="source">The first sequence.</param>
        /// <param name="otherwise">The second sequence, only to be returned when the first sequence is empty.</param>
        /// <returns>The resulting enumerable.</returns>
        public static IEnumerable<T> OrIfEmpty<T>(this IEnumerable<T> source, IEnumerable<T> otherwise)
        {
            #region Contract
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (otherwise == null)
                throw new ArgumentNullException(nameof(otherwise));
            #endregion

            IEnumerable<T> Enumerator()
            {
                using (var enumerator = source.GetEnumerator())
                {
                    if (enumerator.MoveNext())
                    {
                        do
                        {
                            yield return enumerator.Current;
                        } while (enumerator.MoveNext());
                    }
                    else
                    {
                        foreach (var e in otherwise)
                        {
                            yield return e;
                        }
                    }
                }
            }

            return Enumerator();
        }
    }
}