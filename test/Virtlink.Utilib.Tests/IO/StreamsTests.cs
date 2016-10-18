using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Virtlink.Utilib.IO
{
    /// <summary>
    /// Tests the <see cref="Streams"/> class.
    /// </summary>
    public partial class StreamsTests
    {
        /// <summary>
		/// A disposed <see cref="MemoryStream"/> throws an <see cref="ObjectDisposedException"/>
		/// when trying to get the current position.
		/// 
		/// This fact is used in several tests.
		/// </summary>
		[Fact]
        public void DisposedMemoryStreamThrowsExceptionOnGetPosition()
        {
            // Arrange
            var stream = new MemoryStream();
            stream.Dispose();

            // Act/Assert
            Assert.Throws<ObjectDisposedException>(() => {
                long v = stream.Position;
            });
        }
    }
}
