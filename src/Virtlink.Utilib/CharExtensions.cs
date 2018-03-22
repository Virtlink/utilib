namespace Virtlink.Utilib
{
    /// <summary>
    /// Functions for working with characters.
    /// </summary>
    public static class Chars
    {
        /// <summary>
        /// Determines whether the character is a hexadecimal digit.
        /// </summary>
        /// <param name="c">The character to test.</param>
        /// <returns><see langword="true"/> when the character is a hexadecimal character;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool IsHexDigit(char c)
        {
            return (c >= '0' && c <= '9')
                || (c >= 'A' && c <= 'F')
                || (c >= 'a' && c <= 'f');
        }
    }
}
