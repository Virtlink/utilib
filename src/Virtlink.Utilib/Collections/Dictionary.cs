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
            return EmptyDictionary<TKey, TValue>.Instance;
        }

        /// <summary>
        /// An implementation for an empty dictionary.
        /// </summary>
        /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
        /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
        private sealed class EmptyDictionary<TKey, TValue> : IDictionary<TKey, TValue>,
            IReadOnlyDictionary<TKey, TValue>
        {
            public static EmptyDictionary<TKey, TValue> Instance { get; } = new EmptyDictionary<TKey, TValue>();

            /// <inheritdoc cref="IReadOnlyCollection{T}.Count" />
            public int Count => 0;

            /// <inheritdoc />
            public bool IsReadOnly => true;

            /// <inheritdoc />
            ICollection<TValue> IDictionary<TKey, TValue>.Values
                => (ICollection<TValue>)Collection.Empty<TValue>();

            /// <inheritdoc />
            ICollection<TKey> IDictionary<TKey, TValue>.Keys
                => (ICollection<TKey>)Collection.Empty<TKey>();

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
                // ReSharper disable once ValueParameterNotUsed
                set
                {
                    #region Contract
                    if (key == null)
                        throw new ArgumentNullException(nameof(key));
                    #endregion

                    throw new NotSupportedException();
                }
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="EmptyDictionary{TKey,TValue}"/> class.
            /// </summary>
            private EmptyDictionary() { }

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
                => throw new NotSupportedException();

            /// <inheritdoc />
            bool IDictionary<TKey, TValue>.Remove(TKey key)
                => throw new NotSupportedException();

            /// <inheritdoc />
            bool ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
                => throw new NotSupportedException();

            /// <inheritdoc />
            void ICollection<KeyValuePair<TKey, TValue>>.Clear()
                => throw new NotSupportedException();

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
                => false;

            /// <inheritdoc cref="IReadOnlyDictionary{TKey,TValue}.ContainsKey" />
            public bool ContainsKey(TKey key)
            {
                #region Contract
                if (key == null)
                    throw new ArgumentNullException(nameof(key));
                #endregion

                return false;
            }

            /// <inheritdoc cref="IReadOnlyDictionary{TKey,TValue}.TryGetValue" />
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
                => List.Empty<KeyValuePair<TKey, TValue>>().GetEnumerator();

            /// <inheritdoc />
            IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();

            /// <inheritdoc />
            public IEnumerable<TKey> Keys
                => List.Empty<TKey>();

            /// <inheritdoc />
            public IEnumerable<TValue> Values
                => List.Empty<TValue>();

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
        }
    }
}