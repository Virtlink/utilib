using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Virtlink.Utilib.Diagnostics;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// A set that's especially useful for small sets.
    /// </summary>
    [DebuggerTypeProxy(typeof(CollectionDebugView<>))]
    [DebuggerDisplay("Count = {" + nameof(Count) + "}")]
    public sealed class ListSet<T> : ISet<T>, IReadOnlySet<T>
    {
        private readonly List<T> innerList = new List<T>();

        /// <summary>
        /// Gets the comparer used to compare elements of the set.
        /// </summary>
        /// <value>The equality comparer.</value>
        public IEqualityComparer<T> Comparer { get; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ListSet{T}"/> class.
        /// </summary>
        public ListSet()
            : this(null, null)
        {
            // Nothing to do.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListSet{T}"/> class.
        /// </summary>
        /// <param name="comparer">The equality comparer to use.</param>
        public ListSet(IEqualityComparer<T> comparer)
            : this(null, comparer)
        {
            // Nothing to do.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListSet{T}"/> class.
        /// </summary>
        /// <param name="elements">The initial elements in the set.</param>
        public ListSet(IEnumerable<T> elements)
            : this(elements, null)
        {
            // Nothing to do.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListSet{T}"/> class.
        /// </summary>
        /// <param name="elements">The initial elements in the set.</param>
        /// <param name="comparer">The equality comparer to use; or <see langword="null"/> to use the default comparer.</param>
        public ListSet(IEnumerable<T> elements, IEqualityComparer<T> comparer)
        {
            // NOTE: We want to encourage the use of the appropriate overloads
            // instead of explicitly allowing users to call these constructors with null arguments,
            // but we don't want to forbid null either as it allows us to gather all the
            // constructor logic in one place.

            this.Comparer = comparer ?? EqualityComparer<T>.Default;

            if (elements != null)
            {
                foreach (var element in elements)
                {
                    Add(element);
                }
            }
        }
        #endregion

        /// <summary>
        /// Attempts to retrieve an equal element from the set.
        /// </summary>
        /// <param name="item">The object to compare to.</param>
        /// <param name="element">The equal element that was in the set;
        /// or the default of <typeparamref name="T"/> if not found.</param>
        /// <returns><see langword="true"/> if the element was found in the set;
        /// otherwise, <see langword="false"/>.</returns>
        public bool TryGet(T item, out T element)
        {
            if (item == null)
            {
                // Not found.
                element = default(T);
                return false;
            }

            int existingIndex = TryGetIndex(item);

            if (existingIndex == -1)
            {
                // Not found.
                element = default(T);
                return false;
            }

            element = this.innerList[existingIndex];
            return true;
        }

        /// <summary>
        /// Gets the index of an equal element from the set.
        /// </summary>
        /// <param name="item">The item to find.</param>
        /// <returns>The zero-based index; or -1 when not found.</returns>
        private int TryGetIndex(T item)
        {
            #region Contract
            Debug.Assert(item != null);
            #endregion

            for (int i = 0; i < this.innerList.Count; i++)
            {
                if (this.Comparer.Equals(item, this.innerList[i]))
                    return i;
            }
            return -1;
        }

        /// <inheritdoc/>
        public int Count => this.innerList?.Count ?? 0;

        /// <inheritdoc/>
        bool ICollection<T>.IsReadOnly => false;

        /// <inheritdoc/>
        public bool Add(T item)
        {
            #region Contract
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            #endregion

            int existingIndex = TryGetIndex(item);

            if (existingIndex != -1)
            {
                // The element is already in the set.
                return false;
            }

            this.innerList.Add(item);
            return true;
        }

        /// <inheritdoc/>
        void ICollection<T>.Add(T item) => Add(item);

        /// <inheritdoc/>
        public bool Remove(T item)
        {
            if (item == null)
                return false;

            int existingIndex = TryGetIndex(item);
            if (existingIndex == -1)
            {
                // No such element.
                return false;
            }

            this.innerList.RemoveAt(existingIndex);
            return true;
        }

        /// <inheritdoc/>
        public void Clear() => this.innerList?.Clear();

        /// <inheritdoc/>
        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                Add(item);
            }
        }

        /// <inheritdoc/>
        public void IntersectWith(IEnumerable<T> other)
        {
            // Mark all elements that we have to keep.
            var marks = new bool[this.innerList.Count];
            foreach (var item in other)
            {
                int index = TryGetIndex(item);
                if (index != -1)
                    marks[index] = true;
            }
            // Remove all elements that we didn't mark.
            for (int i = marks.Length - 1; i >= 0; i--)
            {
                if (!marks[i])
                    this.innerList.RemoveAt(i);
            }
        }

        /// <inheritdoc/>
        public void ExceptWith(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                Remove(item);
            }
        }

        /// <inheritdoc/>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                int index = TryGetIndex(item);
                if (index == -1)
                {
                    // The item was not yet in this set.
                    this.innerList.Add(item);
                }
                else
                {
                    // The item was in both sets.
                    this.innerList.RemoveAt(index);
                }
            }
        }

        /// <inheritdoc/>
        public bool Contains(T item)
        {
            return TryGetIndex(item) != -1;
        }

        /// <inheritdoc/>
        public bool SetEquals(IEnumerable<T> other)
        {
            // Mark all elements that we found in the other set.
            var marks = new bool[this.innerList.Count];
            foreach (var item in other)
            {
                int index = TryGetIndex(item);
                if (index == -1)
                {
                    // Found an element in the other that is not in this.
                    return false;
                }
                marks[index] = true;
            }
            // If we have items we didn't find in the other set
            // we are not equal.
            return marks.All(m => m == true);
        }

        /// <inheritdoc/>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            // Mark all elements that we found in the other set.
            var marks = new bool[this.innerList.Count];
            foreach (var item in other)
            {
                int index = TryGetIndex(item);
                if (index != -1)
                    marks[index] = true;
            }
            // If we have items we didn't find in the other set
            // we are not a subset.
            return marks.All(m => m == true);
        }

        /// <inheritdoc/>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                if (!Contains(item))
                    return false;
            }
            return true;
        }

        /// <inheritdoc/>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return IsSupersetOf(other) && !SetEquals(other);
        }

        /// <inheritdoc/>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return IsSubsetOf(other) && !SetEquals(other);
        }

        /// <inheritdoc/>
        public bool Overlaps(IEnumerable<T> other)
        {
            foreach (var item in other)
            {
                if (Contains(item))
                    return true;
            }
            return false;
        }

        /// <inheritdoc/>
        public void CopyTo(T[] array, int arrayIndex) => this.innerList.CopyTo(array, arrayIndex);

        /// <inheritdoc/>
        public IEnumerator<T> GetEnumerator() => this.innerList.GetEnumerator();

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}