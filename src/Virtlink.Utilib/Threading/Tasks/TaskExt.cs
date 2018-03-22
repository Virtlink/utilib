using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Virtlink.Utilib.Threading.Tasks
{
    /// <summary>
    /// Extension methods for working with tasks.
    /// </summary>
    public static class TaskExt
    {
        /// <summary>
        /// Runs the specified action in a task while handling exceptions.
        /// </summary>
        /// <param name="action">The action to run.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="exceptionHandler">The exception handler; or <see langword="null"/> to ignore all exceptions.</param>
        public static void RunSafe(Action action, CancellationToken cancellationToken,
            [CanBeNull] Action<Exception> exceptionHandler)
        {
            #region Contract
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            #endregion
            
            RunContinueWithHandler(Task.Run(action, cancellationToken), exceptionHandler);
        }

        /// <summary>
        /// Runs the specified action in a task while handling exceptions.
        /// </summary>
        /// <param name="action">The action to run.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public static void RunSafe(Action action, CancellationToken cancellationToken)
            => RunSafe(action, cancellationToken, null);

        /// <summary>
        /// Runs the specified action in a task while handling exceptions.
        /// </summary>
        /// <param name="action">The action to run.</param>
        /// <param name="exceptionHandler">The exception handler; or <see langword="null"/> to ignore all exceptions.</param>
        public static void RunSafe(Action action, [CanBeNull] Action<Exception> exceptionHandler)
            => RunSafe(action, default(CancellationToken), exceptionHandler);

        /// <summary>
        /// Runs the specified action in a task while handling exceptions.
        /// </summary>
        /// <param name="action">The action to run.</param>
        public static void RunSafe(Action action)
            => RunSafe(action, default(CancellationToken), null);

        // ---

        /// <summary>
        /// Runs the specified function in a task while handling exceptions.
        /// </summary>
        /// <param name="function">The function to run.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="exceptionHandler">The exception handler; or <see langword="null"/> to ignore all exceptions.</param>
        public static void RunSafe(Func<Task> function, CancellationToken cancellationToken,
            [CanBeNull] Action<Exception> exceptionHandler)
        {
            #region Contract
            if (function == null)
                throw new ArgumentNullException(nameof(function));
            #endregion

            RunContinueWithHandler(Task.Run(function, cancellationToken), exceptionHandler);
        }

        /// <summary>
        /// Runs the specified action in a task while handling exceptions.
        /// </summary>
        /// <param name="function">The function to run.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        public static void RunSafe(Func<Task> function, CancellationToken cancellationToken)
            => RunSafe(function, cancellationToken, null);

        /// <summary>
        /// Runs the specified action in a task while handling exceptions.
        /// </summary>
        /// <param name="function">The function to run.</param>
        /// <param name="exceptionHandler">The exception handler; or <see langword="null"/> to ignore all exceptions.</param>
        public static void RunSafe(Func<Task> function, [CanBeNull] Action<Exception> exceptionHandler)
            => RunSafe(function, default(CancellationToken), exceptionHandler);

        /// <summary>
        /// Runs the specified action in a task while handling exceptions.
        /// </summary>
        /// <param name="function">The function to run.</param>
        public static void RunSafe(Func<Task> function)
            => RunSafe(function, default(CancellationToken), null);
        
        // ---

        /// <summary>
        /// Runs the task to completion, ignoring any exceptions that occur.
        /// </summary>
        private static readonly Action<Task> defaultErrorContinuation =
            t => { try { t.Wait(); } catch (Exception) { /* All ignored. */ } };

        /// <summary>
        /// Runs a task with an exception handler.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="exceptionHandler">The exception handler.</param>
        private static void RunContinueWithHandler(Task task, [CanBeNull] Action<Exception> exceptionHandler)
        {
            #region Contract
            Debug.Assert(task != null);
            #endregion

            // Adapted from http://stackoverflow.com/a/38101760/146622

            var continuation = exceptionHandler != null
                ? t => exceptionHandler(t.Exception.GetBaseException())
                : TaskExt.defaultErrorContinuation;

            task.ContinueWith(
                continuation,
                TaskContinuationOptions.ExecuteSynchronously |
                TaskContinuationOptions.OnlyOnFaulted);
        }
    }
}
