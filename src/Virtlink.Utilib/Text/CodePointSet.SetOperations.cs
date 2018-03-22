using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Virtlink.Utilib.Collections;

namespace Virtlink.Utilib.Text
{
    partial class CodePointSet
    {
        /// <inheritdoc cref="IReadOnlySet{T}.SetEquals" />
        public bool SetEquals(IEnumerable<CodePoint> other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            return SetEquals(other as CodePointSet ?? new CodePointSet(other));
        }

        /// <summary>
        /// Determines whether the current code point set
        /// and the specified collection contain the same elements.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns><see langword="true"/> if the sets are equal;
        /// otherwise, <see langword="false"/>.</returns>
        public bool SetEquals(CodePointSet other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            return CompareTo(other) == ComparisonResult.Equal;
        }

        /// <inheritdoc cref="IReadOnlySet{T}.Overlaps" />
        public bool Overlaps(IEnumerable<CodePoint> other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            return Overlaps(other as CodePointSet ?? new CodePointSet(other));
        }

        /// <summary>
        /// Determines whether the current code point set overlaps with the specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns><see langword="true"/> if the current code point set and the specified collection
        /// share at least one common element; otherwise, <see langword="false"/>.</returns>
        public bool Overlaps(CodePointSet other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            return (this.hasEof && other.hasEof)
                || this.bits.ZipEqual(other.bits, (x, y) => new {x, y}).Aggregate(false, (v, p) => v || (p.x & p.y) != 0)
                || Fold(this.intervals, other.intervals, false, (_, __, x, y, v) => v || x && y);
        }

        /// <inheritdoc cref="IReadOnlySet{T}.IsSubsetOf" />
        public bool IsSubsetOf(IEnumerable<CodePoint> other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            return IsSubsetOf(other as CodePointSet ?? new CodePointSet(other));
        }

        /// <summary>
        /// Determines whether the current code point set is a subset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns><see langword="true"/> if the current set is a subset of the specified collection;
        /// otherwise, <see langword="false"/>.</returns>
        public bool IsSubsetOf(CodePointSet other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            return CompareTo(other).HasFlag(ComparisonResult.Subset);
        }

        /// <inheritdoc cref="IReadOnlySet{T}.IsSupersetOf" />
        public bool IsSupersetOf(IEnumerable<CodePoint> other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            return IsSupersetOf(other as CodePointSet ?? new CodePointSet(other));
        }

        /// <summary>
        /// Determines whether the current code point set is a superset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns><see langword="true"/> if the current set is a superset of the specified collection;
        /// otherwise, <see langword="false"/>.</returns>
        public bool IsSupersetOf(CodePointSet other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            return CompareTo(other).HasFlag(ComparisonResult.Superset);
        }

        /// <inheritdoc cref="IReadOnlySet{T}.IsProperSubsetOf" />
        public bool IsProperSubsetOf(IEnumerable<CodePoint> other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            return IsProperSubsetOf(other as CodePointSet ?? new CodePointSet(other));
        }

        /// <summary>
        /// Determines whether the current code point set is a proper subset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns><see langword="true"/> if the current set is a proper subset of the specified collection;
        /// otherwise, <see langword="false"/>.</returns>
        public bool IsProperSubsetOf(CodePointSet other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            return CompareTo(other) == ComparisonResult.Subset;
        }

        /// <inheritdoc cref="IReadOnlySet{T}.IsProperSupersetOf" />
        public bool IsProperSupersetOf(IEnumerable<CodePoint> other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            return IsProperSupersetOf(other as CodePointSet ?? new CodePointSet(other));
        }

        /// <summary>
        /// Determines whether the current code point set is a proper superset of a specified collection.
        /// </summary>
        /// <param name="other">The collection to compare to the current set.</param>
        /// <returns><see langword="true"/> if the current set is a proper superset of the specified collection;
        /// otherwise, <see langword="false"/>.</returns>
        public bool IsProperSupersetOf(CodePointSet other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            return CompareTo(other) == ComparisonResult.Superset;
        }
        

        /// <inheritdoc />
        public void UnionWith(IEnumerable<CodePoint> other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            UnionWith(other as CodePointSet ?? new CodePointSet(other));
        }

        public void UnionWith(CodePointSet other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            var newEof = this.hasEof | other.hasEof;
            var newBits = this.bits.ZipEqual(other.bits, (a, b) => a | b).ToArray();
            var newIntervals = Filter(this.intervals, other.intervals, (s, e, a, b) => a || b).ToArray();

            this.hasEof = newEof;
            this.bits = newBits;
            this.intervals = newIntervals;
            this.Count = CountCharacters(newEof, newBits, newIntervals);
        }

