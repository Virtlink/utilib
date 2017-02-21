using Xunit;

namespace Virtlink.Utilib
{
    partial class StringExtTests
    {
        /// <summary>
        /// Tests the <see cref="StringExt.CountNewlines"/> function.
        /// </summary>
        public sealed class CountNewlinesTests
        {
            [Theory]
            [InlineData("",                  0)]
            [InlineData("abc",               0)]
            [InlineData("\n",                1)]
            [InlineData("abc\n",             1)]
            [InlineData("\ndef",             1)]
            [InlineData("abc\ndef",          1)]
            [InlineData("\r",                1)]
            [InlineData("abc\r",             1)]
            [InlineData("\rdef",             1)]
            [InlineData("abc\rdef",          1)]
            [InlineData("\r\n",              1)]
            [InlineData("abc\r\n",           1)]
            [InlineData("\r\ndef",           1)]
            [InlineData("abc\r\ndef",        1)]
            [InlineData("abc\rdef\rghi",     2)]
            [InlineData("abc\ndef\nghi",     2)]
            [InlineData("abc\r\ndef\r\nghi", 2)]
            [InlineData("abc\r\rghi",        2)]
            [InlineData("abc\n\nghi",        2)]
            [InlineData("abc\n\rghi",        2)]
            public void ShouldReturnExpectedResult(string str, int expected)
            {
                // Act
                int actual = StringExt.CountNewlines(str);

                // Assert
                Assert.Equal(expected, actual);
            }
        }
    }
}
