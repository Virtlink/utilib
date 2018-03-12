using System;

namespace Virtlink.Utilib
{
    /// <summary>
    /// Binary and bit-wise math operations,
    /// and operations that use powers of two.
    /// </summary>
    public static class BinaryMath
    {
        /// <summary>
        /// Rounds the specified value to the next power of two.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <returns>The next power of two.</returns>
        /// <remarks>
        /// For positive values, this function returns the next higher power of two.
        /// For the value 0, this function returns 1.
        /// For negative values, this function returns the next lower power of two.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// <paramref name="value"/> is greater than 0x40000000.
        /// </exception>
        public static int RoundToNextPowerOfTwo(int value)
        {
            return value != 0 ? RoundToNextPowerOfTwoOrZero(value) : 1;
        }

        /// <summary>
        /// Rounds the specified value to the next power of two;
        /// or returns zero.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <returns>The next power of two; or zero.</returns>
        /// <remarks>
        /// For positive values, this function returns the next higher power of two.
        /// For the value 0, this function returns 0.
        /// For negative values, this function returns the next lower power of two.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// <paramref name="value"/> is greater than 0x40000000.
        /// </exception>
        public static int RoundToNextPowerOfTwoOrZero(int value)
        {
            if (value > ((int)1 << 30))
                throw new OverflowException("Rounding the input value would overflow the integer type.");

            bool negative = value < 0;

            unchecked
            {
                if (negative) value = -value;

                value = (int)RoundToNextPowerOfTwoOrZero((uint)value);

                if (negative) value = -value;
            }

            return value;
        }

        /// <summary>
        /// Rounds the specified value to the next power of two.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <returns>The next power of two.</returns>
        /// <remarks>
        /// For positive values, this function returns the next higher power of two.
        /// For the value 0, this function returns 1.
        /// For negative values, this function returns the next lower power of two.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// <paramref name="value"/> is greater than 0x4000000000000000.
        /// </exception>
        public static long RoundToNextPowerOfTwo(long value)
        {
            return value != 0 ? RoundToNextPowerOfTwoOrZero(value) : 1;
        }

        /// <summary>
        /// Rounds the specified value to the next power of two;
        /// or returns zero.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <returns>The next power of two; or zero.</returns>
        /// <remarks>
        /// For positive values, this function returns the next higher power of two.
        /// For the value 0, this function returns 0.
        /// For negative values, this function returns the next lower power of two.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// <paramref name="value"/> is greater than 0x40000000.
        /// </exception>
        public static long RoundToNextPowerOfTwoOrZero(long value)
        {
            if (value > ((long)1 << 62))
                throw new OverflowException("Rounding the input value would overflow the integer type.");

            bool negative = value < 0;

            unchecked
            {
                if (negative) value = -value;

                value = (long)RoundToNextPowerOfTwoOrZero((ulong)value);

                if (negative) value = -value;
            }

            return value;
        }

        /// <summary>
        /// Rounds the specified value to the next power of two.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <returns>The next power of two.</returns>
        /// <remarks>
        /// For positive values, this function returns the next higher power of two.
        /// For the value 0, this function returns 1.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// <paramref name="value"/> is greater than 0x40000000.
        /// </exception>
        public static uint RoundToNextPowerOfTwo(uint value)
        {
            return value != 0 ? RoundToNextPowerOfTwoOrZero(value) : 1;
        }

        /// <summary>
        /// Rounds the specified value to the next power of two;
        /// or returns zero.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <returns>The next power of two; or zero.</returns>
        /// <remarks>
        /// For positive values, this function returns the next higher power of two.
        /// For the value 0, this function returns 0.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// <paramref name="value"/> is greater than 0x80000000.
        /// </exception>
        public static uint RoundToNextPowerOfTwoOrZero(uint value)
        {
            if (value > ((uint)1 << 31))
                throw new OverflowException("Rounding the input value would overflow the integer type.");

            // Based on: Bit Twiddling Hacks
            // http://graphics.stanford.edu/~seander/bithacks.html#RoundUpPowerOf2

            unchecked
            {
                value--;
                value |= value >> 1;
                value |= value >> 2;
                value |= value >> 4;
                value |= value >> 8;
                value |= value >> 16;
                value++;
            }

            return value;
        }

        /// <summary>
        /// Rounds the specified value to the next power of two.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <returns>The next power of two.</returns>
        /// <remarks>
        /// For positive values, this function returns the next higher power of two.
        /// For the value 0, this function returns 1.
        /// For negative values, this function returns the next lower power of two.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// <paramref name="value"/> is greater than 0x4000000000000000.
        /// </exception>
        public static ulong RoundToNextPowerOfTwo(ulong value)
        {
            return value != 0 ? RoundToNextPowerOfTwoOrZero(value) : 1;
        }

