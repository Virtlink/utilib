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
    }
}