using System;
using Xunit;
using System.Threading;

namespace Virtlink.Utilib.Threading
{
	partial class ReaderWriterLockSlimExtensionsTests
    {
        /// <summary>
        /// Tests the <see cref="ReaderWriterLockSlimExtensions.LockedWrite"/> method.
        /// </summary>
        public sealed class LockedWriteTests
		{
			[Fact]
			public void ShouldExecuteAFunctionInAWriteLock()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				bool held = false;
				sut.LockedWrite(x => held = sut.IsWriteLockHeld, true);

				// Assert
				Assert.True(held);
			}

			[Fact]
			public void ShouldThrowArgumentNullException_WhenReaderWriterLockSlimIsNull()
			{
				// Arrange
				ReaderWriterLockSlim sut = null;

			    // Act
			    var exception = Record.Exception(() =>
			    {
			        sut.LockedWrite(x => { }, false);
			    });

			    // Assert
			    Assert.IsType<ArgumentNullException>(exception);
			}

			[Fact]
			public void ShouldThrowArgumentNullException_WhenActionnIsNull()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

			    // Act
			    var exception = Record.Exception(() =>
			    {
			        sut.LockedWrite(null, false);
			    });

			    // Assert
			    Assert.IsType<ArgumentNullException>(exception);
			}
		}
	}
}
