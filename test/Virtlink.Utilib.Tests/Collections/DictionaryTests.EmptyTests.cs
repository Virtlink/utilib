using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.Collections
{
    partial class DictionaryTests
    {
        /// <summary>
        /// Tests the <see cref="Dictionary.Empty"/> function.
        /// </summary>
        [TestFixture]
        public sealed class EmptyTests
        {
            [Test]
            public void ReturnsAnEmptyArray()
            {
                // Act
                var result = Dictionary.Empty<String, Object>();

                // Assert
                Assert.That(result, Is.InstanceOf<IReadOnlyDictionary<String, Object>>());
            }

            [Test]
            public void ReturnedEmptyArrayCannotBeModified()
            {
                // Act
                var result = (IDictionary<String, Object>)Dictionary.Empty<String, Object>();

                // Assert
                Assert.That(() =>
                {
                    result.Add("test", 12);
                }, Throws.InstanceOf<NotSupportedException>());
            }
        }
    }
}
