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
        /// Tests the <see cref="List.Empty"/> function.
        /// </summary>
        [TestFixture]
        public sealed class EmptyTests
        {
            [Test]
            public void ReturnsAnEmptyArray()
            {
                // Act
                var result = List.Empty<String>();

                // Assert
                Assert.That(result, Is.InstanceOf<IReadOnlyList<String>>());
            }

            [Test]
            public void ReturnedEmptyArrayCannotBeModified()
            {
                // Act
                var result = (IList<String>)List.Empty<String>();

                // Assert
                Assert.That(() =>
                {
                    result.Add("test");
                }, Throws.InstanceOf<NotSupportedException>());
            }
        }
    }
}
