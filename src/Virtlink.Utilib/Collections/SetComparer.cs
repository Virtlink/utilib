using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Compares two sets (unordered collections without duplicates)
    /// for equality.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sets.</typeparam>
    public sealed class SetComparer<T> : IEqualityComparer<IEnumerable<T>>
    {
        /// <summary>
        /// Gets the default instance of the <see cref="SetComparer{T}"/>.
        /// </summary>
        /// <returns>The default instance of the <see cref="SetComparer{T}"/> class
        /// for type <typeparamref name="T"/>.</returns>
        public static SetComparer<T> Default { get; } = new SetComparer<T>();

        /// <summary>
        /// The comparer to use to compare elements.
        /// </summary>
        private readonly IEqualityComparer<T> elementComparer;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SetComparer{T}"/> class.
        /// </summary>
        public SetComparer()
            : this(EqualityComparer<T>.Default)
        {
            /* Nothing to do. */
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetComparer{T}"/> class.
        /// </summary>
        /// <param name="elementComparer">The comparer used to compare elements.</param>
        public SetComparer(IEqualityComparer<T> elementComparer)
        {
            #region Contract
            if (elementComparer == null)
                throw new ArgumentNullException(nameof(elementComparer));
            #endregion

            this.elementComparer = elementComparer;
        }
        #endregion

        /// <inheritdoc/>
        public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
        {
            if (x == null)
                return y == null;

            if (y == null)
                return false;

            if (Object.ReferenceEquals(x, y))
                return true;
            
            return AsHashSet(x).SetEquals(y);
        }

        /// <inheritdoc/>
        public int GetHashCode(IEnumerable<T> enumerable)
        {
            return enumerable != null ? HashCodeUtils.GetQuickHashCode(AsHashSet(enumerable), this.elementComparer) : 0;
        }

        /// <summary>
        /// Converts the specifies enumerable sequence to a hash set, if it isn't one already.
        /// </summary>
        /// <param name="enumerable">The enumerable sequence.</param>
        /// <returns>The hash set.</returns>
        private HashSet<T> AsHashSet(IEnumerable<T> enumerable)
        {
            #region Contract
            Debug.Assert(enumerable != null);
            #endregion

            if (enumerable is HashSet<T> hx && Object.Equals(hx.Comparer, this.elementComparer))
            {
                return hx;
            }
            else if (enumerable is ExtHashSet<T> ehx && Object.Equals(ehx.Comparer, this.elementComparer))
            {
                return ehx.InnerSet;
            }
            else
            {
                return new HashSet<T>(enumerable, this.elementComparer);
            }
        }
    }
}
