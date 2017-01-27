using System;
using NUnit.Framework;

namespace Virtlink.Utilib
{
    partial class NumericTests
    {
        /// <summary>
        /// Tests the <see cref="Numeric.IsIntegerType"/> function.
        /// </summary>
        [TestFixture]
        public sealed class IsIntegerTypeTests
        {
            [Test]
            public void IfTypeArgumentIsNull_ShouldThrowException()
            {
                // Act/Assert
                Assert.That(() => {
                    Numeric.IsIntegerType(null);
                }, Throws.ArgumentNullException);
            }

            [TestCase(typeof(String))]
            [TestCase(typeof(Object))]
            [TestCase(typeof(DateTime))]
            [TestCase(typeof(Single))]
            [TestCase(typeof(Double))]
            [TestCase(typeof(Decimal))]
            public void IfTypeArgumentIsNotInteger_ShouldReturnFalse(Type type)
            {
                // Act
                bool result = Numeric.IsIntegerType(type);

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
            public void IfTypeArgumentIsInteger_ShouldReturnTrue(Type type)
            {
                // Act
                bool result = Numeric.IsIntegerType(type);

                // Assert
                Assert.That(result, Is.True);
            }
        }
    }
}
