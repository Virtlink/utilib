using System;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Tests the <see cref="ListSet{T}"/> class.
    /// </summary>
    public partial class ListSetTests
    {
        [Fact]
        public void ShouldNotAddElements_WhenAnEqualElementIsAlreadyPresent()
        {
            // Arrange
            var sut = new ListSet<String>();
            sut.Add("abc");

            // Act
            bool result = sut.Add("abc");

            // Assert
            Assert.False(result);
            Assert.Equal(new[] { "abc" }, sut);
        }

        [Fact]
        public void ShouldAddElement_WhenAnEqualElementIsNotAlreadyPresent()
        {
            // Arrange
            var sut = new ListSet<String>();

            // Act
            bool result = sut.Add("abc");

            // Assert
            Assert.True(result);
            Assert.Equal(new[] { "abc" }, sut);
        }
    }
}
