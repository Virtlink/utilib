using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib.IO
{
    /// <summary>
    /// Tests the <see cref="Streams"/> class.
    /// </summary>
    [TestFixture]
    public partial class StreamsTests
    {
        /// <summary>
		/// A disposed <see cref="MemoryStream"/> throws an <see cref="ObjectDisposedException"/>
		/// when trying to get the current position.
		/// 
		/// This fact is used in several tests.
		/// </summary>
		[Test]
        public void DisposedMemoryStreamThrowsExceptionOnGetPosition()
        {
            // Arrange
            var stream = new MemoryStream();
            stream.Dispose();

            // Act/Assert
            Assert.That(() => {
                long v = stream.Position;
            }, Throws.InstanceOf<ObjectDisposedException>());
        }
    }
}
