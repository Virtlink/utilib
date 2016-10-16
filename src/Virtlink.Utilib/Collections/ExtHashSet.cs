using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// An extended hash set.
    /// </summary>
    /// <typeparam name="T">The type of elements in the set.</typeparam>
    public sealed class ExtHashSet<T> : ISet<T>, IReadOnlyCollection<T>
    {
        private readonly HashSet<T> innerSet;

        /// <inheritdoc />
        public int Count => this.innerSet.Count;

        /// <inheritdoc />
        bool ICollection<T>.IsReadOnly => ((ICollection<T>)this.innerSet).IsReadOnly;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="ExtHashSet{T}"/> class.
        /// </summary>
        public ExtHashSet()
            : this(null, null)
        {
            // Nothing to do.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtHashSet{T}"/> class.
        /// </summary>
        /// <param name="comparer">The equality comparer to use.</param>
        public ExtHashSet(IEqualityComparer<T> comparer)
            : this(null, comparer)
        {
            // Nothing to do.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtHashSet{T}"/> class.
        /// </summary>
        /// <param name="elements">The initial elements in the set.</param>
        public ExtHashSet(IEnumerable<T> elements)
            : this(elements, null)
        {
            // Nothing to do.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExtHashSet{T}"/> class.
        /// </summary>
        /// <param name="elements">The initial elements in the set.</param>
        /// <param name="comparer">The equality comparer to use; or <see langword="null"/> to use the default comparer.</param>
        public ExtHashSet(IEnumerable<T> elements, IEqualityComparer<T> comparer)
        {
            // NOTE: We want to encourage the use of the appropriate overloads
            // instead of explicitly allowing users to call these constructors with null arguments,
            // but we don't want to forbid null either as it allows us to gather all the
            // constructor logic in one place.

            var innerComparer = new CustomComparer(comparer ?? EqualityComparer<T>.Default);
            this.innerSet = elements != null ? new HashSet<T>(elements, innerComparer) : new HashSet<T>(innerComparer);
        }
        #endregion

        /// <inheritdoc />
        public bool Add(T item) => this.innerSet.Add(item);

        /// <inheritdoc />
        void ICollection<T>.Add(T item) => ((ICollection<T>)this.innerSet).Add(item);

        /// <inheritdoc />
        public bool Remove(T item) => this.innerSet.Remove(item);

        /// <inheritdoc />
        public void Clear() => this.innerSet.Clear();

        /// <inheritdoc />
        public void UnionWith(IEnumerable<T> other) => this.innerSet.UnionWith(other);

        /// <inheritdoc />
        public void IntersectWith(IEnumerable<T> other) => this.innerSet.IntersectWith(other);
        /// <inheritdoc />
        public void ExceptWith(IEnumerable<T> other) => this.innerSet.ExceptWith(other);

        /// <inheritdoc />
        public void SymmetricExceptWith(IEnumerable<T> other) => this.innerSet.SymmetricExceptWith(other);

        /// <summary>
        /// Attempts to retrieve an equal element from the set.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <param name="element">The equal element that was in the set;
        /// or the default of <typeparamref name="T"/> if not found.</param>
        /// <returns><see langword="true"/> if the element was found in the set;
        /// otherwise, <see langword="false"/>.</returns>
        public bool TryGet(T obj, out T element)
        {
            var comparer = (CustomComparer)this.innerSet.Comparer;

            bool contained = this.innerSet.Contains(obj);
            element = contained ? comparer.EqualKey : default(T);

            // Reset here to ensure we don't keep the object unintentionally alive
            // with our reference in the comparer.
            comparer.Reset();

            return contained;
        }

        /// <inheritdoc />
        public bool Contains(T item) => this.innerSet.Contains(item);

        /// <inheritdoc />
        public override bool Equals(object obj) => this.innerSet.Equals(obj);

        /// <inheritdoc />
        public override int GetHashCode() => this.innerSet.GetHashCode();

        /// <inheritdoc />
        public bool SetEquals(IEnumerable<T> other) => this.innerSet.SetEquals(other);

        /// <inheritdoc />
        public bool IsSubsetOf(IEnumerable<T> other) => this.innerSet.IsSubsetOf(other);

        /// <inheritdoc />
        public bool IsSupersetOf(IEnumerable<T> other) => this.innerSet.IsSupersetOf(other);

        /// <inheritdoc />
        public bool IsProperSupersetOf(IEnumerable<T> other) => this.innerSet.IsProperSupersetOf(other);

        /// <inheritdoc />
        public bool IsProperSubsetOf(IEnumerable<T> other) => this.innerSet.IsProperSubsetOf(other);

        /// <inheritdoc />
        public bool Overlaps(IEnumerable<T> other) => this.innerSet.Overlaps(other);

        /// <inheritdoc />
        public void CopyTo(T[] array, int arrayIndex) => this.innerSet.CopyTo(array, arrayIndex);

        /// <inheritdoc />
        public IEnumerator<T> GetEnumerator() => this.innerSet.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)this.innerSet).GetEnumerator();

        /// <inheritdoc />
        public override string ToString() => this.innerSet.ToString();

        /// <summary>
        /// Custom comparer that keeps a matching key.
        /// </summary>
        /// <remarks>
        /// Inspired by Graeme Wicksted:
        /// http://stackoverflow.com/a/39818801/146622
        /// </remarks>
        private sealed class CustomComparer : IEqualityComparer<T>
        {
            private readonly IEqualityComparer<T> baseComparer;

            /// <summary>
            /// Gets the last equal key that was captured.
            /// </summary>
            /// <value>The last equal key;
            /// or the default of <typeparamref name="T"/> if none was found.</value>
            public T EqualKey { get; private set; }

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="CustomComparer"/> class.
            /// </summary>
            public CustomComparer(IEqualityComparer<T> baseComparer)
            {
                #region Contract
                Debug.Assert(baseComparer != null);
                #endregion

                this.baseComparer = baseComparer;
            }
            #endregion

            /// <summary>
            /// Resets the comparer's state.
            /// </summary>
            public void Reset()
            {
                this.EqualKey = default(T);
            }

            /// <inheritdoc />
            public bool Equals(T x, T y)
            {
                if (!this.baseComparer.Equals(x, y))
                    return false;

                EqualKey = x;
                return true;
            }

            /// <inheritdoc />
            public int GetHashCode(T obj)
            {
                return this.baseComparer.GetHashCode(obj);
            }
        }
    }
}
