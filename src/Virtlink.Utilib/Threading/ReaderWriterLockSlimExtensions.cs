using System;
using System.Diagnostics;
using System.Threading;

namespace Virtlink.Utilib.Threading
{
    /// <summary>
    /// Extension methods for working with <see cref="ReaderWriterLockSlim"/> objects.
    /// </summary>
    public static class ReaderWriterLockSlimExtensions
    {
        /// <summary>
        /// Determines whether the lock is currently held.
        /// </summary>
        /// <param name="locker">The locker.</param>
        /// <returns><see langword="true"/> when a write lock or an (upgradeable) read lock is held;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool IsLockHeld(this ReaderWriterLockSlim locker)
        {
            #region Contract
            if (locker == null)
                throw new ArgumentNullException(nameof(locker));
            #endregion

            return locker.IsReadLockHeld
                || locker.IsUpgradeableReadLockHeld
                || locker.IsWriteLockHeld;
        }

        /// <summary>
        /// Executes a function that reads a value from within a read lock.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="locker">The locker.</param>
        /// <param name="reader">The function that reads a value.</param>
        /// <returns>The read value.</returns>
        public static T LockedRead<T>(this ReaderWriterLockSlim locker, Func<T> reader)
        {
            #region Contract
            if (locker == null)
                throw new ArgumentNullException(nameof(locker));
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));
            #endregion

            T result;
            using (locker.Read())
            {
                result = reader();
            }
            return result;
        }

        /// <summary>
        /// Executes a function that reads a value from within a read lock.
        /// </summary>
        /// <typeparam name="T">The type of value to read.</typeparam>
        /// <param name="locker">The locker.</param>
        /// <param name="writer">The function that writer a value.</param>
        /// <param name="value">The value to write.</param>
        public static void LockedWrite<T>(this ReaderWriterLockSlim locker, Action<T> writer, T value)
        {
            #region Contract
            if (locker == null)
                throw new ArgumentNullException(nameof(locker));
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));
            #endregion

            using (locker.Write())
            {
                writer(value);
            }
        }

        /// <summary>
        /// Locks for reading.
        /// </summary>
        /// <param name="locker">The locker.</param>
        /// <returns>The lock.</returns>
        /// <remarks>
        /// Dispose the returned object to release the lock.
        /// </remarks>
        public static IDisposable Read(this ReaderWriterLockSlim locker)
        {
            #region Contract
            if (locker == null)
                throw new ArgumentNullException(nameof(locker));
            #endregion

            locker.EnterReadLock();
            return new Lock(locker.ExitReadLock);
        }

        /// <summary>
        /// Locks for reading upgradeable to writing.
        /// </summary>
        /// <param name="locker">The locker.</param>
        /// <returns>The lock.</returns>
        /// <remarks>
        /// Dispose the returned object to release the lock.
        /// </remarks>
        public static IDisposable UpgradeableRead(this ReaderWriterLockSlim locker)
        {
            #region Contract
            if (locker == null)
                throw new ArgumentNullException(nameof(locker));
            #endregion

            locker.EnterUpgradeableReadLock();
            return new Lock(locker.ExitUpgradeableReadLock);
        }

        /// <summary>
        /// Locks for writing.
        /// </summary>
        /// <param name="locker">The locker.</param>
        /// <returns>The lock.</returns>
        /// <remarks>
        /// Dispose the returned object to release the lock.
        /// </remarks>
        public static IDisposable Write(this ReaderWriterLockSlim locker)
        {
            #region Contract
            if (locker == null)
                throw new ArgumentNullException(nameof(locker));
            #endregion

            locker.EnterWriteLock();
            return new Lock(locker.ExitWriteLock);
        }

        /// <summary>
        /// A lock.
        /// </summary>
        private sealed class Lock : IDisposable
        {
            private readonly Action action;

            /// <summary>
            /// Initializes a new instance of the <see cref="Lock"/> class.
            /// </summary>
            public Lock(Action action)
            {
                #region Contract
                Debug.Assert(action != null);
                #endregion

                this.action = action;
            }

            /// <inheritdoc />
            public void Dispose()
            {
                this.action();
            }
        }
    }
}
