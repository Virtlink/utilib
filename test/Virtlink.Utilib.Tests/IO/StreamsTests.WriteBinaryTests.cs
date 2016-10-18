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
        /// Tests the <see cref="Streams.WriteBinary"/> function.
        /// </summary>
        [TestFixture]
        public sealed class WriteBinaryTests
        {
            [Test]
            public void ReturnsABinaryWriter()
            {
                // Arrange
                var input = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD};
                var stream = new MemoryStream();

                // Act
                var writer = stream.WriteBinary();
                writer.Write(input);

                // Assert
                Assert.That(GetBytes(stream), Is.EqualTo(input));

                // Cleanup
                writer.Dispose();
                stream.Dispose();
            }

            [Test]
            public void ClosingWriterDoesNotCloseStream()
            {
                // Arrange
                var stream = new MemoryStream();
                var writer = stream.WriteBinary();

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
                    sut.WriteBinary();
                }, Throws.ArgumentNullException);
            }

            private byte[] GetBytes(MemoryStream stream)
            {
                stream.Position = 0;
                return stream.ToArray();
            }
        }
    }
}
