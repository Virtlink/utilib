using Xunit;
using System;
using System.Threading;

namespace Virtlink.Utilib.Threading
{
	partial class ReaderWriterLockSlimExtensionsTests
    {
        /// <summary>
        /// Tests the <see cref="ReaderWriterLockSlimExtensions.UpgradeableRead"/> method.
        /// </summary>
        public sealed class UpgradeableReadTests
		{
			[Fact]
			public void ShouldReturnADisposable()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.UpgradeableRead();

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
				var @lock = sut.UpgradeableRead();

				// Assert
				Assert.True(sut.IsUpgradeableReadLockHeld);

				// Cleanup
				@lock.Dispose();
			}

			[Fact]
			public void ShouldBeUnlocked_WhenDisposed()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.UpgradeableRead();
				@lock.Dispose();

				// Assert
				Assert.False(sut.IsUpgradeableReadLockHeld);
			}

			[Fact]
			public void ShouldThrowArgumentNullException_WhenReaderWriterLockSlimIsNull()
			{
				// Arrange
				ReaderWriterLockSlim sut = null;

			    // Act
			    var exception = Record.Exception(() =>
			    {
			        sut.UpgradeableRead();
			    });

			    // Assert
			    Assert.IsType<ArgumentNullException>(exception);
			}
		}
	}
}
