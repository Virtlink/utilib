using System;
using System.Collections.Generic;

namespace Virtlink.Utilib.Collections
{
    /// <summary>
    /// Functions for working with stacks.
    /// </summary>
    public static class Stacks
    {
        /// <summary>
        /// Pushes a range of elements onto the stack.
        /// </summary>
        /// <typeparam name="T">The type of elements.</typeparam>
        /// <param name="stack">The stack.</param>
        /// <param name="elements">The elements to push.</param>
        /// <remarks>
        /// The first element is pushed first.
        /// </remarks>
        public static void PushRange<T>(this Stack<T> stack, IEnumerable<T> elements)
        {
            #region Contract
            if (stack == null)
                throw new ArgumentNullException(nameof(stack));
            if (elements == null)
                throw new ArgumentNullException(nameof(elements));
            #endregion

            foreach (var element in elements)
            {
                stack.Push(element);
            }
        }

        /// <summary>
        /// Returns the top element of the stack without removing it;
        /// or returns the default value when the stack is empty.
        /// </summary>
        /// <typeparam name="T">The type of elements.</typeparam>
        /// <param name="stack">The stack.</param>
        /// <returns>The top element of the stack;
        /// or the default value of <typeparamref name="T"/>.</returns>
        public static T PeekOrDefault<T>(this Stack<T> stack)
        {
            #region Contract
            if (stack == null)
                throw new ArgumentNullException(nameof(stack));
            #endregion

            if (stack.Count > 0)
                return stack.Peek();
            else
                return default(T);
        }
    }
}