using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.Collections
{
    partial class ArraysTests
    {
        /// <summary>
        /// Tests the <see cref="Arrays.Empty"/> function.
        /// </summary>
        [TestFixture]
        public sealed class EmptyTests
        {
            [Test]
            public void ReturnsAnEmptyArray()
            {
                // Act
                var result = Arrays.Empty<String>();

                // Assert
                Assert.That(result, Is.EqualTo(new String[0]));
            }

            [Test]
            public void ReturnedArrayIsImmutable()
            {
                // Arrange
                var result = Arrays.Empty<string>();

                // Act/Assert
                Assert.That(() =>
                {
                    ((ICollection<string>)result).Add("str");
                }, Throws.InstanceOf<NotSupportedException>());
            }
        }
    }
}