        /// <summary>
        /// Rounds the specified value to the next power of two;
        /// or returns zero.
        /// </summary>
        /// <param name="value">The value to round.</param>
        /// <returns>The next power of two; or zero.</returns>
        /// <remarks>
        /// For positive values, this function returns the next higher power of two.
        /// For the value 0, this function returns 0.
        /// For negative values, this function returns the next lower power of two.
        /// </remarks>
        /// <exception cref="OverflowException">
        /// <paramref name="value"/> is greater than 0x80000000.
        /// </exception>
        public static ulong RoundToNextPowerOfTwoOrZero(ulong value)
        {
            if (value > ((ulong)1 << 63))
                throw new OverflowException("Rounding the input value would overflow the integer type.");

            // Based on: Bit Twiddling Hacks
            // http://graphics.stanford.edu/~seander/bithacks.html#RoundUpPowerOf2

            unchecked
            {
                value--;
                value |= value >> 1;
                value |= value >> 2;
                value |= value >> 4;
                value |= value >> 8;
                value |= value >> 16;
                value |= value >> 32;
                value++;
            }

            return value;
        }

        /// <summary>
        /// Determines whether a value is a power of two, or zero.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns><see langword="true"/> when <paramref name="value"/> is a power of two,
        /// or zero; otherwise, <see langword="false"/>.</returns>
        public static bool IsPowerOfTwoOrZero(ulong value)
        {
            return (value & (value - 1)) == 0;
        }

        /// <summary>
        /// Determines whether a value is a power of two.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns><see langword="true"/> when <paramref name="value"/> is a power of two;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool IsPowerOfTwo(ulong value)
        {
            return value != 0 && BinaryMath.IsPowerOfTwoOrZero(value);
        }


        /// <summary>
        /// Gets an integer with the most significant set bit set to 1 and all other bits set to 0.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns>An integer that has the most significant bit set in <paramref name="value"/> set to 1,
        /// and the other bits to 0.</returns>
        public static uint SetMostSignificantBit(uint value)
        {
            // Based on: Hacker's Delight
            // http://stackoverflow.com/a/53184/146622

            uint n = value;

            n |= (n >> 1);
            n |= (n >> 2);
            n |= (n >> 4);
            n |= (n >> 8);
            n |= (n >> 16);

            return n - (n >> 1);
        }

        /// <summary>
        /// Gets an integer with the most significant set bit set to 1 and all other bits set to 0.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns>An integer that has the most significant bit set in <paramref name="value"/> set to 1,
        /// and the other bits to 0.</returns>
        public static ulong SetMostSignificantBit(ulong value)
        {
            // Based on: Hacker's Delight
            // http://stackoverflow.com/a/53184/146622

            ulong n = value;

            n |= (n >> 1);
            n |= (n >> 2);
            n |= (n >> 4);
            n |= (n >> 8);
            n |= (n >> 16);
            n |= (n >> 32);

            return n - (n >> 1);
        }


        /// <summary>
        /// Calculates the padding needed to get the specified offset to a multiple of the specified boundary.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="boundary">The boundary.</param>
        /// <returns>The number of padding bytes to add.</returns>
        public static int GetPadding(int offset, int boundary)
        {
            #region Contract
            if (boundary <= 0)
                throw new ArgumentOutOfRangeException(nameof(boundary));
            #endregion

            if (BinaryMath.IsPowerOfTwoOrZero(boundary))
                return (int)BinaryMath.GetPadding(unchecked((uint)offset), boundary);
            else
                return IntegerMath.Modulo(boundary - IntegerMath.Modulo(offset, boundary), boundary);
        }

        /// <summary>
        /// Calculates the padding needed to get the specified offset to a multiple of the specified boundary.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="boundary">The boundary.</param>
        /// <returns>The number of padding bytes to add.</returns>
        public static uint GetPadding(uint offset, int boundary)
        {
            #region Contract
            if (boundary <= 0)
                throw new ArgumentOutOfRangeException(nameof(boundary));
            #endregion

            uint b = unchecked((uint)boundary);
            if (BinaryMath.IsPowerOfTwoOrZero(boundary))
                return (~offset + 1) & (b - 1);
            else
                return (b - (offset % b)) % b;
        }

        /// <summary>
        /// Calculates the padding needed to get the specified offset to a multiple of the specified boundary.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="boundary">The boundary.</param>
        /// <returns>The number of padding bytes to add.</returns>
        public static long GetPadding(long offset, int boundary)
        {
            #region Contract
            if (boundary <= 0)
                throw new ArgumentOutOfRangeException(nameof(boundary));
            #endregion

            if (BinaryMath.IsPowerOfTwoOrZero(boundary))
                return (long)BinaryMath.GetPadding(unchecked((ulong)offset), boundary);
            else
                return IntegerMath.Modulo(boundary - IntegerMath.Modulo(offset, boundary), boundary);
        }

