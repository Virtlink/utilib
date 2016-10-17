using System;
using System.Collections.Generic;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Functions for working with arrays.
    /// </summary>
    public static class Arrays
    {
        /// <summary>
		/// Returns a read-only empty array.
		/// </summary>
		/// <typeparam name="T">The type of elements in the array.</typeparam>
		/// <returns>The read-only empty array.</returns>
		public static T[] Empty<T>()
        {
            return EmptyArrayClass<T>.Instance;
        }

        /// <summary>
        /// Generic class for an empty array instance.
        /// </summary>
        /// <typeparam name="T">The type of elements in the array.</typeparam>
        private static class EmptyArrayClass<T>
        {
            /// <summary>
            /// Gets an empty array instance.
            /// </summary>
            /// <value>The empty array instance.</value>
            public static T[] Instance { get; } = new T[0];
        }
    }
}
