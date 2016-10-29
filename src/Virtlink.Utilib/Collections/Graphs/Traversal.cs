using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtlink.Utilib.Collections.Graphs
{
	/// <summary>
	/// Base class for traversal algorithms.
	/// </summary>
	public abstract class Traversal<T> : ITraversal<T>
	{
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Traversal{T}"/> class.
		/// </summary>
		protected Traversal()
		{
			// Nothing to do.
		}
		#endregion

		/// <inheritdoc />
		public abstract IEnumerable<T> Traverse(T root);
		
		/// <summary>
		/// Returns whether to return the specified node.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="root">The root node at which the traversal started.</param>
		/// <returns><see langword="true"/> to return the specified node;
		/// otherwise, <see langword="false"/>.</returns>
		protected virtual bool IsReturned(T node, T root)
		{
			return true;
		}

		/// <summary>
		/// Returns whether to traverse the children of the specified node.
		/// </summary>
		/// <param name="node">The node.</param>
		/// <param name="root">The root node at which the traversal started.</param>
		/// <returns><see langword="true"/> to traverse the children of the node;
		/// otherwise, <see langword="false"/>.</returns>
		protected virtual bool IsTraversed(T node, T root)
		{
			return true;
		}

		/// <summary>
		/// Returns the children of the specified node.
		/// </summary>
		/// <param name="node">The node.</param>
		protected abstract IEnumerable<T> GetChildren(T node);
	}
}
