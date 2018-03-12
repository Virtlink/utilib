using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Virtlink.Utilib
{
	partial class BinaryMathTests
	{
        /// <summary>
        /// Unit tests for the <see cref="BinaryMath.CountBitsSet"/> functions.
        /// </summary>
        [SuppressMessage("ReSharper", "RedundantCast")]
        public sealed class CountBitsSetTests
        {
            [Theory]
            [InlineData((long)-0x7fffffffffffffff,  2)]
            [InlineData((long)-0x0f0f0f0f0f0f0f0f, 33)]
            [InlineData((long)-0x5555555555555555, 33)]
            [InlineData((long)-0x7aaaaaaaaaaaaaaa, 31)]
            [InlineData((long)-0x7c9c9c9c9c9c9c9c, 30)]
            [InlineData((long)-0x0001000100010001, 61)]
            [InlineData((long)-0x7badf00ddeadbeef, 23)]
            [InlineData((long)-8,                  61)]
            [InlineData((long)-7,                  62)]
            [InlineData((long)-6,                  62)]
            [InlineData((long)-5,                  63)]
            [InlineData((long)-4,                  62)]
            [InlineData((long)-3,                  63)]
            [InlineData((long)-2,                  63)]
            [InlineData((long)-1,                  64)]
            [InlineData((long)0,                    0)]
            [InlineData((long)1,                    1)]
            [InlineData((long)2,                    1)]
            [InlineData((long)3,                    2)]
            [InlineData((long)4,                    1)]
            [InlineData((long)5,                    2)]
            [InlineData((long)6,                    2)]
            [InlineData((long)7,                    3)]
            [InlineData((long)8,                    1)]
            [InlineData((long)0x7badf00ddeadbeef,  42)]
            [InlineData((long)0x0001000100010001,   4)]
            [InlineData((long)0x7c9c9c9c9c9c9c9c,  33)]
            [InlineData((long)0x7aaaaaaaaaaaaaaa,  33)]
            [InlineData((long)0x5555555555555555,  32)]
            [InlineData((long)0x0f0f0f0f0f0f0f0f,  32)]
            [InlineData((long)0x7fffffffffffffff,  63)]
            public void Int64_Overload(long value, int expected)
            {
                // Act
                var actual = BinaryMath.CountSetBits(value);

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory]
            [InlineData((ulong)0,                   0)]
            [InlineData((ulong)1,                   1)]
            [InlineData((ulong)2,                   1)]
            [InlineData((ulong)3,                   2)]
            [InlineData((ulong)4,                   1)]
            [InlineData((ulong)5,                   2)]
            [InlineData((ulong)6,                   2)]
            [InlineData((ulong)7,                   3)]
            [InlineData((ulong)8,                   1)]
            [InlineData((ulong)0x7badf00ddeadbeef, 42)]
            [InlineData((ulong)0x0001000100010001,  4)]
            [InlineData((ulong)0x7c9c9c9c9c9c9c9c, 33)]
            [InlineData((ulong)0x7aaaaaaaaaaaaaaa, 33)]
            [InlineData((ulong)0x5555555555555555, 32)]
            [InlineData((ulong)0x0f0f0f0f0f0f0f0f, 32)]
            [InlineData((ulong)0x7fffffffffffffff, 63)]
            [InlineData((ulong)0x8000000000000001,  2)]
            [InlineData((ulong)0xF0F0F0F0F0F0F0F1, 33)]
            [InlineData((ulong)0xAAAAAAAAAAAAAAAB, 33)]
            [InlineData((ulong)0x8555555555555556, 31)]
            [InlineData((ulong)0x8363636363636364, 30)]
            [InlineData((ulong)0xFFFEFFFEFFFEFFFF, 61)]
            [InlineData((ulong)0x84520FF221524111, 23)]
            [InlineData((ulong)0xFFFFFFFFFFFFFFF8, 61)]
            [InlineData((ulong)0xFFFFFFFFFFFFFFF9, 62)]
            [InlineData((ulong)0xFFFFFFFFFFFFFFFA, 62)]
            [InlineData((ulong)0xFFFFFFFFFFFFFFFB, 63)]
            [InlineData((ulong)0xFFFFFFFFFFFFFFFC, 62)]
            [InlineData((ulong)0xFFFFFFFFFFFFFFFD, 63)]
            [InlineData((ulong)0xFFFFFFFFFFFFFFFE, 63)]
            [InlineData((ulong)0xFFFFFFFFFFFFFFFF, 64)]
            public void UInt64_Overload(ulong value, int expected)
            {
                // Act
                var actual = BinaryMath.CountSetBits(value);

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory]
            [InlineData((int)-0x7fffffff,  2)]
            [InlineData((int)-0x0f0f0f0f, 17)]
            [InlineData((int)-0x55555555, 17)]
            [InlineData((int)-0x7aaaaaaa, 15)]
            [InlineData((int)-0x7c9c9c9c, 14)]
            [InlineData((int)-0x00010001, 31)]
            [InlineData((int)-0x7eadbeef,  9)]
            [InlineData((int)-8,          29)]
            [InlineData((int)-7,          30)]
            [InlineData((int)-6,          30)]
            [InlineData((int)-5,          31)]
            [InlineData((int)-4,          30)]
            [InlineData((int)-3,          31)]
            [InlineData((int)-2,          31)]
            [InlineData((int)-1,          32)]
            [InlineData((int)0,            0)]
			[InlineData((int)1,            1)]
			[InlineData((int)2,            1)]
			[InlineData((int)3,            2)]
			[InlineData((int)4,            1)]
			[InlineData((int)5,            2)]
			[InlineData((int)6,            2)]
			[InlineData((int)7,            3)]
			[InlineData((int)8,            1)]
            [InlineData((int)0x7eadbeef,  24)]
            [InlineData((int)0x00010001,   2)]
            [InlineData((int)0x7c9c9c9c,  17)]
            [InlineData((int)0x7aaaaaaa,  17)]
            [InlineData((int)0x55555555,  16)]
            [InlineData((int)0x0f0f0f0f,  16)]
            [InlineData((int)0x7fffffff,  31)]
            public void Int32_Overload(int value, int expected)
            {
                // Act
                var actual = BinaryMath.CountSetBits(value);

                // Assert
                Assert.Equal(expected, actual);
			}

            [Theory]
            [InlineData((uint)0,           0)]
            [InlineData((uint)1,           1)]
            [InlineData((uint)2,           1)]
            [InlineData((uint)3,           2)]
            [InlineData((uint)4,           1)]
            [InlineData((uint)5,           2)]
            [InlineData((uint)6,           2)]
            [InlineData((uint)7,           3)]
            [InlineData((uint)8,           1)]
            [InlineData((uint)0x7eadbeef, 24)]
            [InlineData((uint)0x00010001,  2)]
            [InlineData((uint)0x7c9c9c9c, 17)]
            [InlineData((uint)0x7aaaaaaa, 17)]
            [InlineData((uint)0x55555555, 16)]
            [InlineData((uint)0x0f0f0f0f, 16)]
            [InlineData((uint)0x7fffffff, 31)]
            [InlineData((uint)0x80000001,  2)]
            [InlineData((uint)0xF0F0F0F1, 17)]
            [InlineData((uint)0xAAAAAAAB, 17)]
            [InlineData((uint)0x85555556, 15)]
            [InlineData((uint)0x83636364, 14)]
            [InlineData((uint)0xFFFEFFFF, 31)]
            [InlineData((uint)0x81524111,  9)]
            [InlineData((uint)0xFFFFFFF8, 29)]
            [InlineData((uint)0xFFFFFFF9, 30)]
            [InlineData((uint)0xFFFFFFFA, 30)]
            [InlineData((uint)0xFFFFFFFB, 31)]
            [InlineData((uint)0xFFFFFFFC, 30)]
            [InlineData((uint)0xFFFFFFFD, 31)]
            [InlineData((uint)0xFFFFFFFE, 31)]
            [InlineData((uint)0xFFFFFFFF, 32)]
            public void UInt32_Overload(uint value, int expected)
            {
                // Act
                var actual = BinaryMath.CountSetBits(value);

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory]
            [InlineData((short)-0x7fff,  2)]
            [InlineData((short)-0x0f0f,  9)]
            [InlineData((short)-0x5555,  9)]
            [InlineData((short)-0x7aaa,  7)]
            [InlineData((short)-0x7c9c,  6)]
            [InlineData((short)-0x0101, 15)]
            [InlineData((short)-0x7ead,  6)]
            [InlineData((short)-8,      13)]
            [InlineData((short)-7,      14)]
            [InlineData((short)-6,      14)]
            [InlineData((short)-5,      15)]
            [InlineData((short)-4,      14)]
            [InlineData((short)-3,      15)]
            [InlineData((short)-2,      15)]
            [InlineData((short)-1,      16)]
            [InlineData((short)0,        0)]
            [InlineData((short)1,        1)]
            [InlineData((short)2,        1)]
            [InlineData((short)3,        2)]
            [InlineData((short)4,        1)]
            [InlineData((short)5,        2)]
            [InlineData((short)6,        2)]
            [InlineData((short)7,        3)]
            [InlineData((short)8,        1)]
            [InlineData((short)0x7ead,  11)]
            [InlineData((short)0x0101,   2)]
            [InlineData((short)0x7c9c,   9)]
            [InlineData((short)0x7aaa,   9)]
            [InlineData((short)0x5555,   8)]
            [InlineData((short)0x0f0f,   8)]
            [InlineData((short)0x7fff,  15)]
            public void Int16_Overload(short value, int expected)
            {
                // Act
                var actual = BinaryMath.CountSetBits(value);

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory]
            [InlineData((ushort)0,        0)]
            [InlineData((ushort)1,        1)]
            [InlineData((ushort)2,        1)]
            [InlineData((ushort)3,        2)]
            [InlineData((ushort)4,        1)]
            [InlineData((ushort)5,        2)]
            [InlineData((ushort)6,        2)]
            [InlineData((ushort)7,        3)]
            [InlineData((ushort)8,        1)]
            [InlineData((ushort)0x7ead,  11)]
            [InlineData((ushort)0x0101,   2)]
            [InlineData((ushort)0x7c9c,   9)]
            [InlineData((ushort)0x7aaa,   9)]
            [InlineData((ushort)0x5555,   8)]
            [InlineData((ushort)0x0f0f,   8)]
            [InlineData((ushort)0x7fff,  15)]
            [InlineData((ushort)0x8001,   2)]
            [InlineData((ushort)0xF0F1,   9)]
            [InlineData((ushort)0xAAAB,   9)]
            [InlineData((ushort)0x8556,   7)]
            [InlineData((ushort)0x8364,   6)]
            [InlineData((ushort)0xFEFE,  14)]
            [InlineData((ushort)0x8152,   5)]
            [InlineData((ushort)0xFFF8,  13)]
            [InlineData((ushort)0xFFF9,  14)]
            [InlineData((ushort)0xFFFA,  14)]
            [InlineData((ushort)0xFFFB,  15)]
            [InlineData((ushort)0xFFFC,  14)]
            [InlineData((ushort)0xFFFD,  15)]
            [InlineData((ushort)0xFFFE,  15)]
            [InlineData((ushort)0xFFFF,  16)]
            public void UInt16_Overload(ushort value, int expected)
            {
                // Act
                var actual = BinaryMath.CountSetBits(value);

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory]
            [InlineData((sbyte)-0x7f,  2)]
            [InlineData((sbyte)-0x0f,  5)]
            [InlineData((sbyte)-0x55,  5)]
            [InlineData((sbyte)-0x7a,  3)]
            [InlineData((sbyte)-0x7c,  2)]
            [InlineData((sbyte)-0x7e,  2)]
            [InlineData((sbyte)-8,     5)]
            [InlineData((sbyte)-7,     6)]
            [InlineData((sbyte)-6,     6)]
            [InlineData((sbyte)-5,     7)]
            [InlineData((sbyte)-4,     6)]
            [InlineData((sbyte)-3,     7)]
            [InlineData((sbyte)-2,     7)]
            [InlineData((sbyte)-1,     8)]
            [InlineData((sbyte)0,      0)]
            [InlineData((sbyte)1,      1)]
            [InlineData((sbyte)2,      1)]
            [InlineData((sbyte)3,      2)]
            [InlineData((sbyte)4,      1)]
            [InlineData((sbyte)5,      2)]
            [InlineData((sbyte)6,      2)]
            [InlineData((sbyte)7,      3)]
            [InlineData((sbyte)8,      1)]
            [InlineData((sbyte)0x7e,   6)]
            [InlineData((sbyte)0x7c,   5)]
            [InlineData((sbyte)0x7a,   5)]
            [InlineData((sbyte)0x55,   4)]
            [InlineData((sbyte)0x0f,   4)]
            [InlineData((sbyte)0x7f,   7)]
            public void SByte_Overload(sbyte value, int expected)
            {
                // Act
                var actual = BinaryMath.CountSetBits(value);

                // Assert
                Assert.Equal(expected, actual);
            }

            [Theory]
            [InlineData((byte)0,       0)]
            [InlineData((byte)1,       1)]
            [InlineData((byte)2,       1)]
            [InlineData((byte)3,       2)]
            [InlineData((byte)4,       1)]
            [InlineData((byte)5,       2)]
            [InlineData((byte)6,       2)]
            [InlineData((byte)7,       3)]
            [InlineData((byte)8,       1)]
            [InlineData((byte)0x7e,    6)]
            [InlineData((byte)0x7c,    5)]
            [InlineData((byte)0x7a,    5)]
            [InlineData((byte)0x55,    4)]
            [InlineData((byte)0x0f,    4)]
            [InlineData((byte)0x7f,    7)]
            [InlineData((byte)0x81,    2)]
            [InlineData((byte)0xF1,    5)]
            [InlineData((byte)0xAB,    5)]
            [InlineData((byte)0x86,    3)]
            [InlineData((byte)0x84,    2)]
            [InlineData((byte)0x82,    2)]
            [InlineData((byte)0xF8,    5)]
            [InlineData((byte)0xF9,    6)]
            [InlineData((byte)0xFA,    6)]
            [InlineData((byte)0xFB,    7)]
            [InlineData((byte)0xFC,    6)]
            [InlineData((byte)0xFD,    7)]
            [InlineData((byte)0xFE,    7)]
            [InlineData((byte)0xFF,    8)]
            public void Byte_Overload(byte value, int expected)
            {
                // Act
                var actual = BinaryMath.CountSetBits(value);

                // Assert
                Assert.Equal(expected, actual);
            }
        }

	}
}
