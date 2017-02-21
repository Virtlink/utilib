using System;
using System.IO;
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
        public void ShouldThrowObjectDisposedException_WhenAMemoryStreamIsDisposedAndGettingPosition()
        {
            // Arrange
            var stream = new MemoryStream();
            stream.Dispose();

            // Act
            var exception = Record.Exception(() => {
                long v = stream.Position;
            });

            // Assert
            Assert.IsType<ObjectDisposedException>(exception);
        }
    }
}
