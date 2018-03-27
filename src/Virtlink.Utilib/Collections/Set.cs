using System;
using System.Collections.Generic;
using System.Text;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Functions for working with sets.
    /// </summary>
    public static class Set
    {
        /// <summary>
        /// Returns a read-only empty set.
        /// </summary>
        /// <typeparam name="T">The type of elements in the set.</typeparam>
        /// <returns>The read-only empty set.</returns>
        public static IReadOnlySet<T> Empty<T>() => (IReadOnlySet<T>)List.Empty<T>();
    }
}