        /// <inheritdoc />
        public void IntersectWith(IEnumerable<CodePoint> other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            IntersectWith(other as CodePointSet ?? new CodePointSet(other));
        }

        public void IntersectWith(CodePointSet other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            var newEof = this.hasEof & other.hasEof;
            var newBits = this.bits.ZipEqual(other.bits, (a, b) => a & b).ToArray();
            var newIntervals = Filter(this.intervals, other.intervals, (s, e, a, b) => a && b).ToArray();

            this.hasEof = newEof;
            this.bits = newBits;
            this.intervals = newIntervals;
            this.Count = CountCharacters(newEof, newBits, newIntervals);
        }

        /// <inheritdoc />
        public void ExceptWith(IEnumerable<CodePoint> other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            ExceptWith(other as CodePointSet ?? new CodePointSet(other));
        }

        public void ExceptWith(CodePointSet other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            var newEof = this.hasEof && !other.hasEof;
            var newBits = this.bits.ZipEqual(other.bits, (a, b) => a & ~b).ToArray();
            var newIntervals = Filter(this.intervals, other.intervals, (s, e, a, b) => a && !b).ToArray();

            this.hasEof = newEof;
            this.bits = newBits;
            this.intervals = newIntervals;
            this.Count = CountCharacters(newEof, newBits, newIntervals);
        }

        /// <inheritdoc />
        public void SymmetricExceptWith(IEnumerable<CodePoint> other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            SymmetricExceptWith(other as CodePointSet ?? new CodePointSet(other));
        }

        public void SymmetricExceptWith(CodePointSet other)
        {
            #region Contract
            if (other == null)
                throw new ArgumentNullException(nameof(other));
            #endregion

            var newEof = this.hasEof ^ other.hasEof;
            var newBits = this.bits.ZipEqual(other.bits, (a, b) => a ^ b).ToArray();
            var newIntervals = Filter(this.intervals, other.intervals, (s, e, a, b) => a ^ b).ToArray();

            this.hasEof = newEof;
            this.bits = newBits;
            this.intervals = newIntervals;
            this.Count = CountCharacters(newEof, newBits, newIntervals);
        }

        /// <summary>
        /// The interval filter function.
        /// </summary>
        /// <param name="start">The inclusive start of an interval.</param>
        /// <param name="end">The exclusive end of an interval.</param>
        /// <param name="hasX">Whether the interval is present in the first list of intervals.</param>
        /// <param name="hasY">Whether the interval is present in the second list of intervals.</param>
        /// <returns>Whether the interval should be present in the resulting list of intervals.</returns>
        private delegate bool IntervalFilter(int start, int end, bool hasX, bool hasY);

        /// <summary>
        /// Maps the specified function to all the intervals in the two interval lists.
        /// </summary>
        /// <param name="xs">The first list of intervals.</param>
        /// <param name="ys">The second list of intervals.</param>
        /// <param name="filter">The filter function, which returns for an interval with the given
        /// start and end whether it should be present in the result. The boolean inputs to
        /// the function indicate in which of the source interval lists the interval is present.</param>
        /// <returns>The resulting list of intervals, all ordered, merged where possible.</returns>
        /// <remarks>
        /// The intervals are divided at every interval boundary,
        /// such that the resulting intervals do not partially overlap.
        /// </remarks>
        private static IReadOnlyList<int> Filter(IReadOnlyList<int> xs, IReadOnlyList<int> ys, IntervalFilter filter)
        {
            #region Contract
            Debug.Assert(xs != null);
            Debug.Assert(ys != null);
            Debug.Assert(filter != null);
            #endregion

            return Fold(xs, ys, new List<int>(), (s, e, x, y, v) =>
            {
                bool keep = filter(s, e, x, y);
                if (keep != (v.Count % 2 != 0))
                {
                    // Add the interval start or end only if we're opening a new interval
                    // or closing an existing interval.
                    v.Add(s);
                }
                return v;
            }, (s, v) =>
            {
                if (v.Count % 2 != 0)
                {
                    // Close the final interval, if any.
                    v.Add(s);
                }
                Debug.Assert(v.Count % 2 == 0);
                return v;
            });
        }

