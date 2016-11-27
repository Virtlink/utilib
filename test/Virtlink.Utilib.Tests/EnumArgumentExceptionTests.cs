using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib
{
    /// <summary>
    /// Tests the <see cref="EnumArgumentException"/> class.
    /// </summary>
    [TestFixture]
    public class InvalidEnumArgumentExceptionTests
    {
        [Test]
        public void DefaultMessage()
        {
            // Act
            var exception = new EnumArgumentException();

            // Assert
            Assert.That(exception.Message, Is.EqualTo("The value of argument is invalid for Enum type."));
        }

        [Test]
        public void MessageGivenParameterNameValueAndType()
        {
            // Arrange
            string paramName = "myParam";
            int invalidValue = 42;
            Type enumType = typeof(FileAccess);

            // Act
            var exception = new EnumArgumentException(paramName, invalidValue, enumType);

            // Assert
            string expected = "The value of argument 'myParam' (42) is invalid for Enum type 'FileAccess'.";
            Assert.That(exception.Message.Substring(0, expected.Length), Is.EqualTo(expected));
        }
    }
}