        /// <summary>
        /// Calculates the padding needed to get the specified offset to a multiple of the specified boundary.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="boundary">The boundary.</param>
        /// <returns>The number of padding bytes to add.</returns>
        public static ulong GetPadding(ulong offset, int boundary)
        {
            #region Contract
            if (boundary <= 0)
                throw new ArgumentOutOfRangeException(nameof(boundary));
            #endregion

            ulong b = unchecked((ulong)boundary);
            if (BinaryMath.IsPowerOfTwoOrZero(boundary))
                return (~offset + 1) & (b - 1);
            else
                return (b - (offset % b)) % b;
        }


        /// <summary>
        /// Aligns the specified offset to the next boundary.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="boundary">The boundary.</param>
        /// <returns>The new offset.</returns>
        public static int Align(int offset, int boundary)
        {
            #region Contract
            if (boundary <= 0)
                throw new ArgumentOutOfRangeException(nameof(boundary));
            #endregion

            return checked(offset + BinaryMath.GetPadding(offset, boundary));
        }

        /// <summary>
        /// Aligns the specified offset to the next boundary.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="boundary">The boundary.</param>
        /// <returns>The new offset.</returns>
        public static uint Align(uint offset, int boundary)
        {
            #region Contract
            if (boundary <= 0)
                throw new ArgumentOutOfRangeException(nameof(boundary));
            #endregion

            return checked(offset + BinaryMath.GetPadding(offset, boundary));
        }

        /// <summary>
        /// Aligns the specified offset to the next boundary.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="boundary">The boundary.</param>
        /// <returns>The new offset.</returns>
        public static long Align(long offset, int boundary)
        {
            #region Contract
            if (boundary <= 0)
                throw new ArgumentOutOfRangeException(nameof(boundary));
            #endregion

            return checked(offset + BinaryMath.GetPadding(offset, boundary));
        }

        /// <summary>
        /// Aligns the specified offset to the next boundary.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="boundary">The boundary.</param>
        /// <returns>The new offset.</returns>
        public static ulong Align(ulong offset, int boundary)
        {
            #region Contract
            if (boundary <= 0)
                throw new ArgumentOutOfRangeException(nameof(boundary));
            #endregion

            return checked(offset + BinaryMath.GetPadding(offset, boundary));
        }

        #region IsPowerOfTwoOrZero() Overloads
        /// <summary>
        /// Determines whether a value is a positive power of two, or zero.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns><see langword="true"/> when <paramref name="value"/> is a positive power of two,
        /// or zero; otherwise, <see langword="false"/>.</returns>
        public static bool IsPowerOfTwoOrZero(long value)
        {
            return value >= 0 && BinaryMath.IsPowerOfTwoOrZero(unchecked((ulong)value));
        }

        /// <summary>
        /// Determines whether a value is a power of two, or zero.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns><see langword="true"/> when <paramref name="value"/> is a power of two,
        /// or zero; otherwise, <see langword="false"/>.</returns>
        public static bool IsPowerOfTwoOrZero(uint value)
        {
            return BinaryMath.IsPowerOfTwoOrZero((ulong)value);
        }

        /// <summary>
        /// Determines whether a value is a positive power of two, or zero.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns><see langword="true"/> when <paramref name="value"/> is a positive power of two,
        /// or zero; otherwise, <see langword="false"/>.</returns>
        public static bool IsPowerOfTwoOrZero(int value)
        {
            return BinaryMath.IsPowerOfTwoOrZero((long)value);
        }
        #endregion

        #region IsPowerOfTwo() Overloads
        /// <summary>
        /// Determines whether a value is a positive power of two.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns><see langword="true"/> when <paramref name="value"/> is a positive power of two;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool IsPowerOfTwo(long value)
        {
            return value > 0 && BinaryMath.IsPowerOfTwoOrZero(unchecked((ulong)value));
        }

        /// <summary>
        /// Determines whether a value is a power of two.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns><see langword="true"/> when <paramref name="value"/> is a power of two;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool IsPowerOfTwo(uint value)
        {
            return BinaryMath.IsPowerOfTwo((ulong)value);
        }

        /// <summary>
        /// Determines whether a value is a positive power of two.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns><see langword="true"/> when <paramref name="value"/> is a positive power of two;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool IsPowerOfTwo(int value)
        {
            return BinaryMath.IsPowerOfTwo((long)value);
        }
        #endregion

