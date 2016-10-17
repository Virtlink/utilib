using System;
using System.Collections.Generic;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Functions for working with queues.
    /// </summary>
    public static class Queues
    {
        /// <summary>
		/// Enqueues a range of elements onto the queue.
		/// </summary>
		/// <typeparam name="T">The type of elements.</typeparam>
		/// <param name="queue">The queue.</param>
		/// <param name="elements">The elements to enqueue.</param>
		/// <remarks>
		/// The first element is enqueued first.
		/// </remarks>
		public static void EnqueueRange<T>(this Queue<T> queue, IEnumerable<T> elements)
        {
            #region Contract
            if (queue == null)
                throw new ArgumentNullException(nameof(queue));
            if (elements == null)
                throw new ArgumentNullException(nameof(elements));
            #endregion

            foreach (var element in elements)
            {
                queue.Enqueue(element);
            }
        }

        /// <summary>
        /// Returns the front element of the queue without removing it;
        /// or returns the default value when the queue is empty.
        /// </summary>
        /// <typeparam name="T">The type of elements.</typeparam>
        /// <param name="queue">The queue.</param>
        /// <returns>The front element of the queue;
        /// or the default value of <typeparamref name="T"/>.</returns>
        public static T PeekOrDefault<T>(this Queue<T> queue)
        {
            #region Contract
            if (queue == null)
                throw new ArgumentNullException(nameof(queue));
            #endregion

            if (queue.Count > 0)
                return queue.Peek();
            else
                return default(T);
        }
    }
}
