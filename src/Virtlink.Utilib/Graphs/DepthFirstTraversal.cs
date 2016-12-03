using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Virtlink.Utilib.Graphs
{
	/// <summary>
	/// Depth-first pre-order traversal.
	/// </summary>
	public abstract class DepthFirstTraversal<T> : Traversal<T>
	{
		/// <inheritdoc />
		public override IEnumerable<T> Traverse(T root)
		{
			#region Contract
			if (root == null)
				throw new ArgumentNullException(nameof(root));
			#endregion

			var visited = new HashSet<T>();
			var toVisit = new Stack<T>();
			toVisit.Push(root);

			while (toVisit.Count > 0)
			{
				var node = toVisit.Pop();
				visited.Add(node);
				if (IsReturned(node, root))
					yield return node;
				if (IsTraversed(node, root))
				{
					foreach(var child in GetChildren(node).Reverse())
					{
						Debug.Assert(child != null);

						if (!visited.Contains(child))
							toVisit.Push(child);
					}
				}
			}
		}
	}

	/// <summary>
	/// Depth-first pre-order traversal.
	/// </summary>
	public static partial class DepthFirstTraversal
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
