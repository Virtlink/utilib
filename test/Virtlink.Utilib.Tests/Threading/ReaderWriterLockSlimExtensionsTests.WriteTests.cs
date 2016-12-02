using NUnit.Framework;
using System;
using System.Threading;

namespace Virtlink.Utilib.Threading
{
	partial class ReaderWriterLockSlimExtensionsTests
	{
		[TestFixture]
		public sealed class WriteTests
		{
			[Test]
			public void ReturnsDisposable()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.Write();

				// Assert
				Assert.That(@lock, Is.AssignableTo(typeof(IDisposable)));

				// Cleanup
				@lock.Dispose();
			}

			[Test]
			public void IsLockedWhileNotDisposed()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.Write();

				// Assert
				Assert.That(sut.IsWriteLockHeld, Is.True);

				// Cleanup
				@lock.Dispose();
			}

			[Test]
			public void IsUnlockedWhenDisposed()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.Write();
				@lock.Dispose();

				// Assert
				Assert.That(sut.IsWriteLockHeld, Is.False);
			}

			[Test]
			public void WorksWithinUpgradeableReadLock()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();
				sut.EnterUpgradeableReadLock();

				// Act
				var @lock = sut.Write();

				// Assert
				Assert.That(sut.IsWriteLockHeld, Is.True);
				Assert.That(sut.IsUpgradeableReadLockHeld, Is.True);

				// Cleanup
				@lock.Dispose();
				sut.ExitUpgradeableReadLock();
			}

			[Test]
			public void DoesNotExitUpgradeableReadLock()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();
				sut.EnterUpgradeableReadLock();

				// Act
				var @lock = sut.Write();
				@lock.Dispose();

				// Assert
				Assert.That(sut.IsWriteLockHeld, Is.False);
				Assert.That(sut.IsUpgradeableReadLockHeld, Is.True);

				// Cleanup
				sut.ExitUpgradeableReadLock();
			}

			[Test]
			public void ThrowsWhenReaderWriterLockSlimIsNull()
			{
				// Arrange
				ReaderWriterLockSlim sut = null;

				// Act/Assert
				Assert.That(() =>
				{
					sut.Write();
				}, Throws.ArgumentNullException);
			}
		}
	}
}
