using NUnit.Framework;
using System.Threading;

namespace Virtlink.Utilib.Threading
{
	partial class ReaderWriterLockSlimExtensionsTests
	{
		[TestFixture]
		public sealed class LockedWriteTests
		{
			[Test]
			public void ExecutesAFunctionInAWriteLock()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				bool held = false;
				sut.LockedWrite(x => held = sut.IsWriteLockHeld, true);

				// Assert
				Assert.That(held, Is.True);
			}

			[Test]
			public void ThrowsWhenReaderWriterLockSlimIsNull()
			{
				// Arrange
				ReaderWriterLockSlim sut = null;

				// Act/Assert
				Assert.That(() =>
				{
					sut.LockedWrite(x => { }, false);
				}, Throws.ArgumentNullException);
			}

			[Test]
			public void ThrowsWhenActionnIsNull()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act/Assert
				Assert.That(() =>
				{
					sut.LockedWrite(null, false);
				}, Throws.ArgumentNullException);
			}
		}
	}
}
