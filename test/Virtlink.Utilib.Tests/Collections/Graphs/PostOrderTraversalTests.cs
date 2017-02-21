using Xunit;
using System.Linq;

namespace Virtlink.Utilib.Collections.Graphs
{
    /// <summary>
    /// Tests the <see cref="PostOrderTraversal"/> class.
    /// </summary>
	public sealed class PostOrderTraversalTests
	{
		/// <summary>
		/// Creates the traversal algorithm.
		/// </summary>
		/// <returns>The algorithm.</returns>
		private ITraversal<Node> Create()
		{
			return new PostOrderTraversal.LambdaTraversal<Node>(node => node.Children);
		}

		[Fact]
		public void ShouldReturnAPostOrderSequence_WhenTheGraphIsOneNode()
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
		public void ShouldReturnAPostOrderSequence_WhenTheGraphIsATree()
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
			Assert.Equal(new[] { h, i, d, e, a, b, j, k, f, g, c, root }, nodes);
		}

		[Fact]
		public void ShouldReturnAPostOrderSequence_WhenTheGraphIsADAG()
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
			Assert.Equal(new[] { f, g, h, d, a, e, b, c, root }, nodes);
		}

		[Fact]
		public void ShouldReturnAPostOrderSequence_WhenTheGraphHasCycles()
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
			var nodes = traversal.Traverse(a).ToArray();

			// Assert
			Assert.Equal(new[] { e, c, d, b, a }, nodes);
		}
	}
}