        #region SetMostSignificantBit() Overloads
        /// <summary>
        /// Gets an integer with the most significant set bit set to 1 and all other bits set to 0.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns>An integer that has the most significant bit set in <paramref name="value"/> set to 1,
        /// and the other bits to 0.</returns>
        /// <remarks>
        /// The sign of <paramref name="value"/> is ignored.
        /// </remarks>
        public static int SetMostSignificantBit(int value)
        {
            if (value < 0)
                throw new NotSupportedException("The semantics of negative values have not been defined.");

            bool negative = value < 0;

            unchecked
            {
                if (negative) value = -value;

                value = (int)SetMostSignificantBit((uint)value);

                if (negative) value = -value;
            }

            return value;
        }

        /// <summary>
        /// Gets an integer with the most significant set bit set to 1 and all other bits set to 0.
        /// </summary>
        /// <param name="value">The value to test.</param>
        /// <returns>An integer that has the most significant bit set in <paramref name="value"/> set to 1,
        /// and the other bits to 0.</returns>
        /// <remarks>
        /// The sign of <paramref name="value"/> is ignored.
        /// </remarks>
        public static long SetMostSignificantBit(long value)
        {
            if (value < 0)
                throw new NotSupportedException("The semantics of negative values have not been defined.");

            bool negative = value < 0;

            unchecked
            {
                if (negative) value = -value;

                value = (long)SetMostSignificantBit((ulong)value);

                if (negative) value = -value;
            }

            return value;
        }
        #endregion

        /// <summary>
        /// Counts the number of bits set in the specified value.
        /// </summary>
        /// <param name="value">The value whose bits to count.</param>
        /// <returns>The number of bits that are set to 1.</returns>
        public static int CountSetBits(ulong value)
        {
            // Based on: Bit Twiddling Hacks
            // https://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel

            unchecked
            {
                ulong v = value;
                v = v - ((v >> 1) & 0x5555555555555555UL);
                v = (v & 0x3333333333333333UL) + ((v >> 2) & 0x3333333333333333UL);
                v = (v + (v >> 4)) & 0xF0F0F0F0F0F0F0FUL;
                return (int) ((v * 0x101010101010101UL) >> 56);
            }
        }

        /// <summary>
        /// Counts the number of bits set in the specified value.
        /// </summary>
        /// <param name="value">The value whose bits to count.</param>
        /// <returns>The number of bits that are set to 1.</returns>
        public static int CountSetBits(uint value)
        {
            // Based on: Bit Twiddling Hacks
            // https://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel

            unchecked
            {
                uint v = value;
                v = v - ((v >> 1) & 0x55555555U);
                v = (v & 0x33333333U) + ((v >> 2) & 0x33333333U);
                v = (v + (v >> 4)) & 0x0F0F0F0FU;
                return (int) ((v * 0x01010101U) >> 24);
            }
        }

        /// <summary>
        /// Counts the number of bits set in the specified value.
        /// </summary>
        /// <param name="value">The value whose bits to count.</param>
        /// <returns>The number of bits that are set to 1.</returns>
        public static int CountSetBits(long value)
            => CountSetBits(unchecked((ulong)value));

        /// <summary>
        /// Counts the number of bits set in the specified value.
        /// </summary>
        /// <param name="value">The value whose bits to count.</param>
        /// <returns>The number of bits that are set to 1.</returns>
        public static int CountSetBits(int value)
            => CountSetBits(unchecked((uint)value));

        /// <summary>
        /// Counts the number of bits set in the specified value.
        /// </summary>
        /// <param name="value">The value whose bits to count.</param>
        /// <returns>The number of bits that are set to 1.</returns>
        public static int CountSetBits(short value)
            => CountSetBits(unchecked((uint)(ushort)value));

        /// <summary>
        /// Counts the number of bits set in the specified value.
        /// </summary>
        /// <param name="value">The value whose bits to count.</param>
        /// <returns>The number of bits that are set to 1.</returns>
        public static int CountSetBits(ushort value)
            => CountSetBits(unchecked((uint)value));

        /// <summary>
        /// Counts the number of bits set in the specified value.
        /// </summary>
        /// <param name="value">The value whose bits to count.</param>
        /// <returns>The number of bits that are set to 1.</returns>
        public static int CountSetBits(sbyte value)
            => CountSetBits(unchecked((uint)(byte)value));

        /// <summary>
        /// Counts the number of bits set in the specified value.
        /// </summary>
        /// <param name="value">The value whose bits to count.</param>
        /// <returns>The number of bits that are set to 1.</returns>
        public static int CountSetBits(byte value)
            => CountSetBits(unchecked((uint)value));
    }
}