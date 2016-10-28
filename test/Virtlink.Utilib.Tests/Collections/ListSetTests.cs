using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Tests the <see cref="ListSet{T}"/> class.
    /// </summary>
    [TestFixture]
    public partial class ListSetTests
    {
        [Test]
        public void DoesNotAddDuplicateElements()
        {
            // Arrange
            var sut = new ListSet<String>();
            sut.Add("abc");

            // Act
            bool result = sut.Add("abc");

            // Assert
            Assert.That(result, Is.False);
            Assert.That(sut, Is.EquivalentTo(new [] { "abc" }));
        }

        [Test]
        public void AddNewElements()
        {
            // Arrange
            var sut = new ListSet<String>();

            // Act
            bool result = sut.Add("abc");

            // Assert
            Assert.That(result, Is.True);
            Assert.That(sut, Is.EquivalentTo(new[] { "abc" }));
        }
    }
}
