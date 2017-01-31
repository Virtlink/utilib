using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.Collections
{
    partial class ListTests
    {
        /// <summary>
        /// Tests the <see cref="List.Copy"/> function.
        /// </summary>
        [TestFixture]
        public sealed class CopyTests
        {
            [Test]
            public void CountZero_CopiesNothing()
            {
                // Arrange
                var source = new int[] {1, 2, 3};
                var destination = new int[5];

                // Act
                List.Copy(source, 0, destination, 0, 0);

                // Assert
                Assert.That(destination, Is.EqualTo(new[] {0, 0, 0, 0, 0}));
            }

            [Test]
            public void TwoLists_CopiesStuff()
            {
                // Arrange
                var source = new int[] { 1, 2, 3 };
                var destination = new int[] { 1, 3, 5, 7, 9 };

                // Act
                List.Copy(source, 1, destination, 2, 2);

                // Assert
                Assert.That(destination, Is.EqualTo(new[] { 1, 3, 2, 3, 9 }));
            }

            [Test]
            public void SameListFromStartToLater_CopiesBackward()
            {
                // Arrange
                var list = new int[] { 1, 2, 3, 4, 5 };

                // Act
                List.Copy(list, 1, list, 3, 2);

                // Assert
                Assert.That(list, Is.EqualTo(new[] { 1, 2, 3, 2, 3 }));
            }

            [Test]
            public void SameListFromLaterToStart_CopiesForward()
            {
                // Arrange
                var list = new int[] { 1, 2, 3, 4, 5 };

                // Act
                List.Copy(list, 3, list, 1, 2);

                // Assert
                Assert.That(list, Is.EqualTo(new[] { 1, 4, 5, 4, 5 }));
            }

            [Test]
            public void SameListFromSameToSame_CopiesNothing()
            {
                // Arrange
                var list = new int[] { 1, 2, 3, 4, 5 };

                // Act
                List.Copy(list, 2, list, 2, 2);

                // Assert
                Assert.That(list, Is.EqualTo(new[] { 1, 2, 3, 4, 5 }));
            }

            [Test]
            public void NullSource_ThrowsException()
            {
                // Act/Assert
                Assert.That(() => {
                    List.Copy(null, 0, new int[5], 0, 0);
                }, Throws.ArgumentNullException);
            }

            [Test]
            public void NullDestination_ThrowsException()
            {
                // Act/Assert
                Assert.That(() => {
                    List.Copy(new int[5], 0, null, 0, 0);
                }, Throws.ArgumentNullException);
            }

            [Test]
            public void NegativeSourceIndex_ThrowsException()
            {
                // Act/Assert
                Assert.That(() => {
                    List.Copy(new int[5], -3, new int[5], 0, 0);
                }, Throws.InstanceOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void NegativeDestinationIndex_ThrowsException()
            {
                // Act/Assert
                Assert.That(() => {
                    List.Copy(new int[5], 0, new int[5], -3, 0);
                }, Throws.InstanceOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void NegativeCount_ThrowsException()
            {
                // Act/Assert
                Assert.That(() => {
                    List.Copy(new int[5], 0, new int[5], 0, -3);
                }, Throws.InstanceOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void SourceIndexOutOfBounds_ThrowsException()
            {
                // Act/Assert
                Assert.That(() => {
                    List.Copy(new int[5], 6, new int[5], 0, 0);
                }, Throws.InstanceOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void DestinationIndexOutOfBounds_ThrowsException()
            {
                // Act/Assert
                Assert.That(() => {
                    List.Copy(new int[5], 0, new int[5], 6, 0);
                }, Throws.InstanceOf<ArgumentOutOfRangeException>());
            }

            [Test]
            public void CountOutOfBounds_ThrowsException()
            {
                // Act/Assert
                Assert.That(() => {
                    List.Copy(new int[5], 5, new int[5], 0, 1);
                }, Throws.InstanceOf<ArgumentOutOfRangeException>());
            }
        }
    }
}
