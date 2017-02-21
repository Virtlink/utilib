using Xunit;
using System;
using System.Threading;

namespace Virtlink.Utilib.Threading
{
	partial class ReaderWriterLockSlimExtensionsTests
    {
        /// <summary>
        /// Tests the <see cref="ReaderWriterLockSlimExtensions.Write"/> method.
        /// </summary>
        public sealed class WriteTests
		{
			[Fact]
			public void ShouldReturnADisposable()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.Write();

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
				var @lock = sut.Write();

				// Assert
				Assert.True(sut.IsWriteLockHeld);

				// Cleanup
				@lock.Dispose();
			}

			[Fact]
			public void ShouldBeUnlocked_WhenDisposed()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.Write();
				@lock.Dispose();

				// Assert
				Assert.False(sut.IsWriteLockHeld);
			}

			[Fact]
			public void ShouldWorkWithinUpgradeableReadLock()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();
				sut.EnterUpgradeableReadLock();

				// Act
				var @lock = sut.Write();

				// Assert
				Assert.True(sut.IsWriteLockHeld);
				Assert.True(sut.IsUpgradeableReadLockHeld);

				// Cleanup
				@lock.Dispose();
				sut.ExitUpgradeableReadLock();
			}

			[Fact]
			public void ShouldNotExitUpgradeableReadLock()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();
				sut.EnterUpgradeableReadLock();

				// Act
				var @lock = sut.Write();
				@lock.Dispose();

				// Assert
				Assert.False(sut.IsWriteLockHeld);
				Assert.True(sut.IsUpgradeableReadLockHeld);

				// Cleanup
				sut.ExitUpgradeableReadLock();
			}

			[Fact]
			public void ShouldThrowArgumentNullException_WhenReaderWriterLockSlimIsNull()
			{
				// Arrange
				ReaderWriterLockSlim sut = null;

			    // Act
			    var exception = Record.Exception(() =>
			    {
			        sut.Write();
			    });

			    // Assert
			    Assert.IsType<ArgumentNullException>(exception);
			}
		}
	}
}
