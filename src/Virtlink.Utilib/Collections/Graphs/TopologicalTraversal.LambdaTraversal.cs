﻿using System;
using System.Collections.Generic;

namespace Virtlink.Utilib.Collections.Graphs
{
    partial class TopologicalTraversal
    {
        /// <summary>
        /// Topological traversal,
        /// where the children are provided by a lambda function.
        /// </summary>
        internal sealed class LambdaTraversal<T> : TopologicalTraversal<T>
        {
            private readonly Func<T, IReadOnlyCollection<T>> childrenGetter;

            #region Constructors
            /// <summary>
            /// Initializes a new instance of the <see cref="TopologicalTraversal.LambdaTraversal{T}"/> class.
            /// </summary>
            /// <param name="childrenGetter">Function that returns the children of a node.</param>
            public LambdaTraversal(Func<T, IReadOnlyCollection<T>> childrenGetter)
            {
                #region Contract
                if (childrenGetter == null)
                    throw new ArgumentNullException(nameof(childrenGetter));
                #endregion

                this.childrenGetter = childrenGetter;
            }
            #endregion

            /// <inheritdoc />
            protected override IEnumerable<T> GetChildren(T node)
            {
                return this.childrenGetter(node);
            }
        }
    }
}