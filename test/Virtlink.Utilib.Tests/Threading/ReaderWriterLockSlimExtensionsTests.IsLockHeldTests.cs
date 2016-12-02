using NUnit.Framework;
using System.Threading;

namespace Virtlink.Utilib.Threading
{
	partial class ReaderWriterLockSlimExtensionsTests
	{
		[TestFixture]
		public sealed class IsLockHeldTests
		{
			[Test]
			public void IsFalseWhenNoLockIsHeld()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				bool result = sut.IsLockHeld();

				// Assert
				Assert.That(result, Is.False);
			}

			[Test]
			public void IsTrueWhenReadLockIsHeld()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();
				sut.EnterReadLock();

				// Act
				bool result = sut.IsLockHeld();

				// Assert
				Assert.That(result, Is.True);

				// Cleanup
				sut.ExitReadLock();
			}

			[Test]
			public void IsTrueWhenUpgradeableReadLockIsHeld()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();
				sut.EnterUpgradeableReadLock();

				// Act
				bool result = sut.IsLockHeld();

				// Assert
				Assert.That(result, Is.True);

				// Cleanup
				sut.ExitUpgradeableReadLock();
			}

			[Test]
			public void IsTrueWhenWriteLockIsHeld()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();
				sut.EnterWriteLock();

				// Act
				bool result = sut.IsLockHeld();

				// Assert
				Assert.That(result, Is.True);

				// Cleanup
				sut.ExitWriteLock();
			}

			[Test]
			public void IsTrueWhenWriteLockIsHeldInUpgradeableReadLock()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();
				sut.EnterUpgradeableReadLock();
				sut.EnterWriteLock();

				// Act
				bool result = sut.IsLockHeld();

				// Assert
				Assert.That(result, Is.True);

				// Cleanup
				sut.ExitWriteLock();
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
					sut.IsLockHeld();
				}, Throws.ArgumentNullException);
			}
		}
	}
}
