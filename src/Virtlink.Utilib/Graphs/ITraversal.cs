using System.Collections.Generic;

namespace Virtlink.Utilib.Graphs
{
	/// <summary>
	/// A graph traversal algorithm.
	/// </summary>
	public interface ITraversal<T>
	{
		/// <summary>
		/// Traverses the graph, starting at the specified root.
		/// </summary>
		/// <param name="root">The root at which to start the traversal.</param>
		/// <returns>An enumerable sequence of nodes.</returns>
		IEnumerable<T> Traverse(T root);
	}
}
