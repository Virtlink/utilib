using NUnit.Framework;
using System;
using System.Threading;

namespace Virtlink.Utilib.Threading
{
	partial class ReaderWriterLockSlimExtensionsTests
	{
		[TestFixture]
		public sealed class ReadTests
		{
			[Test]
			public void ReturnsDisposable()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.Read();

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
				var @lock = sut.Read();

				// Assert
				Assert.That(sut.IsReadLockHeld, Is.True);

				// Cleanup
				@lock.Dispose();
			}

			[Test]
			public void IsUnlockedWhenDisposed()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				var @lock = sut.Read();
				@lock.Dispose();

				// Assert
				Assert.That(sut.IsReadLockHeld, Is.False);
			}

			[Test]
			public void ThrowsWhenReaderWriterLockSlimIsNull()
			{
				// Arrange
				ReaderWriterLockSlim sut = null;

				// Act/Assert
				Assert.That(() =>
				{
					sut.Read();
				}, Throws.ArgumentNullException);
			}
		}
	}
}
