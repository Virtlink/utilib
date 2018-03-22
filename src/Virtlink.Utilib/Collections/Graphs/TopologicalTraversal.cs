using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Virtlink.Utilib.Collections.Graphs
{
    /// <summary>
    /// Topological traversal.
    /// </summary>
    public abstract class TopologicalTraversal<T> : Traversal<T>
    {
        /// <inheritdoc />
        public override IEnumerable<T> Traverse(T root)
        {
            #region Contract
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            #endregion

            // It is assumed that the root(s) are all and the only nodes
            // that are not children of some node.

            var visited = new HashSet<T>();
            var toVisit = new Queue<T>();
            toVisit.Enqueue(root);

            while (toVisit.Count > 0)
            {
                var node = toVisit.Dequeue();
                visited.Add(node);

                if (IsReturned(node, root))
                    yield return node;
                if (!IsTraversed(node, root))
                    continue;

                foreach (var child in GetChildren(node))
                {
                    Debug.Assert(child != null);

                    if (Object.ReferenceEquals(child, node) || visited.Contains(child))
                        throw new InvalidOperationException("Graph contains cycles.");

                    if (!toVisit.Contains(child))
                        toVisit.Enqueue(child);
                }
            }
        }
    }

    /// <summary>
    /// Topological traversal.
    /// </summary>
    public static partial class TopologicalTraversal
    {
        /// <summary>
        /// Traverses a tree whose nodes implement the <see cref="INode{T}"/> interface.
        /// </summary>
        /// <typeparam name="T">The type of nodes.</typeparam>
        /// <param name="root">The root of the tree.</param>
        /// <returns>An enumerable that returns the tree's nodes
        /// in depth-first pre-order.</returns>
        public static IEnumerable<T> Traverse<T>(T root)
            where T : INode<T>
        {
            #region Contract
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            #endregion

            return Traverse(root, node => node.Children);
        }

        /// <summary>
        /// Traverses a tree where the children of a node are returned by a lambda function.
        /// </summary>
        /// <typeparam name="T">The type of nodes.</typeparam>
        /// <param name="root">The root of the tree.</param>
        /// <param name="childrenGetter">Function that returns the children of the node.</param>
        /// <returns>An enumerable that returns the tree's nodes
        /// in depth-first pre-order.</returns>
        public static IEnumerable<T> Traverse<T>(T root, Func<T, IReadOnlyCollection<T>> childrenGetter)
        {
            #region Contract
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            if (childrenGetter == null)
                throw new ArgumentNullException(nameof(childrenGetter));
            #endregion

            return new LambdaTraversal<T>(childrenGetter).Traverse(root);
        }
    }
}