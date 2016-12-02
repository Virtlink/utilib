using NUnit.Framework;
using System;
using System.Threading;

namespace Virtlink.Utilib.Threading
{
	partial class ReaderWriterLockSlimExtensionsTests
	{
		[TestFixture]
		public sealed class UpgradeableReadTests
		{
			[Test]
			public void ReturnsDisposable()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.UpgradeableRead();

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
				var @lock = sut.UpgradeableRead();

				// Assert
				Assert.That(sut.IsUpgradeableReadLockHeld, Is.True);

				// Cleanup
				@lock.Dispose();
			}

			[Test]
			public void IsUnlockedWhenDisposed()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.UpgradeableRead();
				@lock.Dispose();

				// Assert
				Assert.That(sut.IsUpgradeableReadLockHeld, Is.False);
			}

			[Test]
			public void ThrowsWhenReaderWriterLockSlimIsNull()
			{
				// Arrange
				ReaderWriterLockSlim sut = null;

				// Act/Assert
				Assert.That(() =>
				{
					sut.UpgradeableRead();
				}, Throws.ArgumentNullException);
			}
		}
	}
}
