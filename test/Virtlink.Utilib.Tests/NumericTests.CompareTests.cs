using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.Compare"/> function.
        /// </summary>
        public sealed class CompareTests
        {
            [Fact]
            public void ShouldThrowArgumentNullException_WhenFirstArgumentIsNull()
            {
                // Act
                var exception = Record.Exception(() =>
                {
                    Numeric.Compare(null, 10);
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }

            [Fact]
            public void ShouldThrowArgumentNullException_WhenSecondArgumentIsNull()
            {
                // Act
                var exception = Record.Exception(() =>
                {
                    Numeric.Compare(10, null);
                });

                // Assert
                Assert.IsType<ArgumentNullException>(exception);
            }

            [Fact]
            public void ShouldThrowArgumentException_WhenFirstArgumentIsNotNumeric()
            {
                // Act
                var exception = Record.Exception(() =>
                {
                    Numeric.Compare("abc", 10);
                });

                // Assert
                Assert.IsType<ArgumentException>(exception);
            }

            [Fact]
            public void ShouldThrowArgumentException_WhenSecondArgumentIsNotNumeric()
            {
                // Act
                var exception = Record.Exception(() =>
                {
                    Numeric.Compare(10, "abc");
                });

                // Assert
                Assert.IsType<ArgumentException>(exception);
            }

            public static IEnumerable<object[]> LessThanTestCases { get; } = new[]
            {
                new object[] { (long)    -13000, (short)   -12345 },
                new object[] { (ulong)    12000, (ushort)   12345 },
                new object[] { (int)        -15, (sbyte)      -12 },
                new object[] { (uint)        10, (byte)        12 },
                new object[] { (short)     -123, (float)    123.4 },
                new object[] { (ushort)    1230, (double)  1234.5 },
                new object[] { (sbyte)      -15, (decimal)  -12.6 },
                new object[] { (byte)        12, (long)     12345 },
                new object[] { (float)    123.4, (ulong)    12345 },
                new object[] { (double) -1234.5, (int)      -1230 },
                new object[] { (decimal)12345.6, (uint)     12350 },
            };
            [Theory]
            [MemberData(nameof(LessThanTestCases))]
            public void IfFirstArgumentIsLessThanSecondArgument_ShouldReturnNegativeValue(object x, object y)
            {
                // Act
                int result = Numeric.Compare(x, y);

                // Assert
                Assert.True(result < 0);
            }

            public static IEnumerable<object[]> GreaterThanTestCases { get; } = new[]
            {
                new object[] { (long)     12345, (short)     -123 },
                new object[] { (ulong)    12345, (ushort)    1230 },
                new object[] { (int)       1230, (sbyte)      -15 },
                new object[] { (uint)     12350, (byte)        12 },
                new object[] { (short)      130, (float)    123.4 },
                new object[] { (ushort)   12345, (double) -1234.5 },
                new object[] { (sbyte)       12, (decimal)   11.6 },
                new object[] { (byte)        12, (long)    -13000 },
                new object[] { (float)  12345.6, (ulong)    12000 },
                new object[] { (double)  1234.5, (int)        -15 },
                new object[] { (decimal)   12.6, (uint)        10 },
            };
            [Theory]
            [MemberData(nameof(GreaterThanTestCases))]
            public void IfFirstArgumentIsGreaterThanSecondArgument_ShouldReturnPositiveValue(object x, object y)
            {
                // Act
                int result = Numeric.Compare(x, y);

                // Assert
                Assert.True(result > 0);
            }

            public static IEnumerable<object[]> EqualToTestCases { get; } = new[]
            {
                new object[] { (long)      -123, (short)     -123 },
                new object[] { (ulong)     1230, (ushort)    1230 },
                new object[] { (int)        -15, (sbyte)      -15 },
                new object[] { (uint)        12, (byte)        12 },
                new object[] { (short)     -123, (float)   -123.0 },
                new object[] { (ushort)    1234, (double)  1234.0 },
                new object[] { (sbyte)      -12, (decimal)  -12.0 },
                new object[] { (byte)        12, (long)        12 },
                new object[] { (float)    123.0, (ulong)      123 },
                new object[] { (double)  1234.0, (int)       1234 },
                new object[] { (decimal)   12.0, (uint)        12 },
            };
            [Theory]
            [MemberData(nameof(EqualToTestCases))]
            public void IfFirstArgumentIsEqualToSecondArgument_ShouldReturnZero(object x, object y)
            {
                // Act
                int result = Numeric.Compare(x, y);

                // Assert
                Assert.True(result == 0);
            }
        }
    }
}
