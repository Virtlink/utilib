using System;
using NUnit.Framework;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.IsNumericType"/> function.
        /// </summary>
        [TestFixture]
        public sealed class IsNumericTypeTests
        {
            [Test]
            public void IfTypeArgumentIsNull_ShouldThrowException()
            {
                // Act/Assert
                Assert.That(() => {
                    Numeric.IsNumericType(null);
                }, Throws.ArgumentNullException);
            }

            [TestCase(typeof(String))]
            [TestCase(typeof(Object))]
            [TestCase(typeof(DateTime))]
            public void IfTypeArgumentIsNotNumeric_ShouldReturnFalse(Type type)
            {
                // Act
                bool result = Numeric.IsNumericType(type);

                // Assert
                Assert.That(result, Is.False);
            }

            [TestCase(typeof(SByte))]
            [TestCase(typeof(Byte))]
            [TestCase(typeof(Int16))]
            [TestCase(typeof(UInt16))]
            [TestCase(typeof(Int32))]
            [TestCase(typeof(UInt32))]
            [TestCase(typeof(Int64))]
            [TestCase(typeof(UInt64))]
            [TestCase(typeof(Single))]
            [TestCase(typeof(Double))]
            [TestCase(typeof(Decimal))]
            public void IfTypeArgumentIsNumeric_ShouldReturnTrue(Type type)
            {
                // Act
                bool result = Numeric.IsNumericType(type);

                // Assert
                Assert.That(result, Is.True);
            }
        }
    }
}
