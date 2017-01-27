using System;
using NUnit.Framework;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.IsDecimalType"/> function.
        /// </summary>
        [TestFixture]
        public sealed class IsDecimalTypeTests
        {
            [Test]
            public void IfTypeArgumentIsNull_ShouldThrowException()
            {
                // Act/Assert
                Assert.That(() => {
                    Numeric.IsDecimalType(null);
                }, Throws.ArgumentNullException);
            }

            [TestCase(typeof(String))]
            [TestCase(typeof(Object))]
            [TestCase(typeof(DateTime))]
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
            public void IfTypeArgumentIsNotDecimal_ShouldReturnFalse(Type type)
            {
                // Act
                bool result = Numeric.IsDecimalType(type);

                // Assert
                Assert.That(result, Is.False);
            }

            [TestCase(typeof(Decimal))]
            public void IfTypeArgumentIsDecimal_ShouldReturnTrue(Type type)
            {
                // Act
                bool result = Numeric.IsDecimalType(type);

                // Assert
                Assert.That(result, Is.True);
            }
        }
    }
}
