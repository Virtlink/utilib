using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// A two-dimensional table.
    /// </summary>
    /// <typeparam name="TRowKey">The type of the row key.</typeparam>
    /// <typeparam name="TColumnKey">The type of the column key.</typeparam>
    /// <typeparam name="TValue">The value.</typeparam>
    public interface IReadOnlyTable<TRowKey, TColumnKey, TValue> : IReadOnlyCollection<Tuple<TRowKey, TColumnKey, TValue>>
    {
        /// <summary>
        /// Gets the value at the specified row/column.
        /// </summary>
        /// <param name="key1">The row key.</param>
        /// <param name="key2">The column key.</param>
        /// <returns>The value.</returns>
        TValue this[TRowKey key1, TColumnKey key2] { get; }

        /// <summary>
        /// Gets the rows in the table.
        /// </summary>
        /// <value>The rows in the table.</value>
        IReadOnlyDictionary<TRowKey, IReadOnlyList<TValue>> Rows { get; }

        /// <summary>
        /// Gets the columns in the table.
        /// </summary>
        /// <value>The columns in the table.</value>
        IReadOnlyDictionary<TColumnKey, IReadOnlyList<TValue>> Columns { get; }

        /// <summary>
        /// Attempts to get a value from the table.
        /// </summary>
        /// <param name="key1">The row key.</param>
        /// <param name="key2">The column key.</param>
        /// <param name="value">The value; or the default value.</param>
        /// <returns><see langword="true"/> when the value was present;
        /// otherwise, <see langword="false"/>.</returns>
        bool TryGetValue(TRowKey key1, TColumnKey key2, out TValue value);

        /// <summary>
        /// Determines whether the table contains a value for the specified keys.
        /// </summary>
        /// <param name="key1">The row key.</param>
        /// <param name="key2">The column key.</param>
        /// <returns><see langword="true"/> when the value was present;
        /// otherwise, <see langword="false"/>.</returns>
        bool ContainsKeys(TRowKey key1, TColumnKey key2);
    }
}
