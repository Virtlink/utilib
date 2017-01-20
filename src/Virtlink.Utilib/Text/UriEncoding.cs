namespace Virtlink.Utilib.Text
{
    /// <summary>
    /// URI encoding.
    /// </summary>
    public class UriEncoding : PathEncoding
    {
        /// <summary>
        /// Determines whether the specified character is allowed unencoded.
        /// </summary>
        /// <param name="c">The character to test.</param>
        /// <returns><see langword="true"/> when the character is allowed unencoded;
        /// otherwise, <see langword="false"/>.</returns>
        protected override bool IsAllowedCharacter(char c)
        {
            return base.IsAllowedCharacter(c)
                   && c < 128;
        }
    }
}