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
        /// Tests the <see cref="Streams.WriteText"/> function.
        /// </summary>
        [TestFixture]
        public sealed class WriteTextTests
        {
            [Test]
            public void ReturnsATextWriter()
            {
                // Arrange
                var input = "TEST";
                var stream = new MemoryStream();

                // Act
                var writer = stream.WriteText();
                writer.Write(input);
                writer.Flush();

                // Assert
                Assert.That(GetString(stream), Is.EqualTo(input));

                // Cleanup
                writer.Dispose();
                stream.Dispose();
            }

            [Test]
            public void ClosingWriterDoesNotCloseStream()
            {
                // Arrange
                var stream = new MemoryStream();
                var writer = stream.WriteText();

                // Act
                writer.Dispose();

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
                    sut.WriteText();
                }, Throws.ArgumentNullException);
            }

            private string GetString(MemoryStream stream)
            {
                stream.Position = 0;
                return Encoding.UTF8.GetString(stream.ToArray());
            }
        }
    }
}
