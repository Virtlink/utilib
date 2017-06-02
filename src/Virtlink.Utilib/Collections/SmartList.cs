using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using JetBrains.Annotations;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// A smart list built from an enumerable.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <remarks>
    /// <para>The smart list tries to not fully enumerate the given enumerable whenever possible,
    /// and will ensure the enumerable is enumerated only once.</para>
    /// <para>This class obviously won't work with infinite enumerables.</para>
    /// <para>This class is not thread-safe.</para>
    /// </remarks>
    internal sealed class SmartList<T> : IReadOnlyList<T>
    {
        /// <summary>
        /// The enumerator, or null when we don't have one.
        /// </summary>
        [CanBeNull] private IEnumerator<T> enumerator;
        /// <summary>
        /// The number of elements in the list, or null when we haven't determined it yet.
        /// </summary>
        [CanBeNull] private int? count;
        /// <summary>
        /// Either the enumeration converted to a list, or a mutable List{T} uses to store
        /// the enumeration's elements.
        /// </summary>
        private readonly IReadOnlyList<T> innerList;

        /// <inheritdoc />
        public int Count
        {
            get
            {
                if (this.count == null)
                {
                    // Force full enumeration of the rest of the enumerable.
                    EnumerateRemainder();
                }
                Debug.Assert(this.count != null);
                return (int)this.count;
            }
        }

        /// <inheritdoc />
        public T this[int index]
        {
            get
            {
                #region Contract
                if (index < 0)
                    throw new ArgumentOutOfRangeException(nameof(index));
                if (this.count != null && index >= this.count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                #endregion

                if (!Get(index, out T element))
                {
                    // We hit the end. Index out of bounds.
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                return element;
            }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SmartList{T}"/> class.
        /// </summary>
        /// <param name="enumerable">The enumerable.</param>
        public SmartList(IEnumerable<T> enumerable)
        {
            #region Contract
            if (enumerable == null)
                throw new ArgumentNullException(nameof(enumerable));
            #endregion

            this.innerList = enumerable as IReadOnlyList<T>;
            if (this.innerList != null)
            {
                // We have converted the enumerable to a list.
                // We're done and can simply enumerate the list.
                this.count = this.innerList.Count;
                this.enumerator = null;
            }
            else
            {
                // Maybe the enumerable is actually a collection, list, or set,
                // so we can determine the number of elements cheaply.
                this.count = Enumerables.TryGetCount(enumerable);
                this.innerList = this.count != null ? new List<T>((int)this.count) : new List<T>();
                this.enumerator = enumerable.GetEnumerator();
            }
        }
        #endregion

        /// <summary>
        /// Gets the element with the specified index.
        /// </summary>
        /// <param name="index">The zero-based index.</param>
        /// <param name="element">The element; or the default value if not found.</param>
        /// <returns><see langword="true"/> if found; otherwise, <see langword="false"/>
        /// when the index is out of bounds.</returns>
        private bool Get(int index, out T element)
        {
            #region Contract
            Debug.Assert(index >= 0);
            #endregion
            
            // Do we have this element in the list already? Then return it.
            if (index < this.innerList.Count)
            {
                // We know the elements in the list won't change.
                element = this.innerList[index];
                return true;
            }
            // Otherwise, read elements from the enumerable until we hit the desired index
            // or we run out of elements.
            element = default(T);
            for (int i = this.innerList.Count; i <= index; i++)
            {
                if (!ReadNext(out element))
                {
                    // We hit the end. Index out of bounds.
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Reads the next element from the enumerable.
        /// </summary>
        /// <returns><see langword="true"/> when the next element was successfully read and added to the list;
        /// otherwise, <see langword="false"/> when there are no more elements.</returns>
        private bool ReadNext(out T element)
        {
            if (this.enumerator == null)
            {
                // There are no more elements.
                element = default(T);
                return false;
            }

            int index = this.innerList.Count;
            if (!this.enumerator.MoveNext())
            {
                // No more elements.
                // We have determined the number of elements.
                this.count = index;
                this.enumerator = null;
                Debug.Assert(this.innerList.Count == this.count);
                element = default(T);
                return false;
            }
            element = this.enumerator.Current;
            // The inner list is a mutable list when we weren't able to cast the enumerable to a list.
            ((List<T>)this.innerList).Add(element);
            Debug.Assert(this.innerList.Count == index + 1);
            return true;
        }

        /// <summary>
        /// Enumerates the remainder.
        /// </summary>
        private void EnumerateRemainder()
        {
            for (int i = this.innerList.Count;; i++)
            {
                if (!Get(i, out _))
                    break;
            }
        }

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator()
        {
            int index = 0;
            while (Get(index, out T element))
            {
                yield return element;
                index += 1;
            }
        }

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
