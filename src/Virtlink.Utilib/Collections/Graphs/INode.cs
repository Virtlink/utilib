using System.Collections.Generic;

namespace Virtlink.Utilib.Collections.Graphs
{
	/// <summary>
	/// A node in a graph.
	/// </summary>
	/// <typeparam name="T">The type of node.</typeparam>
	public interface INode<out T>
		where T : INode<T>
	{
		/// <summary>
		/// Gets the children of the node.
		/// </summary>
		/// <value>A collection of child nodes.</value>
		IReadOnlyCollection<T> Children { get; }
	}
}
