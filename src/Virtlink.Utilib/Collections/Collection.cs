using System.Collections.Generic;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Functions for working with collections.
    /// </summary>
    public static class Collection
    {
        /// <summary>
        /// Returns a read-only empty collection.
        /// </summary>
        /// <typeparam name="T">The type of elements in the collection.</typeparam>
        /// <returns>The read-only empty collection.</returns>
        public static IReadOnlyCollection<T> Empty<T>() => List.Empty<T>();
    }
}