using Xunit;
using System;
using System.Threading;

namespace Virtlink.Utilib.Threading
{
	partial class ReaderWriterLockSlimExtensionsTests
    {
        /// <summary>
        /// Tests the <see cref="ReaderWriterLockSlimExtensions.Read"/> method.
        /// </summary>
        public sealed class ReadTests
		{
			[Fact]
			public void ShouldReturnADisposable()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.Read();

				// Assert
				Assert.IsAssignableFrom<IDisposable>(@lock);

				// Cleanup
				@lock.Dispose();
			}

			[Fact]
			public void ShouldBeLocked_WhileNotDisposed()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.Read();

				// Assert
				Assert.True(sut.IsReadLockHeld);

				// Cleanup
				@lock.Dispose();
			}

			[Fact]
			public void ShouldBeUnlocked_WhenDisposed()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.Read();
				@lock.Dispose();

				// Assert
				Assert.False(sut.IsReadLockHeld);
			}

			[Fact]
			public void ShouldThrowArgumentNullException_WhenReaderWriterLockSlimIsNull()
			{
				// Arrange
				ReaderWriterLockSlim sut = null;

			    // Act
			    var exception = Record.Exception(() =>
			    {
			        sut.Read();
			    });

			    // Assert
			    Assert.IsType<ArgumentNullException>(exception);
			}
		}
	}
}
