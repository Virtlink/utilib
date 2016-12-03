using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Virtlink.Utilib.Collections;

namespace Virtlink.Utilib.Graphs
{
	/// <summary>
	/// Node class, used for testing graphs.
	/// </summary>
	/// <remarks>
	/// Two nodes are considered equal if their names match.
	/// </remarks>
	public sealed class Node : INode<Node>
	{
		/// <summary>
		/// Gets the name of the node.
		/// </summary>
		public string Name { get; }

		/// <inheritdoc />
		public IReadOnlyCollection<Node> Children { get; private set; } = List.Empty<Node>();

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="Node"/> class.
		/// </summary>
		/// <param name="name">The name of the node.</param>
		public Node(string name)
		{
			this.Name = name;
		}
		#endregion
		
		/// <inheritdoc />
		public bool Equals(Node other)
		{
			if (Object.ReferenceEquals(other, null) ||      // When 'other' is null
				other.GetType() != this.GetType())          // or of a different type
				return false;                               // they are not equal.
			return this.Name == other.Name;
		}

		/// <inheritdoc />
		public override bool Equals(object obj)
		{
			return Equals(obj as Node);
		}

		/// <inheritdoc />
		public override int GetHashCode()
		{
			return this.Name.GetHashCode();
		}

		/// <summary>
		/// Sets the children of this node.
		/// </summary>
		/// <param name="children">The children.</param>
		/// <returns>This node.</returns>
		public Node WithChildren(params Node[] children)
		{
			return WithChildren((IEnumerable<Node>)children);
		}

		/// <summary>
		/// Sets the children of this node.
		/// </summary>
		/// <param name="children">The children.</param>
		/// <returns>This node.</returns>
		public Node WithChildren(IEnumerable<Node> children)
		{
			#region Contract
			if (children == null)
				throw new ArgumentNullException(nameof(children));
			#endregion

			this.Children = children.ToArray();
			return this;
		}

		/// <inheritdoc />
		public override string ToString()
		{
			return this.Name;
		}
	}
}
