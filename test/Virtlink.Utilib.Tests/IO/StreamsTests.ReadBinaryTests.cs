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
        /// Tests the <see cref="Streams.ReadBinary"/> function.
        /// </summary>
        [TestFixture]
        public sealed class ReadBinaryTests
        {
            [Test]
            public void ReturnsABinaryReader()
            {
                // Arrange
                var input = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD};
                var stream = new MemoryStream(input);

                // Act
                var reader = stream.ReadBinary();

                // Assert
                Assert.That(reader.ReadBytes(input.Length), Is.EqualTo(input));

                // Cleanup
                reader.Dispose();
                stream.Dispose();
            }

            [Test]
            public void ClosingReaderDoesNotCloseStream()
            {
                // Arrange
                var stream = new MemoryStream();
                var reader = stream.ReadBinary();

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
                    sut.ReadBinary();
                }, Throws.ArgumentNullException);
            }
        }
    }
}
