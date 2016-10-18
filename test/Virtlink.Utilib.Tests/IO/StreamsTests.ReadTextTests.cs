using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.IO
{
    partial class StreamsTests
    {
        /// <summary>
        /// Tests the <see cref="Streams.ReadText"/> function.
        /// </summary>
        [TestFixture]
        public sealed class ReadTextTests
        {
            [Test]
            public void ReturnsATextReader()
            {
                // Arrange
                var input = "TEST";
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));

                // Act
                var reader = stream.ReadText();

                // Assert
                Assert.That(reader.ReadToEnd(), Is.EqualTo(input));

                // Cleanup
                reader.Dispose();
                stream.Dispose();
            }

            [Test]
            public void ClosingReaderDoesNotCloseStream()
            {
                // Arrange
                var stream = new MemoryStream();
                var reader = stream.ReadText();

                // Act
                reader.Dispose();

                // Assert
                Assert.That(() =>
                {
                    long p = stream.Position;
                }, Throws.Nothing);

                // Cleanup
                stream.Dispose();
            }

            [Test]
            public void ThrowsWhenStreamIsNull()
            {
                // Arrange
                Stream sut = null;

                // Act/Assert
                Assert.That(() =>
                {
                    sut.ReadText();
                }, Throws.ArgumentNullException);
            }
        }
    }
}
