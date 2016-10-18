using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.Collections
{
    partial class ExtHashSetTests
    {
        /// <summary>
        /// Tests the <see cref="ExtHashSet{T}.TryGet"/> method.
        /// </summary>
        [TestFixture]
        public sealed class TryGetTests
        {
            [Test]
            public void OnExistingSameValue_ReturnsElementAndTrue()
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
                TestObject muller;
                bool result = set.TryGet(elements[1], out muller);

                // Assert
                Assert.That(result, Is.True);
                Assert.That(muller, Is.SameAs(elements[1]));
            }
            
            [Test]
            public void OnExistingEqualValue_ReturnsElementAndTrue()
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
                TestObject grey;
                bool result = set.TryGet(new TestObject("C.G.P. Grey", "Process Manager"), out grey);

                // Assert
                Assert.That(result, Is.True);
                Assert.That(grey, Is.SameAs(elements[5]));
            }

            [Test]
            public void OnExistingChangedValue_ReturnsChangedElementAndTrue()
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

                TestObject reich;
                set.TryGet(elements[4], out reich);
                reich.Value = "YouTuber";

                // Act
                TestObject reich2;
                bool result = set.TryGet(elements[4], out reich2);

                // Assert
                Assert.That(result, Is.True);
                Assert.That(reich2.Value, Is.EqualTo("YouTuber"));
            }

            [Test]
            public void OnNonExistingValue_ReturnsDefaultAndFalse()
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
                TestObject kjellberg;
                bool result = set.TryGet(new TestObject("F.A.U. Kjellberg", "YouTuber"), out kjellberg);

                // Assert
                Assert.That(result, Is.False);
                Assert.That(kjellberg, Is.SameAs(default(TestObject)));
            }
        }
    }
}
