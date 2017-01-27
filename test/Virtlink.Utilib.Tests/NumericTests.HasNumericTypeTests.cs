using System;
using NUnit.Framework;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.HasNumericType"/> function.
        /// </summary>
        [TestFixture]
        public sealed class HasNumericTypeTests
        {
            [Test]
            public void IfArgumentIsNull_ShouldReturnFalse()
            {
                // Act
                bool result = Numeric.HasNumericType(null);

                // Assert
                Assert.That(result, Is.False);
            }

            private static object[] NegativeTestCases =
            {
                String.Empty,
                new object(),
                new DateTime(2017, 1, 27, 11, 32, 20),
            };
            [Test, TestCaseSource(nameof(NegativeTestCases))]
            public void IfArgumentIsNotNumeric_ShouldReturnFalse(object obj)
            {
                // Act
                bool result = Numeric.HasNumericType(obj);

                // Assert
                Assert.That(result, Is.False);
            }

            private static object[] PositiveTestCases =
            {
                SByte.MinValue,
                Byte.MaxValue,
                Int16.MinValue,
                UInt16.MaxValue,
                Int32.MinValue,
                UInt32.MaxValue,
                Int64.MinValue,
                UInt64.MaxValue,
                Single.MaxValue,
                Double.MaxValue,
                Decimal.MaxValue,
            };
            [Test, TestCaseSource(nameof(PositiveTestCases))]
            public void IfArgumentIsNumeric_ShouldReturnTrue(object obj)
            {
                // Act
                bool result = Numeric.HasNumericType(obj);

                // Assert
                Assert.That(result, Is.True);
            }
        }
    }
}
