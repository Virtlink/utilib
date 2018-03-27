using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Xunit;

namespace Virtlink.Utilib.Collections
{
    partial class EnumerablesTests
    {
        /// <summary>
        /// Tests the <see cref="Enumerables.CreateSafetyCopy"/> method.
        /// </summary>
        public sealed class CreateSafetyCopyTests
        {
            [Fact]
            public void ShouldReturnUnchangingList_WhenInputElementIsSetInList()
            {
                // Arrange
                var input = new List<string> { "a", "b", "c" };

                // Act
                var result = input.CreateSafetyCopy();
                input[1] = "X";

                // Assert
                Assert.Equal(new[] { "a", "b", "c" }, result);
            }

            [Fact]
            public void ShouldReturnUnchangingList_WhenInputElementIsRemovedInList()
            {
                // Arrange
                var input = new List<string> { "a", "b", "c" };

                // Act
                var result = input.CreateSafetyCopy();
                input.RemoveAt(1);

                // Assert
                Assert.Equal(new[] { "a", "b", "c" }, result);
            }

            [Fact]
            public void ShouldReturnUnchangingList_WhenInputElementIsAddedInList()
            {
                // Arrange
                var input = new List<string> { "a", "b", "c" };

                // Act
                var result = input.CreateSafetyCopy();
                input.Insert(1, "d");

                // Assert
                Assert.Equal(new[] { "a", "b", "c" }, result);
            }

            [Fact]
            public void ShouldReturnUnchangingList_WhenInputListIsCleared()
            {
                // Arrange
                var input = new List<string> { "a", "b", "c" };

                // Act
                var result = input.CreateSafetyCopy();
                input.Clear();

                // Assert
                Assert.Equal(new[] { "a", "b", "c" }, result);
            }

            [Fact]
            public void ShouldReturnUnchangingList_WhenInputElementIsSetInArray()
            {
                // Arrange
                var input = new string[] { "a", "b", "c" };

                // Act
                var result = input.CreateSafetyCopy();
                input[1] = "X";

                // Assert
                Assert.Equal(new[] { "a", "b", "c" }, result);
            }

            [Fact]
            public void ShouldReturnUnchangingList_WhenInputElementIsAddedInEmptyList()
            {
                // Arrange
                var input = new List<string>();

                // Act
                var result = input.CreateSafetyCopy();
                input.Add("a");

                // Assert
                Assert.Empty(result);
            }

            [Fact]
            public void ShouldReturnUnchangingList_WhenInputEmptyListIsCleared()
            {
                // Arrange
                var input = new List<string>();

                // Act
                var result = input.CreateSafetyCopy();
                input.Clear();

                // Assert
                Assert.Empty(result);
            }
        }
    }
}
