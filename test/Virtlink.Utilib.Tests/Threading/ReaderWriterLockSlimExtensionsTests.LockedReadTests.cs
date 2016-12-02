using NUnit.Framework;
using System;
using System.Threading;

namespace Virtlink.Utilib.Threading
{
	partial class ReaderWriterLockSlimExtensionsTests
	{
		[TestFixture]
		public sealed class LockedReadTests
		{
			[Test]
			public void ExecutesAFunctionInAReadLock()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				bool result = sut.LockedRead(() => sut.IsReadLockHeld);

				// Assert
				Assert.That(result, Is.True);
			}

			[Test]
			public void ThrowsWhenReaderWriterLockSlimIsNull()
			{
				// Arrange
				ReaderWriterLockSlim sut = null;

				// Act/Assert
				Assert.That(() =>
				{
					sut.LockedRead(() => true);
				}, Throws.ArgumentNullException);
			}

			[Test]
			public void ThrowsWhenFunctionIsNull()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act/Assert
				Assert.That(() =>
				{
					sut.LockedRead((Func<bool>)null);
				}, Throws.ArgumentNullException);
			}
		}
	}
}
