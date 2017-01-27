using System;
using NUnit.Framework;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.HasIntegerType"/> function.
        /// </summary>
        [TestFixture]
        public sealed class HasIntegerTypeTests
        {
            [Test]
            public void IfArgumentIsNull_ShouldReturnFalse()
            {
                // Act
                bool result = Numeric.HasIntegerType(null);

                // Assert
                Assert.That(result, Is.False);
            }

            private static object[] NegativeTestCases =
            {
                String.Empty,
                new object(),
                new DateTime(2017, 1, 27, 11, 32, 20),
                Single.MaxValue,
                Double.MaxValue,
                Decimal.MaxValue,
            };
            [Test, TestCaseSource(nameof(NegativeTestCases))]
            public void IfArgumentIsNotInteger_ShouldReturnFalse(object obj)
            {
                // Act
                bool result = Numeric.HasIntegerType(obj);

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
            };
            [Test, TestCaseSource(nameof(PositiveTestCases))]
            public void IfArgumentIsInteger_ShouldReturnTrue(object obj)
            {
                // Act
                bool result = Numeric.HasIntegerType(obj);

                // Assert
                Assert.That(result, Is.True);
            }
        }
    }
}
