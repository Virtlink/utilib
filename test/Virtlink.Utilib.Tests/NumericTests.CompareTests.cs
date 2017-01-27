using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.Compare"/> function.
        /// </summary>
        public sealed class CompareTests
        {
            [Test]
            public void IfFirstArgumentIsNull_ShouldThrowException()
            {
                // Act/Assert
                Assert.That(() =>
                {
                    Numeric.Compare(null, 10);
                }, Throws.ArgumentNullException);
            }

            [Test]
            public void IfSecondArgumentIsNull_ShouldThrowException()
            {
                // Act/Assert
                Assert.That(() =>
                {
                    Numeric.Compare(10, null);
                }, Throws.ArgumentNullException);
            }

            [Test]
            public void IfFirstArgumentIsNotNumeric_ShouldThrowException()
            {
                // Act/Assert
                Assert.That(() =>
                {
                    Numeric.Compare("abc", 10);
                }, Throws.ArgumentException);
            }

            [Test]
            public void IfSecondArgumentIsNotNumeric_ShouldThrowException()
            {
                // Act/Assert
                Assert.That(() =>
                {
                    Numeric.Compare(10, "abc");
                }, Throws.ArgumentException);
            }

            private static object[] LessThanTestCases =
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
            [Test, TestCaseSource(nameof(LessThanTestCases))]
            public void IfFirstArgumentIsLessThanSecondArgument_ShouldReturnNegativeValue(object x, object y)
            {
                // Act
                int result = Numeric.Compare(x, y);

                // Assert
                Assert.That(result, Is.Negative);
            }

            private static object[] GreaterThanTestCases =
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
            [Test, TestCaseSource(nameof(GreaterThanTestCases))]
            public void IfFirstArgumentIsGreaterThanSecondArgument_ShouldReturnPositiveValue(object x, object y)
            {
                // Act
                int result = Numeric.Compare(x, y);

                // Assert
                Assert.That(result, Is.Positive);
            }

            private static object[] EqualToTestCases =
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
            [Test, TestCaseSource(nameof(EqualToTestCases))]
            public void IfFirstArgumentIsEqualToSecondArgument_ShouldReturnZero(object x, object y)
            {
                // Act
                int result = Numeric.Compare(x, y);

                // Assert
                Assert.That(result, Is.Zero);
            }
        }
    }
}
