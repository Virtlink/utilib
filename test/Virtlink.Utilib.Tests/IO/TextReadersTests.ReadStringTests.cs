using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.IO
{
    partial class TextReadersTests
    {
        /// <summary>
        /// Tests the <see cref="TextReaders.ReadString"/> method.
        /// </summary>
        [TestFixture]
        public sealed class ReadStringTests
        {
            [Test]
            public void Given0_ReadsAnEmptyString()
            {
                // Arrange
                var reader = new StringReader("abcdef");

                // Act
                var result = reader.ReadString(0);

                // Assert
                Assert.That(result, Is.EqualTo(""));
            }

            [Test]
            public void Given1_ReadsASingleCharacter()
            {
                // Arrange
                var reader = new StringReader("abcdef");

                // Act
                var result = reader.ReadString(1);

                // Assert
                Assert.That(result, Is.EqualTo("a"));
            }

            [Test]
            public void Given5_ReadsMostOfTheString()
            {
                // Arrange
                var reader = new StringReader("abcdef");

                // Act
                var result = reader.ReadString(5);

                // Assert
                Assert.That(result, Is.EqualTo("abcde"));
            }

            [Test]
            public void Given6_ReadsAllOfTheString()
            {
                // Arrange
                var reader = new StringReader("abcdef");

                // Act
                var result = reader.ReadString(6);

                // Assert
                Assert.That(result, Is.EqualTo("abcdef"));
            }

            [Test]
            public void Given10_ReadsJustTheString()
            {
                // Arrange
                var reader = new StringReader("abcdef");

                // Act
                var result = reader.ReadString(10);

                // Assert
                Assert.That(result, Is.EqualTo("abcdef"));
            }
        }
    }
}
