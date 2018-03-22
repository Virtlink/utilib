using Xunit;

namespace Virtlink.Utilib.Text
{
    partial class CodePointSetTests
    {
        /// <summary>
        /// Tests the <see cref="CodePointSet.Remove"/> method.
        /// </summary>
        public sealed class RemoveTests
        {
            [Fact]
            public void ShouldNotRemoveEof_WhenTheElementIsNotPresent()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(41), new CodePoint(42), new CodePoint(43), new CodePoint(1000), new CodePoint(1001), new CodePoint(1002) });
                var result = new CodePointSet(set);

                // Act
                result.Remove(CodePoint.Eof);

                // Assert
                Assert.Equivalent(new[] { new CodePoint(41), new CodePoint(42), new CodePoint(43), new CodePoint(1000), new CodePoint(1001), new CodePoint(1002) }, result);
            }

            [Fact]
            public void ShouldRemoveEof_WhenTheElementIsPresent()
            {
                // Arrange
                var set = new CodePointSet(new[] { CodePoint.Eof, new CodePoint(41), new CodePoint(42), new CodePoint(43), new CodePoint(1000), new CodePoint(1001), new CodePoint(1002) });
                var result = new CodePointSet(set);

                // Act
                result.Remove(CodePoint.Eof);

                // Assert
                Assert.Equivalent(new[] { new CodePoint(41), new CodePoint(42), new CodePoint(43), new CodePoint(1000), new CodePoint(1001), new CodePoint(1002) }, result);
            }

            [Fact]
            public void ShouldNotRemoveTheLowElement_WhenTheElementIsNotPresent()
            {
                // Arrange
                var set = new CodePointSet(new [] { new CodePoint(41), new CodePoint(42), new CodePoint(43), new CodePoint(1000), new CodePoint(1001), new CodePoint(1002) });
                var result = new CodePointSet(set);

                // Act
                result.Remove(new CodePoint(60));

                // Assert
                Assert.Equivalent(new [] { new CodePoint(41), new CodePoint(42), new CodePoint(43), new CodePoint(1000), new CodePoint(1001), new CodePoint(1002) }, result);
            }

            [Fact]
            public void ShouldRemoveTheLowElement_WhenTheElementIsPresent()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(41), new CodePoint(42), new CodePoint(43), new CodePoint(1000), new CodePoint(1001), new CodePoint(1002) });
                var result = new CodePointSet(set);

                // Act
                result.Remove(new CodePoint(42));

                // Assert
                Assert.Equivalent(new[] { new CodePoint(41), new CodePoint(43), new CodePoint(1000), new CodePoint(1001), new CodePoint(1002) }, result);
            }

            [Fact]
            public void ShouldNotRemoveTheHighElement_WhenTheElementIsNotPresent()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(41), new CodePoint(42), new CodePoint(43), new CodePoint(1000), new CodePoint(1001), new CodePoint(1002) });
                var result = new CodePointSet(set);

                // Act
                result.Remove(new CodePoint(1010));

                // Assert
                Assert.Equivalent(new[] { new CodePoint(41), new CodePoint(42), new CodePoint(43), new CodePoint(1000), new CodePoint(1001), new CodePoint(1002) }, result);
            }

            [Fact]
            public void ShouldNotRemoveTheHighElement_WhenTheElementIsPresent()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(41), new CodePoint(42), new CodePoint(43), new CodePoint(1000), new CodePoint(1001), new CodePoint(1002) });
                var result = new CodePointSet(set);

                // Act
                result.Remove(new CodePoint(1001));

                // Assert
                Assert.Equivalent(new[] { new CodePoint(41), new CodePoint(42), new CodePoint(43), new CodePoint(1000), new CodePoint(1002) }, result);
            }
        }
    }
}
