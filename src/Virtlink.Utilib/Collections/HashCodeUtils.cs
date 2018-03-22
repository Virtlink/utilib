using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Hash code utility functions.
    /// </summary>
    internal static class HashCodeUtils
    {
        /// <summary>
        /// Calculates the hash code of the collection quickly.
        /// </summary>
        /// <param name="enumerable">The collection.</param>
        /// <param name="comparer">The comparer to use.</param>
        public static int GetQuickHashCode<T>(IEnumerable<T> enumerable, IEqualityComparer<T> comparer)
        {
            #region Contract
            Debug.Assert(enumerable != null);
            Debug.Assert(comparer != null);
            #endregion

            int hash = 17;
            unchecked
            {
                // Since addition is commutative, we don't care about the order of the elements.
                foreach (T value in enumerable)
                {
                    hash += (value != null ? comparer.GetHashCode(value) : 42);
                }
            }
            return hash;
        }


        // ReSharper disable once UnusedMember.Loca//l

        /// <summary>
        /// Calculates the hash code of the collection while keeping the number of hash collisions low.
        /// </summary>
        /// <param name="enumerable">The collection.</param>
        /// <param name="comparer">The comparer to use.</param>
        private static int GetExpensiveHashCode<T>(IEnumerable<T> enumerable, IEqualityComparer<T> comparer)
        {
            #region Contract
            Debug.Assert(enumerable != null);
            Debug.Assert(comparer != null);
            #endregion

            int hash = 17;
            unchecked
            {
                // ReSharper disable once LoopCanBeConvertedToQuery
                foreach (T value in enumerable.OrderBy(x => x))
                {
                    hash = hash * 29 + (value != null ? comparer.GetHashCode(value) : 42);
                }
            }
            return hash;
        }
    }
}
