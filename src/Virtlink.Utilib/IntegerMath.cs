using System;

namespace Virtlink.Utilib
{
    /// <summary>
    /// Math operations on integers.
    /// </summary>
    public static class IntegerMath
    {
        /// <summary>
        /// Calculates the dividend modulo the divisor.
        /// </summary>
        /// <param name="dividend">The dividend.</param>
        /// <param name="divisor">The divisor.</param>
        /// <returns>The result of <paramref name="dividend"/> modulo <paramref name="divisor"/>.</returns>
        /// <remarks>
        /// <para>When <paramref name="dividend"/> is positive, this method
        /// performs the same operation as <c>dividend % divisor</c>. However,
        /// when <paramref name="dividend"/> is negative, this method
        /// returns the modulo instead of the remainder. The result will therefore
        /// always be positive.</para>
        /// <para>The sign of the divisor is ignored.</para>
        /// </remarks>
        /// <exception cref="DivideByZeroException">
        /// The <paramref name="divisor"/> cannot be zero.
        /// </exception>
        public static int Modulo(int dividend, int divisor)
        {
            #region Contract
            if (divisor == 0)
                throw new DivideByZeroException("The divisor cannot be zero.");
            #endregion

            if (divisor < 0)
                divisor = -divisor;

            int r = dividend % divisor;
            return r >= 0 ? r : r + divisor;
        }

        /// <summary>
        /// Calculates the dividend modulo the divisor.
        /// </summary>
        /// <param name="dividend">The dividend.</param>
        /// <param name="divisor">The divisor.</param>
        /// <returns>The result of <paramref name="dividend"/> modulo <paramref name="divisor"/>.</returns>
        /// <remarks>
        /// <para>When <paramref name="dividend"/> is positive, this method
        /// performs the same operation as <c>dividend % divisor</c>. However,
        /// when <paramref name="dividend"/> is negative, this method
        /// returns the modulo instead of the remainder. The result will therefore
        /// always be positive.</para>
        /// <para>The sign of the divisor is ignored.</para>
        /// </remarks>
        /// <exception cref="DivideByZeroException">
        /// The <paramref name="divisor"/> cannot be zero.
        /// </exception>
        public static long Modulo(long dividend, long divisor)
        {
            #region Contract
            if (divisor == 0)
                throw new DivideByZeroException("The divisor cannot be zero.");
            #endregion

            if (divisor < 0)
                divisor = -divisor;

            long r = dividend % divisor;
            return r >= 0 ? r : r + divisor;
        }


        /// <summary>
        /// Clamps an integer value between two bounds.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="lowerBound">The inclusive lower bound.</param>
        /// <param name="upperBound">The inclusive upper bound.</param>
        /// <returns>The clamped value.</returns>
        public static int Clamp(int value, int lowerBound, int upperBound)
        {
            #region Contract
            if (upperBound < lowerBound)
                throw new ArgumentOutOfRangeException(nameof(upperBound),
                    "The lower bound must be less than or equal to the upper bound.");
            #endregion

            return Math.Min(upperBound, Math.Max(lowerBound, value));
        }

        /// <summary>
        /// Clamps an integer value between two bounds.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="lowerBound">The inclusive lower bound.</param>
        /// <param name="upperBound">The inclusive upper bound.</param>
        /// <returns>The clamped value.</returns>
        public static long Clamp(long value, long lowerBound, long upperBound)
        {
            #region Contract
            if (upperBound < lowerBound)
                throw new ArgumentOutOfRangeException(nameof(upperBound),
                    "The lower bound must be less than or equal to the upper bound.");
            #endregion

            return Math.Min(upperBound, Math.Max(lowerBound, value));
        }

        /// <summary>
        /// Clamps an integer value between two bounds.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="lowerBound">The inclusive lower bound.</param>
        /// <param name="upperBound">The inclusive upper bound.</param>
        /// <returns>The clamped value.</returns>
        public static uint Clamp(uint value, uint lowerBound, uint upperBound)
        {
            #region Contract
            if (upperBound < lowerBound)
                throw new ArgumentOutOfRangeException(nameof(upperBound),
                    "The lower bound must be less than or equal to the upper bound.");
            #endregion

            return Math.Min(upperBound, Math.Max(lowerBound, value));
        }

        /// <summary>
        /// Clamps an integer value between two bounds.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="lowerBound">The inclusive lower bound.</param>
        /// <param name="upperBound">The inclusive upper bound.</param>
        /// <returns>The clamped value.</returns>
        public static ulong Clamp(ulong value, ulong lowerBound, ulong upperBound)
        {
            #region Contract
            if (upperBound < lowerBound)
                throw new ArgumentOutOfRangeException(nameof(upperBound),
                    "The lower bound must be less than or equal to the upper bound.");
            #endregion

            return Math.Min(upperBound, Math.Max(lowerBound, value));
        }
    }
}