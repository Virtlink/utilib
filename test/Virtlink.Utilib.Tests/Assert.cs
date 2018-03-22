using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Virtlink.Utilib
{
    public class Assert : Xunit.Assert
    {
        /// <summary>
        /// Verifies that two sequences have the same items in the same quantities, using a default comparer.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared.</typeparam>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The value to be compared against.</param>
        /// <exception cref="Xunit.Sdk.EqualException">
        /// Thrown when the objects are not equal.
        /// </exception>
        public static void Equivalent<T>([CanBeNull] IEnumerable<T> expected, [CanBeNull] IEnumerable<T> actual)
        {
            Assert.Equal(expected?.OrderBy(v => v), actual?.OrderBy(v => v));
        }

        /// <summary>
        /// Verifies that two sequences have the same items in the same quantities, using a custom equatable comparer.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared</typeparam>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The value to be compared against.</param>
        /// <param name="comparer">The comparer used to compare the two objects.</param>
        /// <exception cref="Xunit.Sdk.EqualException">
        /// Thrown when the objects are not equal.
        /// </exception>
        public static void Equivalent<T>(IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer)
        {
            Assert.Equal(expected?.OrderBy(v => v), actual?.OrderBy(v => v), comparer);
        }

        /// <summary>
        /// Verifies that two sequences have the same items in the same quantities, using a custom equatable comparer.
        /// </summary>
        /// <typeparam name="T">The type of the objects to be compared</typeparam>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The value to be compared against.</param>
        /// <param name="comparer">The comparer used to compare the two objects.</param>
        /// <param name="orderer">The orderer to use to order the objects.</param>
        /// <exception cref="Xunit.Sdk.EqualException">
        /// Thrown when the objects are not equal.
        /// </exception>
        public static void Equivalent<T>(IEnumerable<T> expected, IEnumerable<T> actual, IEqualityComparer<T> comparer, IComparer<T> orderer)
        {
            Assert.Equal(expected?.OrderBy(v => v, orderer), actual?.OrderBy(v => v, orderer), comparer);
        }
    }
}
