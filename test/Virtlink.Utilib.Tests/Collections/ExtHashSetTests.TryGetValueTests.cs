using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class ExtHashSetTests
    {
        /// <summary>
        /// Tests the <see cref="ExtHashSet{T}.TryGetValue"/> method.
        /// </summary>
        public sealed class TryGetValueTests
        {
            [Fact]
            public void ShouldReturnElementAndTrue_WhenSameValueExists()
            {
                // Arrange
                var elements = new[]
                {
                    new TestObject("D.W. Sandlin", "Astronaut"),
                    new TestObject("D.A. Muller", "Physicist"),
                    new TestObject("B.J. Haran", "Journalist"),
                    new TestObject("V. Hart", "Mathematician"),
                    new TestObject("H.E. Reich", "Physicist"),
                    new TestObject("C.G.P. Grey", "Teacher"),
                };
                var set = new ExtHashSet<TestObject>(elements);

                // Act
                bool result = set.TryGetValue(elements[1], out var muller);

                // Assert
                Assert.True(result);
                Assert.Same(elements[1], muller);
            }

            [Fact]
            public void ShouldReturnElementAndTrue_WhenEqualValueExists()
            {
                // Arrange
                var elements = new[]
                {
                    new TestObject("D.W. Sandlin", "Astronaut"),
                    new TestObject("D.A. Muller", "Physicist"),
                    new TestObject("B.J. Haran", "Journalist"),
                    new TestObject("V. Hart", "Mathematician"),
                    new TestObject("H.E. Reich", "Physicist"),
                    new TestObject("C.G.P. Grey", "Teacher"),
                };
                var set = new ExtHashSet<TestObject>(elements);

                // Act
                bool result = set.TryGetValue(new TestObject("C.G.P. Grey", "Process Manager"), out var grey);

                // Assert
                Assert.True(result);
                Assert.Same(elements[5], grey);
            }

            [Fact]
            public void ShouldReturnChangedElementAndTrue_WhenChangedValueExists()
            {
                // Arrange
                var elements = new[]
                {
                    new TestObject("D.W. Sandlin", "Astronaut"),
                    new TestObject("D.A. Muller", "Physicist"),
                    new TestObject("B.J. Haran", "Journalist"),
                    new TestObject("V. Hart", "Mathematician"),
                    new TestObject("H.E. Reich", "Physicist"),
                    new TestObject("C.G.P. Grey", "Teacher"),
                };
                var set = new ExtHashSet<TestObject>(elements);

                set.TryGetValue(elements[4], out var reich);
                reich.Value = "YouTuber";

                // Act
                bool result = set.TryGetValue(elements[4], out var reich2);

                // Assert
                Assert.True(result);
                Assert.Equal("YouTuber", reich2.Value);
            }

            [Fact]
            public void ShouldReturnInputValueAndFalse_WhenValueDoesNotExist()
            {
                // Arrange
                var elements = new[]
                {
                    new TestObject("D.W. Sandlin", "Astronaut"),
                    new TestObject("D.A. Muller", "Physicist"),
                    new TestObject("B.J. Haran", "Journalist"),
                    new TestObject("V. Hart", "Mathematician"),
                    new TestObject("H.E. Reich", "Physicist"),
                    new TestObject("C.G.P. Grey", "Teacher"),
                };
                var set = new ExtHashSet<TestObject>(elements);

                // Act
                var toFind = new TestObject("F.A.U. Kjellberg", "YouTuber");
                bool result = set.TryGetValue(toFind, out var kjellberg);

                // Assert
                Assert.False(result);
                Assert.Same(toFind, kjellberg);
            }
        }
    }
}
