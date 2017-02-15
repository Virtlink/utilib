using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Virtlink.Utilib.Diagnostics
{
    /// <summary>
    /// Provides a special view of the collection when using the debugger.
    /// </summary>
    public sealed class CollectionDebugView<T>
    {
        /// <summary>
        /// The collection.
        /// </summary>
        private readonly ICollection<T> collection;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionDebugView{T}"/> class.
        /// </summary>
        public CollectionDebugView(ICollection<T> collection)
        {
            #region Contract
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            #endregion

            this.collection = collection;
        }
        #endregion

        /// <summary>
        /// Gets the array of items to display.
        /// </summary>
        /// <value>An array of items.</value>
        [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public T[] Items
        {
            get
            {
                var array = new T[this.collection.Count];
                this.collection.CopyTo(array, 0);
                return array;
            }
        }
    }
}
