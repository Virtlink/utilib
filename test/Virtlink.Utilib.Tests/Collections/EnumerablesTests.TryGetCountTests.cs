using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.Collections
{
    partial class EnumerablesTests
    {
        /// <summary>
        /// Tests the <see cref="Enumerables.TryGetCount"/> method.
        /// </summary>
        [TestFixture]
        public sealed class TryGetCountTests
        {
            [Test]
            public void ReturnsCountOfICollection_T()
            {
                // Arrange
                var collection = new List<String>{ "a", "b", "c" };

                // Act
                int? result = Enumerables.TryGetCount(collection);

                // Assert
                Assert.That(result, Is.EqualTo(3));
            }

            [Test]
            public void ReturnsCountOfICollection()
            {
                // Arrange
                var collection = new ArrayList { "a", "b", "c" };

                // Act
                int? result = Enumerables.TryGetCount(collection);

                // Assert
                Assert.That(result, Is.EqualTo(3));
            }

            [Test]
            public void ReturnsNullForNonCollection()
            {
                // Arrange
                var enumerable = new [] { "a", "b", "c" }.Select(s => s);

                // Act
                int? result = Enumerables.TryGetCount(enumerable);

                // Assert
                Assert.That(result, Is.Null);
            }

            [Test]
            public void ThrowsIfEnumerableIsNull()
            {
                // Arrange
                IReadOnlyCollection<String> enumerable = null;

                // Act/Assert
                Assert.That(() =>
                {
                    Enumerables.TryGetCount(enumerable);
                }, Throws.ArgumentNullException);
            }
        }
    }
}
