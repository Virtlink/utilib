using System;
using System.IO;
using Xunit;

namespace Virtlink.Utilib
{
    /// <summary>
    /// Tests the <see cref="EnumArgumentException"/> class.
    /// </summary>
    public class EnumArgumentExceptionTests
    {
        [Fact]
        public void DefaultMessage()
        {
            // Act
            var exception = new EnumArgumentException();

            // Assert
            Assert.Equal("The value of argument is invalid for Enum type.", exception.Message);
        }

        [Fact]
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
            Assert.Equal(expected, exception.Message.Substring(0, expected.Length));
        }
    }
}
