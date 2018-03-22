using Xunit;

namespace Virtlink.Utilib.Text
{
    partial class CodePointSetTests
    {
        /// <summary>
        /// Tests the <see cref="CodePointSet.Add"/> method.
        /// </summary>
        public sealed class AddTests
        {
            [Fact]
            public void ShouldAddEof_WhenEofNotAlreadyPresent()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(42), new CodePoint(1000) });
                var result = new CodePointSet(set);

                // Act
                result.Add(CodePoint.Eof);

                // Assert
                Assert.Equivalent(new[] { new CodePoint(42), new CodePoint(1000), CodePoint.Eof }, result);
            }

            [Fact]
            public void ShouldNotAddEof_WhenEofIsAlreadyPresent()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(42), new CodePoint(1000), CodePoint.Eof });
                var result = new CodePointSet(set);

                // Act
                result.Add(CodePoint.Eof);

                // Assert
                Assert.Equivalent(new[] { new CodePoint(42), new CodePoint(1000), CodePoint.Eof }, result);
            }

            [Fact]
            public void ShouldAddTheLowElement_WhenTheElementIsNotAlreadyPresent()
            {
                // Arrange
                var set = new CodePointSet(new [] { new CodePoint(42), new CodePoint(1000) });
                var result = new CodePointSet(set);

                // Act
                result.Add(new CodePoint(60));

                // Assert
                Assert.Equivalent(new [] { new CodePoint(42), new CodePoint(60), new CodePoint(1000) }, result);
            }

            [Fact]
            public void ShouldNotAddTheLowElement_WhenTheElementIsAlreadyPresent()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(42), new CodePoint(1000) });
                var result = new CodePointSet(set);

                // Act
                result.Add(new CodePoint(42));

                // Assert
                Assert.Equivalent(new[] { new CodePoint(42), new CodePoint(1000) }, result);
            }

            [Fact]
            public void ShouldAddTheHighElement_WhenTheElementIsNotAlreadyPresent()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(42), new CodePoint(1000) });
                var result = new CodePointSet(set);

                // Act
                result.Add(new CodePoint(1010));

                // Assert
                Assert.Equivalent(new[] { new CodePoint(42), new CodePoint(1000), new CodePoint(1010) }, result);
            }

            [Fact]
            public void ShouldNotAddTheHighElement_WhenTheElementIsAlreadyPresent()
            {
                // Arrange
                var set = new CodePointSet(new[] { new CodePoint(42), new CodePoint(1000) });
                var result = new CodePointSet(set);

                // Act
                result.Add(new CodePoint(1000));

                // Assert
                Assert.Equivalent(new[] { new CodePoint(42), new CodePoint(1000) }, result);
            }
        }
    }
}
