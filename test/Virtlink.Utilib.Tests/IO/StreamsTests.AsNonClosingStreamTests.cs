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
        /// Tests the <see cref="Streams.AsNonClosingStream"/> function.
        /// </summary>
        [TestFixture]
        public sealed class AsNonClosingStreamTests
        {
            [Test]
            public void ReturnedStreamAllowsReading()
            {
                // Arrange
                var input = "TEST";
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));

                // Act
                var nonClosingStream = stream.AsNonClosingStream();
                var reader = nonClosingStream.ReadText();
                var result = reader.ReadToEnd();

                // Assert
                Assert.That(result, Is.EqualTo(input));

                // Cleanup
                reader.Dispose();
                stream.Dispose();
            }

            [Test]
            public void ReturnedStreamAllowsWriting()
            {
                // Arrange
                var input = "TEST";
                var stream = new MemoryStream();

                // Act
                var nonClosingStream = stream.AsNonClosingStream();
                var writer = nonClosingStream.WriteText();
                writer.Write(input);
                writer.Flush();

                // Assert
                Assert.That(GetString(stream), Is.EqualTo(input));

                // Cleanup
                writer.Dispose();
                stream.Dispose();
            }

            [Test]
            public void ReturnedStreamAllowsSeeking()
            {
                // Arrange
                var input = "TEST";
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(input));

                // Act
                var nonClosingStream = stream.AsNonClosingStream();
                nonClosingStream.Seek(2, SeekOrigin.Begin);

                // Assert
                Assert.That(stream.Position, Is.EqualTo(2));

                // Cleanup
                stream.Dispose();
            }

            [Test]
            public void UnderlyingStreamIsNotClosed()
            {
                // Arrange
                var stream = new MemoryStream();
                var nonClosingStream = stream.AsNonClosingStream();

                // Act
                nonClosingStream.Dispose();

                // Assert
                Assert.That(() =>
                {
                    long p = stream.Position;
                }, Throws.Nothing);

                // Cleanup
                stream.Dispose();
            }

            [Test]
            public void ReturnsSameStreamWhenStreamIsAlreadyNonClosing()
            {
                // Arrange
                var stream = new MemoryStream().AsNonClosingStream();

                // Act
                var result = stream.AsNonClosingStream();

                // Assert
                Assert.That(result, Is.SameAs(stream));
            }

            [Test]
            public void ThrowsWhenStreamIsNull()
            {
                // Arrange
                Stream sut = null;

                // Act/Assert
                Assert.That(() =>
                {
                    sut.AsNonClosingStream();
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
