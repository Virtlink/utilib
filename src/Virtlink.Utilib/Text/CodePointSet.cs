using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Virtlink.Utilib.Collections;

namespace Virtlink.Utilib.Text
{
    /// <summary>
    /// A set of code points.
    /// </summary>
    /// <remarks>
    /// This class is not thread-safe.
    /// </remarks>
    public sealed partial class CodePointSet : ISet<CodePoint>, IReadOnlySet<CodePoint>
    {
        /// <summary>
        /// The number of elements in the <see cref="bits"/> array.
        /// </summary>
        private const int BitsLength = 4;

        /// <summary>
        /// The maximum character codepoint stored in the bit array.
        /// Characters above this value are stored in the interval array.
        /// </summary>
        private const int MaxBitCodePoint = BitsLength * sizeof(ulong) * 8 - 1;

        /// <inheritdoc cref="ICollection{T}.Count"/> />
        public int Count { get; private set; }

        /// <inheritdoc />
        bool ICollection<CodePoint>.IsReadOnly => false;

        /// <summary>
        /// Whether the set includes EOF.
        /// </summary>
        private bool hasEof;
        /// <summary>
        /// Bit arrays for characters from 0 to 255.
        /// </summary>
        private ulong[] bits;
        /// <summary>
        /// An array of character intervals.
        /// </summary>
        /// <remarks>
        /// <para>Each value on an even index is the inclusive start of a interval,
        /// each value on an odd index is the exclusive end of a interval.</para>
        /// <para>A binary search for a character will return either an exact index,
        /// or the index of the next greater character.  The character is in the intervals
        /// if either an exact index was found, and the index is even (therefore the
        /// inclusive start of a interval); or the index of the next greater character was
        /// returned, and the index is odd (therefore the exclusive end of a interval).</para>
        /// <para>
        /// The intervals in this list do not overlap or touch, and are ordered from low to high.
        /// The list contains no empty intervals.
        /// </para>
        /// </remarks>
        private int[] intervals;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CodePointSet"/> class.
        /// </summary>
        public CodePointSet()
        : this(false, new ulong[BitsLength], Arrays.Empty<int>()) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodePointSet"/> class.
        /// </summary>
        /// <param name="characters">The characters to include in the set.</param>
        public CodePointSet(IEnumerable<CodePoint> characters)
        {
            #region Contract
            if (characters == null)
                throw new ArgumentNullException(nameof(characters));
            #endregion

            if (characters is CodePointSet charSet)
            {
                // Copy the internal data.
                this.hasEof = charSet.hasEof;
                this.Count = charSet.Count;
                this.bits = charSet.bits.ToArray();
                this.intervals = charSet.intervals.ToArray();
            }
            else
            {
                var charList = characters.OrderBy(c => c).ToList();

                int i = 0;

                // Consume EOF characters.
                for (; i < charList.Count; i++)
                {
                    if (!charList[i].IsEof) break;
                    this.hasEof = true;
                }

                // Set all the characters in the bit arrays.
                var newBits = new ulong[BitsLength];
                for (; i < charList.Count; i++)
                {
                    int c = charList[i].Value;
                    if (c > MaxBitCodePoint) break;
                    SetFromBits(newBits, c);
                }
                this.bits = newBits;

                // Create the intervals.
                if (i < charList.Count)
                {
                    var newIntervals = new List<int>();
                    var start = charList[i].Value;
                    var end = charList[i].Value + 1;
                    i += 1;
                    for (; i < charList.Count; i++)
                    {
                        var c = charList[i].Value;

                        if (c == end)
                        {
                            // Continue the interval.
                            end = c + 1;
                        }
                        else if (c > end)
                        {
                            // End the previous interval
                            newIntervals.Add(start);
                            newIntervals.Add(end);
                            // and start a new interval.
                            start = c;
                            end = c + 1;
                        }
                    }

                    // End the last interval.
                    newIntervals.Add(start);
                    newIntervals.Add(end);

                    Debug.Assert(newIntervals.Count % 2 == 0);
                    this.intervals = newIntervals.ToArray();
                }
                else
                {
                    this.intervals = Arrays.Empty<int>();
                }

                this.Count = CountCharacters(this.hasEof, this.bits, this.intervals);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodePointSet"/> class.
        /// </summary>
        /// <param name="hasEof">Whether the set includes EOF.</param>
        /// <param name="bits">The bits of the set.</param>
        /// <param name="intervals">The intervals of the set.</param>
        /// <remarks>
        /// This constructor does not make a safety copy of the given arrays.
        /// </remarks>
        private CodePointSet(bool hasEof, ulong[] bits, int[] intervals)
        {
            #region Contract
            Debug.Assert(bits != null);
            Debug.Assert(bits.Length == BitsLength);
            Debug.Assert(intervals != null);
            Debug.Assert(intervals.Length % 2 == 0);
            #endregion

            this.hasEof = hasEof;
            this.bits = bits;
            this.intervals = intervals;
            this.Count = CountCharacters(this.hasEof, this.bits, this.intervals);
        }
        #endregion

        /// <inheritdoc cref="IReadOnlySet{T}.Contains" />
        [Pure]
        public bool Contains(CodePoint c)
        {
            if (c.IsEof)
            {
                return this.hasEof;
            }
            else if (c.Value <= MaxBitCodePoint)
            {
                // For all characters below 256 we can simply test whether the corresponding
                // bit in the bits array is on.
                return GetFromBits(this.bits, c.Value);
            }
            else if (this.intervals != null)
            {
                // For characters at 256 and above, we do a binary search.
                int index = Array.BinarySearch(this.intervals, c.Value);
                return (index >= 0 && (index % 2) == 0)     // Exact index found is the start of a interval.
                    || (index < 0 && (~index % 2) == 1);    // Greater index found is the end of a interval.
            }
            else
            {
                return false;
            }
        }

        /// <inheritdoc />
        [Pure]
        public bool TryGetValue(CodePoint equalValue, out CodePoint actualValue)
        {
            bool contained = Contains(equalValue);
            actualValue = contained ? equalValue : default(CodePoint);
            return contained;
        }

        /// <inheritdoc />
        public void Clear()
        {
            this.hasEof = false;
            this.bits = new ulong[BitsLength];
            this.intervals = Arrays.Empty<int>();
            this.Count = 0;
        }

        /// <inheritdoc />
        void ICollection<CodePoint>.Add(CodePoint item)
            => Add(item);

        /// <inheritdoc />
        public bool Add(CodePoint item)
        {
            if (Contains(item))
                return false;

            UnionWith(Enumerables.Of(item));
            return true;
        }

        /// <summary>
        /// Adds a range of elements to this code point set.
        /// </summary>
        /// <param name="from">The inclusive start of the range.</param>
        /// <param name="until">The exclusive end of the range.</param>
        /// <returns>A new code point set with the range added,
        /// or this set if the elements are already in the set.</returns>
        public void AddRange(CodePoint from, CodePoint until)
            // TODO: This can be may more efficient.
            => UnionWith(Enumerable.Range(from.Value, until - from).Select(v => new CodePoint(v)));


        /// <inheritdoc />
        public bool Remove(CodePoint item)
        {
            if (!Contains(item))
                return false;

            ExceptWith(Enumerables.Of(item));
            return true;
        }

        /// <inheritdoc />
        public void CopyTo(CodePoint[] array, int arrayIndex)
        {
            #region Contract
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (arrayIndex < 0 || arrayIndex + this.Count > array.Length)
                throw new ArgumentOutOfRangeException(nameof(array));
            #endregion

            int i = arrayIndex;
            foreach (var element in this)
            {
                array[i] = element;
                i += 1;
            }
        }

        /// <inheritdoc />
        [Pure]
        public IEnumerator<CodePoint> GetEnumerator()
        {
            // Yield an EOF character, if present.
            if (this.hasEof)
            {
                yield return CodePoint.Eof;
            }
            // Yield a character for each bit that is set in the bit array.
            for (int i = 0; i < BitsLength; i++)
            {
                var b = this.bits[i];
                for (int j = 0; j < 64; j++)
                {
                    if ((b & (1UL << j)) != 0)
                        yield return new CodePoint(i * 64 + j);
                }
            }
            // Yield a character for each element in each interval.
            if (this.intervals != null)
            {
                for (int i = 0; i < this.intervals.Length; i += 2)
                {
                    int start = this.intervals[i + 0];
                    int end = this.intervals[i + 1];
                    foreach (var c in Enumerable.Range(start, end - start).Select(c => new CodePoint(c)))
                        yield return c;
                }
            }
        }

        /// <inheritdoc />
        [Pure]
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        

        /// <summary>
        /// Determines whether the specified character is set in the bit array.
        /// </summary>
        /// <param name="bits">The bits array to modify.</param>
        /// <param name="c">The character to test.</param>
        /// <returns><see langword="true"/> when it is set in the bit array;
        /// otherwise, <see langword="false"/>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool GetFromBits(ulong[] bits, int c)
        {
            #region Contract
            Debug.Assert(bits != null);
            Debug.Assert(bits.Length == BitsLength);
            Debug.Assert(c <= MaxBitCodePoint);
            #endregion

            return (bits[c >> 6] & 1UL << (c & 0x3F)) != 0;
        }

        /// <summary>
        /// Sets the specified character in the bit array.
        /// </summary>
        /// <param name="bits">The bits array to modify.</param>
        /// <param name="c">The character to set.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetFromBits(ulong[] bits, int c)
        {
            #region Contract
            Debug.Assert(bits != null);
            Debug.Assert(bits.Length == BitsLength);
            Debug.Assert(c <= MaxBitCodePoint);
            #endregion

            bits[c >> 6] |= 1UL << (c & 0x3F);
        }

        /// <summary>
        /// Unsets the specified character in the bit array.
        /// </summary>
        /// <param name="bits">The bits array to modify.</param>
        /// <param name="c">The character to unset.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void UnsetFromBits(ulong[] bits, int c)
        {
            #region Contract
            Debug.Assert(bits != null);
            Debug.Assert(bits.Length == BitsLength);
            Debug.Assert(c <= MaxBitCodePoint);
            #endregion

            bits[c >> 6] &= ~(1UL << (c & 0x3F));
        }

        /// <summary>
        /// Counts the number of characters in the character set.
        /// </summary>
        /// <param name="hasEof">Whether EOF is included.</param>
        /// <param name="bits">The bit set.</param>
        /// <param name="intervals">The character intervals.</param>
        /// <returns>The number of characters in the set.</returns>
        private static int CountCharacters(bool hasEof, ulong[] bits, [CanBeNull] IReadOnlyList<int> intervals)
        {
            #region Contract
            Debug.Assert(bits != null);
            Debug.Assert(bits.Length == BitsLength);
            Debug.Assert(intervals == null || intervals.Count % 2 == 0);
            #endregion

            return (hasEof ? 1 : 0)
                 + bits.Sum(BinaryMath.CountSetBits)
                 + Tupelize(intervals).Sum(p => p.Item2 - p.Item1);
        }

        /// <summary>
        /// Compares this character set to the specified character set.
        /// </summary>
        /// <param name="other">The other character set.</param>
        /// <returns>The comparison result.</returns>
        private ComparisonResult CompareTo(CodePointSet other)
        {
            ComparisonResult result = ComparisonResult.Equal;

            if (this.hasEof && !other.hasEof) result &= ~ComparisonResult.Subset;
            if (!this.hasEof && other.hasEof) result &= ~ComparisonResult.Superset;

            result = this.bits.ZipEqual(other.bits, (x, y) => new { x, y }).Aggregate(result, (v, p) =>
            {
                if ((p.x & (~p.y)) != 0) v &= ~ComparisonResult.Subset;
                if (((~p.x) & p.y) != 0) v &= ~ComparisonResult.Superset;
                return v;
            });

            result = Fold(this.intervals, other.intervals, result, (_, __, x, y, v) =>
            {
                if (x && !y) v &= ~ComparisonResult.Subset;
                if (!x && y) v &= ~ComparisonResult.Superset;
                return v;
            });

            return result;
        }

        /// <summary>
        /// Specifies the result of comparing two character sets.
        /// </summary>
        [Flags]
        private enum ComparisonResult
        {
            /// <summary>
            /// This set is neither equal, nor a subset, nor a superset
            /// of the specified set.
            /// </summary>
            Unequal = 0,
            /// <summary>
            /// This set is a subset of the specified set.
            /// </summary>
            Subset = 1 << 0,
            /// <summary>
            /// This set is a superset of the specified set.
            /// </summary>
            Superset = 1 << 1,
            /// <summary>
            /// This set is equal to the specified set.
            /// </summary>
            Equal = Subset | Superset,
        }

        /// <summary>
        /// Returns pairs of elements from the given enumerable.
        /// </summary>
        /// <typeparam name="T">The type of elements.</typeparam>
        /// <param name="source">The source enumerable.</param>
        /// <returns>The pairs of elements.</returns>
        /// <remarks>
        /// The enumerable must return an even number of elements.
        /// </remarks>
        private static IEnumerable<Tuple<T, T>> Tupelize<T>(IEnumerable<T> source)
        {
            #region Contract
            Debug.Assert(source != null);
            #endregion

            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var item1 = enumerator.Current;

                    if (!enumerator.MoveNext())
                        throw new InvalidOperationException("The sequence does not hold an even number of elements.");

                    var item2 = enumerator.Current;

                    yield return Tuple.Create(item1, item2);
                }
            }
        }
    }
}
