using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtlink.Utilib.Collections.Graphs
{
	partial class DepthFirstTraversal
	{
		/// <summary>
		/// Depth-first pre-order traversal,
		/// where the children are provided by a lambda function.
		/// </summary>
		internal sealed class LambdaTraversal<T> : DepthFirstTraversal<T>
		{
			private readonly Func<T, IReadOnlyCollection<T>> childrenGetter;

			#region Constructors
			/// <summary>
			/// Initializes a new instance of the <see cref="LambdaTraversal{T}"/> class.
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
