using System;
using NUnit.Framework;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.HasFloatingPointType"/> function.
        /// </summary>
        [TestFixture]
        public sealed class HasFloatingPointTypeTests
        {
            [Test]
            public void IfArgumentIsNull_ShouldReturnFalse()
            {
                // Act
                bool result = Numeric.HasFloatingPointType(null);

                // Assert
                Assert.That(result, Is.False);
            }

            private static object[] NegativeTestCases =
            {
                String.Empty,
                new object(),
                new DateTime(2017, 1, 27, 11, 32, 20),
                SByte.MinValue,
                Byte.MaxValue,
                Int16.MinValue,
                UInt16.MaxValue,
                Int32.MinValue,
                UInt32.MaxValue,
                Int64.MinValue,
                UInt64.MaxValue,
                Decimal.MaxValue,
            };
            [Test, TestCaseSource(nameof(NegativeTestCases))]
            public void IfArgumentIsNotFloatingPoint_ShouldReturnFalse(object obj)
            {
                // Act
                bool result = Numeric.HasFloatingPointType(obj);

                // Assert
                Assert.That(result, Is.False);
            }

            private static object[] PositiveTestCases =
            {
                Single.MaxValue,
                Double.MaxValue,
            };
            [Test, TestCaseSource(nameof(PositiveTestCases))]
            public void IfArgumentIsFloatingPoint_ShouldReturnTrue(object obj)
            {
                // Act
                bool result = Numeric.HasFloatingPointType(obj);

                // Assert
                Assert.That(result, Is.True);
            }
        }
    }
}
