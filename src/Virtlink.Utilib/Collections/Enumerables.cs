using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Functions for working with enumerables.
    /// </summary>
    public static class Enumerables
    {
        /// <summary>
        /// Returns an empty enumerable.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <returns>The empty enumerable.</returns>
        public static IEnumerable<T> Of<T>()
        {
            return Enumerable.Empty<T>();
        }

        /// <summary>
        /// Returns a enumerable with one value.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The singleton enumerable.</returns>
        public static IEnumerable<T> Of<T>(T value)
        {
            yield return value;
        }

        /// <summary>
        /// Returns a enumerable with two values.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <returns>The enumerable.</returns>
        public static IEnumerable<T> Of<T>(T value1, T value2)
        {
            yield return value1;
            yield return value2;
        }

        /// <summary>
        /// Returns a enumerable with three values.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="value1">The first value.</param>
        /// <param name="value2">The second value.</param>
        /// <param name="value3">The third value.</param>
        /// <returns>The enumerable.</returns>
        public static IEnumerable<T> Of<T>(T value1, T value2, T value3)
        {
            yield return value1;
            yield return value2;
            yield return value3;
        }

        /// <summary>
        /// Returns a enumerable with multiple values.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="values">The values.</param>
        /// <returns>The enumerable.</returns>
        public static IEnumerable<T> Of<T>(params T[] values)
        {
            return values;
        }

        /// <summary>
        /// Returns the enumerable as a list, either by casting it or by wrapping it in a smart list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
        /// <param name="enumerable">The enumerable to wrap.</param>
        /// <returns>The wrapped enumerable.</returns>
        /// <remarks>
        /// The smart list tries to not fully enumerate the given enumerable whenever possible,
        /// and will ensure the enumerable is enumerated only once.
        /// </remarks>
        public static IReadOnlyList<T> AsList<T>(this IEnumerable<T> enumerable)
        {
            #region Contract
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            #endregion

            if (enumerable is IReadOnlyList<T> list)
                return list;
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

            if (enumerable is ICollection<T> collection)
                return collection.Count;

            if (enumerable is IReadOnlyCollection<T> roCollection)
                return roCollection.Count;

            return TryGetCount((IEnumerable) enumerable);
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

        /// <summary>
        /// Zips two sequences together, like Zip, but enforces that both sequences have equal lengths.
        /// </summary>
        /// <typeparam name="T1">The type of elements in the first sequence.</typeparam>
        /// <typeparam name="T2">The type of elements in the second sequence.</typeparam>
        /// <typeparam name="TResult">The result selector.</typeparam>
        /// <returns>The resulting sequence.</returns>
        public static IEnumerable<TResult> ZipEqual<T1, T2, TResult>(
            this IEnumerable<T1> first,
            IEnumerable<T2> second,
            Func<T1, T2, TResult> resultSelector)
        {
            #region Contract
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));
            if (resultSelector == null)
                throw new ArgumentNullException(nameof(resultSelector));
            #endregion

            IEnumerable<TResult> Enumerator()
            {
                using (var e1 = first.GetEnumerator())
                using (var e2 = second.GetEnumerator())
                {
                    while (e1.MoveNext())
                    {
                        if (!e2.MoveNext())
                            throw new InvalidOperationException("Second sequence is shorter than the first.");

                        yield return resultSelector(e1.Current, e2.Current);
                    }
                    if (e2.MoveNext())
                        throw new InvalidOperationException("First sequence is shorter than the second.");
                }
            }

            return Enumerator();
        }
    }
}