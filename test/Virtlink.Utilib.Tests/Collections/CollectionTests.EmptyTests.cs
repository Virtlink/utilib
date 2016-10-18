using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.Collections
{
    partial class CollectionTests
    {
        /// <summary>
        /// Tests the <see cref="Collection{T}.Empty"/> function.
        /// </summary>
        [TestFixture]
        public sealed class EmptyTests
        {
            [Test]
            public void ReturnsAnEmptyArray()
            {
                // Act
                var result = Collection.Empty<String>();

                // Assert
                Assert.That(result, Is.InstanceOf<IReadOnlyCollection<String>>());
            }

            [Test]
            public void ReturnedEmptyArrayCannotBeModified()
            {
                // Act
                var result = (ICollection<String>)Collection.Empty<String>();

                // Assert
                Assert.That(() =>
                {
                    result.Add("test");
                }, Throws.InstanceOf<NotSupportedException>());
            }
        }
    }
}
