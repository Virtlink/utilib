namespace Virtlink.Utilib.Text
{
    /// <summary>
    /// A string encoding.
    /// </summary>
    public interface IStringEncoding
    {
        /// <summary>
        /// Encodes the specified string.
        /// </summary>
        /// <param name="unencoded">The unencoded string.</param>
        /// <returns>The encoded string.</returns>
        string Encode(string unencoded);

        /// <summary>
        /// Decodes the specified string.
        /// </summary>
        /// <param name="encoded">The encoded string.</param>
        /// <returns>The unencoded string.</returns>
        string Decode(string encoded);
    }
}