using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
        private readonly IEnumerable<T> collection;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionDebugView{T}"/> class.
        /// </summary>
        public CollectionDebugView(IEnumerable<T> collection)
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
        public T[] Items => this.collection.ToArray();
    }
}
