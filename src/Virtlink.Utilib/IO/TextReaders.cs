using System;
using System.IO;
using System.Text;

namespace Virtlink.Utilib.IO
{
    /// <summary>
    /// Extension functions for working with <see cref="TextReader"/> objects.
    /// </summary>
    public static class TextReaders
    {
        /// <summary>
        /// Reads a string of the specified length.
        /// </summary>
        /// <param name="reader">The text reader.</param>
        /// <param name="length">The length, in characters.</param>
        /// <returns>The read string.</returns>
        public static string ReadString(this TextReader reader, int length)
        {
            #region Contract
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));
            #endregion

            if (length == 0)
                return String.Empty;

            char[] buffer = new char[4096];
            var sb = new StringBuilder(length);

            while (sb.Length < length)
            {
                int read = reader.Read(buffer, 0, Math.Min(buffer.Length, length - sb.Length));
                if (read == 0)
                {
                    // End of file.
                    break;
                }
                sb.Append(buffer, 0, read);
            }

            return sb.ToString();
        }
    }
}
