using Xunit;

namespace Virtlink.Utilib
{
    partial class CharsTests
    {
        /// <summary>
        /// Tests the <see cref="Chars.IsHexDigit"/> function.
        /// </summary>
        public sealed class IsHexDigitTests
        {
            [Theory]
            [InlineData('0')]
            [InlineData('1')]
            [InlineData('2')]
            [InlineData('3')]
            [InlineData('4')]
            [InlineData('5')]
            [InlineData('6')]
            [InlineData('7')]
            [InlineData('8')]
            [InlineData('9')]
            [InlineData('a')]
            [InlineData('b')]
            [InlineData('c')]
            [InlineData('d')]
            [InlineData('e')]
            [InlineData('f')]
            [InlineData('A')]
            [InlineData('B')]
            [InlineData('C')]
            [InlineData('D')]
            [InlineData('E')]
            [InlineData('F')]
            public void ShouldReturnTrueForHexadecimalCharacters(char c)
            {
                // Act
                bool result = Chars.IsHexDigit(c);

                // Assert
                Assert.True(result);
            }

            [Theory]
            [InlineData(')')]
            [InlineData('!')]
            [InlineData('@')]
            [InlineData('#')]
            [InlineData('$')]
            [InlineData('%')]
            [InlineData('^')]
            [InlineData('&')]
            [InlineData('*')]
            [InlineData('(')]
            [InlineData('g')]
            [InlineData('h')]
            [InlineData('i')]
            [InlineData('j')]
            [InlineData('k')]
            [InlineData('l')]
            [InlineData('G')]
            [InlineData('H')]
            [InlineData('I')]
            [InlineData('J')]
            [InlineData('K')]
            [InlineData('L')]
            public void ShouldReturnFalseForNonHexadecimalCharacters(char c)
            {
                // Act
                bool result = Chars.IsHexDigit(c);

                // Assert
                Assert.False(result);
            }
        }
    }
}