        /// <summary>
        /// The interval fold function.
        /// </summary>
        /// <typeparam name="T">The type of value being folded.</typeparam>
        /// <param name="start">The inclusive start of an interval.</param>
        /// <param name="end">The exclusive end of an interval.</param>
        /// <param name="hasX">Whether the interval is present in the first list of intervals.</param>
        /// <param name="hasY">Whether the interval is present in the second list of intervals.</param>
        /// <param name="value">The current value.</param>
        /// <returns>The new value.</returns>
        private delegate T IntervalFold<T>(int start, int end, bool hasX, bool hasY, T value);

        /// <summary>
        /// The interval final fold function.
        /// </summary>
        /// <typeparam name="T">The type of value being folded.</typeparam>
        /// <param name="end">The end of the last interval.</param>
        /// <param name="value">The current value.</param>
        /// <returns>The new value.</returns>
        private delegate T IntervalFinalFold<T>(int end, T value);

        /// <summary>
        /// Applies a folding function to the list of intervals.
        /// </summary>
        /// <typeparam name="T">The type of value being folded.</typeparam>
        /// <param name="xs">The first list of intervals.</param>
        /// <param name="ys">The second list of intervals.</param>
        /// <param name="initial">The initial value.</param>
        /// <param name="fold">The folding function.</param>
        /// <returns>The resulting value.</returns>
        private static T Fold<T>(IReadOnlyList<int> xs, IReadOnlyList<int> ys, T initial, IntervalFold<T> fold)
            => Fold(xs, ys, initial, fold, (_, v) => v);

        /// <summary>
        /// Applies a folding function to the list of intervals.
        /// </summary>
        /// <typeparam name="T">The type of value being folded.</typeparam>
        /// <param name="xs">The first list of intervals.</param>
        /// <param name="ys">The second list of intervals.</param>
        /// <param name="initial">The initial value.</param>
        /// <param name="fold">The folding function.</param>
        /// <param name="final">The final fold function.</param>
        /// <returns>The resulting value.</returns>
        private static T Fold<T>(IReadOnlyList<int> xs, IReadOnlyList<int> ys, T initial, IntervalFold<T> fold, IntervalFinalFold<T> final)
        {
            #region Contract
            Debug.Assert(xs != null);
            Debug.Assert(ys != null);
            Debug.Assert(fold != null);
            Debug.Assert(final != null);
            #endregion

            T current = initial;

            // Neither lists has any elements, so we'll return.
            if (xs.Count == 0 && ys.Count == 0) return current;

            // Indices point to the elements in the lists that are greater than or equal to `cursor`.
            int xi = 0;
            int yi = 0;
            // The cursor is the current position.
            int comparison = CompareIntervals(xs, ys, xi, yi, out int cursor);
            if (comparison <= 0) xi += 1;
            if (comparison >= 0) yi += 1;

            while (xi < xs.Count || yi < ys.Count)
            {
                comparison = CompareIntervals(xs, ys, xi, yi, out int nextCursor);

                int start = cursor;
                int end = nextCursor;
                bool hasX = (xi % 2) != 0;
                bool hasY = (yi % 2) != 0;
                current = fold(start, end, hasX, hasY, current);

                if (comparison <= 0) xi += 1;
                if (comparison >= 0) yi += 1;
                cursor = nextCursor;
            }

            current = final(cursor, current);

            return current;
        }

        /// <summary>
        /// Compares the specified elements from the two lists of intervals,
        /// and returns the closest value.
        /// </summary>
        /// <param name="xs">The first list of intervals.</param>
        /// <param name="ys">The second list of intervals.</param>
        /// <param name="xi">The zero-based index of the interval in the first list.</param>
        /// <param name="yi">The zero-based index of the interval in the second list.</param>
        /// <param name="next">The closest value.</param>
        /// <returns>The result of comparing the first value to the second value.</returns>
        /// <remarks>
        /// When an interval from only one of the lists of intervals is available, it is considered to be the closest interval.
        /// </remarks>
        private static int CompareIntervals(IReadOnlyList<int> xs, IReadOnlyList<int> ys, int xi, int yi, out int next)
        {
            #region Contract
            Debug.Assert(xs != null);
            Debug.Assert(ys != null);
            Debug.Assert(xi >= 0);
            Debug.Assert(yi >= 0);
            Debug.Assert(xi < xs.Count || yi < ys.Count);
            #endregion

            int x = xi < xs.Count ? xs[xi] : Int32.MaxValue;
            int y = yi < ys.Count ? ys[yi] : Int32.MaxValue;
            int comparison = x.CompareTo(y);
            if (comparison <= 0) next = x;  // X is less than or equal to Y
            else next = y;                  // Y is less than X.
            return comparison;
        }
    }
}
