using System;
using System.Collections.Generic;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Functions for working with lists.
    /// </summary>
    public static class List
    {
        /// <summary>
        /// Returns a read-only empty list.
        /// </summary>
        /// <typeparam name="T">The type of elements in the list.</typeparam>
        /// <returns>The read-only empty list.</returns>
        public static IReadOnlyList<T> Empty<T>() => Arrays.Empty<T>();

        /// <summary>
        /// Copies elements from one list to another.
        /// </summary>
        /// <typeparam name="T">The type of elements in the lists.</typeparam>
        /// <param name="sourceList">The source list.</param>
        /// <param name="sourceIndex">The source index.</param>
        /// <param name="destinationList">The destination list.</param>
        /// <param name="destinationIndex">The destination index.</param>
        /// <param name="count">The number of elements to copy.</param>
        public static void Copy<T>(IReadOnlyList<T> sourceList, int sourceIndex, IList<T> destinationList,
            int destinationIndex, int count)
        {
            #region Contract
            if (sourceList == null)
                throw new ArgumentNullException(nameof(sourceList));
            if (sourceIndex < 0 || sourceIndex > sourceList.Count)
                throw new ArgumentOutOfRangeException(nameof(sourceIndex));
            if (destinationList == null)
                throw new ArgumentNullException(nameof(destinationList));
            if (destinationIndex < 0 || destinationIndex > destinationList.Count)
                throw new ArgumentOutOfRangeException(nameof(destinationIndex));
            if (count < 0 || sourceIndex + count > sourceList.Count || destinationIndex + count > destinationList.Count)
                throw new ArgumentOutOfRangeException(nameof(count));
            #endregion


            if (sourceIndex < destinationIndex)
            {
                for (int i = count - 1; i >= 0; i--)
                {
                    destinationList[destinationIndex + i] = sourceList[sourceIndex + i];
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    destinationList[destinationIndex + i] = sourceList[sourceIndex + i];
                }
            }
        }

        /// <summary>
        /// Copies elements from one list to another.
        /// </summary>
        /// <typeparam name="T">The type of elements in the lists.</typeparam>
        /// <param name="sourceList">The source list.</param>
        /// <param name="destinationList">The destination list.</param>
        /// <param name="count">The number of elements to copy.</param>
        public static void Copy<T>(IReadOnlyList<T> sourceList, IList<T> destinationList, int count)
            => Copy(sourceList, 0, destinationList, 0, count);
    }
}