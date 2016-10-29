using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Virtlink.Utilib.Collections.Graphs
{
	/// <summary>
	/// Depth-first post-order traversal.
	/// </summary>
	public abstract class PostOrderTraversal<T> : Traversal<T>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="PostOrderTraversal{T}"/> class.
		/// </summary>
		protected PostOrderTraversal()
		{
			// Nothing to do.
		}
		#endregion

		/// <inheritdoc />
		public override IEnumerable<T> Traverse(T root)
		{
			#region Contract
			if (root == null)
				throw new ArgumentNullException(nameof(root));
			#endregion

			var toVisit = new Stack<T>();
			var visitedAncestors = new Stack<T>();
			var visited = new HashSet<T>();

			toVisit.Push(root);
			while (toVisit.Count > 0)
			{
				var node = toVisit.Peek();
				visited.Add(node);

				bool isVisited = Object.Equals(visitedAncestors.PeekOrDefault(), node);

				if (!isVisited && IsTraversed(node, root))
				{
					// First visit (down).
					var children = GetChildren(node);
					visitedAncestors.Push(node);

					foreach (var child in children.Reverse())
					{
						Debug.Assert(child != null);

						if (!visited.Contains(child))
							toVisit.Push(child);
					}
				}
				else
				{
					if (isVisited)
					{
						// Second visit (up).
						visitedAncestors.Pop();
					}

					// End of visit.
					if (IsReturned(node, root))
						yield return node;
					toVisit.Pop();
				}
			}
		}
	}

	/// <summary>
	/// Depth-first traversal.
	/// </summary>
	public static partial class PostOrderTraversal
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

			return new PostOrderTraversal.LambdaTraversal<T>(childrenGetter).Traverse(root);
		}
	}
}
