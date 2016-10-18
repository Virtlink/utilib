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
        /// Tests the <see cref="Streams.ResetPosition"/> function.
        /// </summary>
        [TestFixture]
        public sealed class ResetPositionTests
        {
            [Test]
            public void ResetsThePositionToZero()
            {
                // Arrange
                var input = new byte[] { 0xAA, 0xBB, 0xCC, 0xDD};
                var stream = new MemoryStream();
                stream.Write(input, 0, input.Length);

                // Act
                long oldPosition = stream.Position;
                stream.ResetPosition();
                long newPosition = stream.Position;

                // Assert
                Assert.That(oldPosition, Is.EqualTo(4));
                Assert.That(newPosition, Is.EqualTo(0));

                // Cleanup
                stream.Dispose();
            }

            [Test]
            public void ReturnsTheInputStream()
            {
                // Arrange
                var stream = new MemoryStream();

                // Act
                var result = stream.ResetPosition();

                // Assert
                Assert.That(result, Is.SameAs(stream));

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
                    sut.ResetPosition();
                }, Throws.ArgumentNullException);
            }
        }
    }
}
