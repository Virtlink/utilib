using Xunit;
using System;
using System.Linq;

namespace Virtlink.Utilib.Collections.Graphs
{
	/// <summary>
    /// Tests the <see cref="TopologicalTraversal"/> class.
    /// </summary>
	public sealed class TopologicalTraversalTests
	{
		/// <summary>
		/// Creates the traversal algorithm.
		/// </summary>
		/// <returns>The algorithm.</returns>
		private ITraversal<Node> Create()
		{
			return new TopologicalTraversal.LambdaTraversal<Node>(node => node.Children);
		}
		
		[Fact]
		public void ShouldReturnATopologicalTraversalSequence_WhenTheGraphIsOneNode()
		{
			// Arrange
			var traversal = Create();
			var root = new Node("root");

			// Act
			var nodes = traversal.Traverse(root).ToArray();

			// Assert
			Assert.Equal(new[] { root }, nodes);
		}
		
		[Fact]
		public void ShouldReturnATopologicalTraversalSequence_WhenTheGraphIsATree()
		{
			// Arrange
			var traversal = Create();
			var k = new Node("K");
			var j = new Node("J");
			var i = new Node("I");
			var h = new Node("H");
			var g = new Node("G");
			var f = new Node("F").WithChildren(j, k);
			var e = new Node("E");
			var d = new Node("D").WithChildren(h, i);
			var c = new Node("C").WithChildren(f, g);
			var b = new Node("B");
			var a = new Node("A").WithChildren(d, e);
			var root = new Node("root").WithChildren(a, b, c);

			//         root
			//         / | \ 
			//        A  B  C
			//       /|     |\
			//      D E     F G
			//     /|       |\
			//    H I       J K

			// Act
			var nodes = traversal.Traverse(root).ToArray();

			// Assert
			Assert.Equal(new[] { root, a, b, c, d, e, f, g, h, i, j, k }, nodes);
		}

		[Fact]
		public void ShouldReturnATopologicalTraversalSequence_WhenTheGraphIsADAG()
		{
			// Arrange
			var traversal = Create();
			var h = new Node("H");
			var g = new Node("G");
			var f = new Node("F");
			var e = new Node("E").WithChildren(g);
			var d = new Node("D").WithChildren(f, g, h);
			var c = new Node("C").WithChildren(e, h);
			var b = new Node("B").WithChildren(d, e);
			var a = new Node("A").WithChildren(d);
			var root = new Node("root").WithChildren(a, b, c);

			//       root
			//      / |  \
			//     A  B   C
			//     | / \ /|
			//     D    E |
			//     ||\  | |
			//     || \ | |
			//     ||  \| |
			//     |\   \ |
			//     | \ / \|
			//     F  G   H

			// Act
			var nodes = traversal.Traverse(root).ToArray();

			// Assert
			Assert.Equal(new[] { root, a, b, c, d, e, h, f, g }, nodes);
		}
		
		[Fact]
		public void ShouldThrowInvalidOperationException_WhenTheGraphHasCycles()
		{
			// Arrange
			var traversal = Create();
			var a = new Node("A");
			var e = new Node("E");
			var d = new Node("D");
			var c = new Node("C").WithChildren(a, e);
			var b = new Node("B").WithChildren(c, d);
			a.WithChildren(b);

			//    A --> B
			//    ^    /|
			//    |   / |
			//    |  /  |
			//    | /   V
			//    C<    D
			//    |
			//    V
			//    E

			// Act
			var exception = Record.Exception(() =>
			{
				traversal.Traverse(a).ToArray();
			});

            // Assert
		    Assert.IsType<InvalidOperationException>(exception);
		}
	}
}
