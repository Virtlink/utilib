using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Virtlink.Utilib.Graphs
{
	/// <summary>
	/// Breadth-first traversal.
	/// </summary>
	public abstract class BreadthFirstTraversal<T> : Traversal<T>
	{
		/// <inheritdoc />
		public override IEnumerable<T> Traverse(T root)
		{
			#region Contract
			if (root == null)
				throw new ArgumentNullException(nameof(root));
			#endregion

			var visited = new HashSet<T>();
			var toVisit = new Queue<T>();
			toVisit.Enqueue(root);
			visited.Add(root);

			while (toVisit.Count > 0)
			{
				var node = toVisit.Dequeue();
				
				if (IsReturned(node, root))
					yield return node;
				if (IsTraversed(node, root))
				{
					foreach(var child in GetChildren(node))
					{
						Debug.Assert(child != null);

						if (!visited.Contains(child))
						{
							toVisit.Enqueue(child);
							visited.Add(child);
						}
					}
				}
			}
		}
	}

	/// <summary>
	/// Breadth-first traversal.
	/// </summary>
	public static partial class BreadthFirstTraversal
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
