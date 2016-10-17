using System;
using System.Collections;
using System.Collections.Generic;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Functions for working with dictionaries.
    /// </summary>
    public static class Dictionary
    {
        /// <summary>
		/// Returns a read-only empty dictionary.
		/// </summary>
		/// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
		/// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
		/// <returns>The read-only empty dictionary.</returns>
		public static IReadOnlyDictionary<TKey, TValue> Empty<TKey, TValue>()
        {
            return EmptyDictionaryClass<TKey, TValue>.Instance;
        }

        /// <summary>
        /// Generic class for an empty array instance.
        /// </summary>
		/// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
		/// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        private static class EmptyDictionaryClass<TKey, TValue>
        {
            /// <summary>
            /// Gets an empty dictionary instance.
            /// </summary>
            /// <value>The empty dictionary instance.</value>
            public static IReadOnlyDictionary<TKey, TValue> Instance { get; } = new EmptyDictionary<TKey, TValue>();
        }

        /// <summary>
        /// An implementation for an empty dictionary.
        /// </summary>
		/// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
		/// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        private sealed class EmptyDictionary<TKey, TValue> : IDictionary<TKey, TValue>, IReadOnlyDictionary<TKey, TValue>
        {
            /// <inheritdoc />
            public int Count => 0;

            /// <inheritdoc />
            public bool IsReadOnly => true;

            /// <inheritdoc />
            public IEnumerable<TKey> Keys => List.Empty<TKey>();

            /// <inheritdoc />
            ICollection<TValue> IDictionary<TKey, TValue>.Values
            {
                get { throw new NotImplementedException(); }
            }

            /// <inheritdoc />
            ICollection<TKey> IDictionary<TKey, TValue>.Keys
            {
                get { throw new NotImplementedException(); }
            }

            /// <inheritdoc />
            public IEnumerable<TValue> Values => List.Empty<TValue>();

            /// <inheritdoc />
            public TValue this[TKey key]
            {
                get
                {
                    #region Contract
                    if (key == null)
                        throw new ArgumentNullException(nameof(key));
                    #endregion

                    throw new KeyNotFoundException("Key not found.");
                }
            }

            /// <inheritdoc />
            TValue IDictionary<TKey, TValue>.this[TKey key]
            {
                get
                {
                    #region Contract
                    if (key == null)
                        throw new ArgumentNullException(nameof(key));
                    #endregion

                    throw new KeyNotFoundException("Key not found.");
                }
                set
                {
                    #region Contract
                    if (key == null)
                        throw new ArgumentNullException(nameof(key));
                    #endregion

                    throw new NotSupportedException();
                }
            }

            /// <inheritdoc />
            void IDictionary<TKey, TValue>.Add(TKey key, TValue value)
            {
                #region Contract
                if (key == null)
                    throw new ArgumentNullException(nameof(key));
                #endregion

                throw new NotSupportedException();
            }

            /// <inheritdoc />
            void ICollection<KeyValuePair<TKey, TValue>>.Add(KeyValuePair<TKey, TValue> item)
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc />
            bool IDictionary<TKey, TValue>.Remove(TKey key)
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc />
            bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc />
            void ICollection<KeyValuePair<TKey, TValue>>.Clear()
            {
                throw new NotSupportedException();
            }

            /// <inheritdoc />
            public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
            {
                #region Contract
                if (array == null)
                    throw new ArgumentNullException(nameof(array));
                if (arrayIndex < 0 || arrayIndex > array.Length)
                    throw new ArgumentOutOfRangeException(nameof(arrayIndex));
                if (array.Length - arrayIndex < 0)
                    throw new ArgumentOutOfRangeException(nameof(arrayIndex));
                #endregion

                // Nothing to do.
            }

            /// <inheritdoc />
            public bool Contains(KeyValuePair<TKey, TValue> item)
            {
                return false;
            }

            /// <inheritdoc />
            public bool ContainsKey(TKey key)
            {
                #region Contract
                if (key == null)
                    throw new ArgumentNullException(nameof(key));
                #endregion

                return false;
            }

            /// <inheritdoc />
            public bool TryGetValue(TKey key, out TValue value)
            {
                #region Contract
                if (key == null)
                    throw new ArgumentNullException(nameof(key));
                #endregion

                value = default(TValue);
                return false;
            }

            /// <inheritdoc />
            public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
            {
                return List.Empty<KeyValuePair<TKey, TValue>>().GetEnumerator();
            }

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
