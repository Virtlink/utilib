using System;
using Xunit;
using System.Threading;

namespace Virtlink.Utilib.Threading
{
	partial class ReaderWriterLockSlimExtensionsTests
	{
        /// <summary>
        /// Tests the <see cref="ReaderWriterLockSlimExtensions.IsLockHeld"/> method.
        /// </summary>
		public sealed class IsLockHeldTests
		{
			[Fact]
			public void ShouldReturnFalse_WhenNoLockIsHeld()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				bool result = sut.IsLockHeld();

				// Assert
				Assert.False(result);
			}

			[Fact]
			public void ShouldReturnTrue_WhenReadLockIsHeld()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();
				sut.EnterReadLock();

				// Act
				bool result = sut.IsLockHeld();

				// Assert
				Assert.True(result);

				// Cleanup
				sut.ExitReadLock();
			}

			[Fact]
			public void ShouldReturnTrue_WhenUpgradeableReadLockIsHeld()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();
				sut.EnterUpgradeableReadLock();

				// Act
				bool result = sut.IsLockHeld();

				// Assert
				Assert.True(result);

				// Cleanup
				sut.ExitUpgradeableReadLock();
			}

			[Fact]
			public void ShouldReturnTrue_WhenWriteLockIsHeld()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();
				sut.EnterWriteLock();

				// Act
				bool result = sut.IsLockHeld();

				// Assert
				Assert.True(result);

				// Cleanup
				sut.ExitWriteLock();
			}

			[Fact]
			public void ShouldReturnTrue_WhenWriteLockIsHeldInUpgradeableReadLock()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();
				sut.EnterUpgradeableReadLock();
				sut.EnterWriteLock();

				// Act
				bool result = sut.IsLockHeld();

				// Assert
				Assert.True(result);

				// Cleanup
				sut.ExitWriteLock();
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
					sut.IsLockHeld();
				});

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
			}
		}
	}
}
