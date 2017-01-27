using System;
using NUnit.Framework;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.IsFloatingPointType"/> function.
        /// </summary>
        [TestFixture]
        public sealed class IsFloatingPointTypeTests
        {
            [Test]
            public void IfTypeArgumentIsNull_ShouldThrowException()
            {
                // Act/Assert
                Assert.That(() => {
                    Numeric.IsFloatingPointType(null);
                }, Throws.ArgumentNullException);
            }

            [TestCase(typeof(String))]
            [TestCase(typeof(Object))]
            [TestCase(typeof(DateTime))]
            [TestCase(typeof(Decimal))]
            [TestCase(typeof(SByte))]
            [TestCase(typeof(Byte))]
            [TestCase(typeof(Int16))]
            [TestCase(typeof(UInt16))]
            [TestCase(typeof(Int32))]
            [TestCase(typeof(UInt32))]
            [TestCase(typeof(Int64))]
            [TestCase(typeof(UInt64))]
            public void IfTypeArgumentIsNotFloatingPoint_ShouldReturnFalse(Type type)
            {
                // Act
                bool result = Numeric.IsFloatingPointType(type);

                // Assert
                Assert.That(result, Is.False);
            }

            [TestCase(typeof(Single))]
            [TestCase(typeof(Double))]
            public void IfTypeArgumentIsFloatingPoint_ShouldReturnTrue(Type type)
            {
                // Act
                bool result = Numeric.IsFloatingPointType(type);

                // Assert
                Assert.That(result, Is.True);
            }
        }
    }
}
