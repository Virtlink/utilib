using Xunit;
using System;
using System.Threading;

namespace Virtlink.Utilib.Threading
{
	partial class ReaderWriterLockSlimExtensionsTests
    {
        /// <summary>
        /// Tests the <see cref="ReaderWriterLockSlimExtensions.LockedRead"/> method.
        /// </summary>
        public sealed class LockedReadTests
		{
			[Fact]
			public void ShouldExecuteAFunctionInAReadLock()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

				// Act
				bool result = sut.LockedRead(() => sut.IsReadLockHeld);

				// Assert
				Assert.True(result);
			}

			[Fact]
			public void ShouldThrowArgumentNullException_WhenReaderWriterLockSlimIsNull()
			{
				// Arrange
				ReaderWriterLockSlim sut = null;

			    // Act
			    var exception = Record.Exception(() =>
			    {
			        sut.LockedRead(() => true);
			    });

			    // Assert
			    Assert.IsType<ArgumentNullException>(exception);
			}

			[Fact]
			public void ShouldThrowArgumentNullException_WhenFunctionIsNull()
			{
				// Arrange
				var sut = new ReaderWriterLockSlim();

			    // Act
			    var exception = Record.Exception(() =>
			    {
			        sut.LockedRead((Func<bool>)null);
			    });

			    // Assert
			    Assert.IsType<ArgumentNullException>(exception);
			}
		}
	}
}
