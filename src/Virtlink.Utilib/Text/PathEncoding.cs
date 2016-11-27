using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtlink.Utilib.Text
{
    /// <summary>
	/// Path encoding.
	/// </summary>
	public class PathEncoding : IStringEncoding
    {
        private static Encoding DefaultEncoding => Encoding.UTF8;

        /// <inheritdoc />
        public string Encode(string unencoded)
        {
            #region Contract
            if (unencoded == null) throw new ArgumentNullException(nameof(unencoded));
            #endregion

            byte[] buffer = new byte[4];

            var sb = new StringBuilder(unencoded.Length * 2);

            // Encode as many characters as we can.
            int i = 0;
            while (i < unencoded.Length)
            {
                if (!IsAllowedCharacter(unencoded[i]))
                {
                    int step = EncodeChar(unencoded, i, sb, buffer);
                    i += step;
                }
                else
                {
                    sb.Append(unencoded[i]);
                    i += 1;
                }
            }

            string encoded = sb.ToString();

            // Avoid creating an illegal name.
            if (!IsAllowedName(encoded))
            {
                // Encode the first character.
                sb.Clear();
                int step = EncodeChar(encoded, 0, sb, buffer);
                sb.Append(encoded.Substring(step));
                encoded = sb.ToString();
            }

            return encoded;
        }

        /// <summary>
        /// Encodes a character.
        /// </summary>
        /// <param name="unencoded">The unencoded string.</param>
        /// <param name="index">The zero-based index in the unencoded string.</param>
        /// <param name="output">The output string builder.</param>
        /// <param name="buffer">The byte buffer used.</param>
        /// <returns>The number of characters encoded.</returns>
        private int EncodeChar(string unencoded, int index, StringBuilder output, byte[] buffer)
        {
            int chars = Char.IsSurrogatePair(unencoded, index) ? 2 : 1;
            int bytes = DefaultEncoding.GetBytes(unencoded, index, chars, buffer, 0);
            for (int j = 0; j < bytes; j++)
            {
                output.Append('%');
                output.Append(buffer[j].ToString("X2"));
            }
            return chars;
        }

        /// <inheritdoc />
        public string Decode(string encoded)
        {
            #region Contract
            if (encoded == null) throw new ArgumentNullException(nameof(encoded));
            #endregion

            var buffer = new List<byte>(4);

            var sb = new StringBuilder(encoded.Length);

            // Decode characters.
            int i = 0;
            while (i < encoded.Length)
            {
                if (encoded[i] == '%')
                {
                    int step = DecodeChars(encoded, i, sb, buffer);
                    i += step;
                }
                else
                {
                    sb.Append(encoded[i]);
                    i += 1;
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Decodes as many characters as possible.
        /// </summary>
        /// <param name="encoded">The encoded string.</param>
        /// <param name="index">The zero-based index in the encoded string.</param>
        /// <param name="output">The output string builder.</param>
        /// <param name="buffer">The byte buffer.</param>
        /// <returns>The number of characters decoded.</returns>
        private int DecodeChars(string encoded, int index, StringBuilder output, IList<byte> buffer)
        {
            int read = 0;

            // Read as many encoded characters as we can.
            buffer.Clear();
            bool success;
            do
            {
                success = TryReadEncodedByte(encoded, index + read, buffer);
                read += 3;
            } while (success);

            read -= 3;

            if (buffer.Count > 0)
            {
                // Decode them all at once.
                byte[] byteBuffer = buffer.ToArray();
                string decoded = PathEncoding.DefaultEncoding.GetString(byteBuffer, 0, byteBuffer.Length);

                output.Append(decoded);
            }

            return read;
        }

        /// <summary>
        /// Tries to read an encoded byte.
        /// </summary>
        /// <param name="encoded">The encoded string.</param>
        /// <param name="index">The zero-based index in the encoded string.</param>
        /// <param name="buffer">The buffer to which to add the read string.</param>
        /// <returns><see langword="true"/> when a byte was read;
        /// otherwise, <see langword="false"/>.</returns>
        private bool TryReadEncodedByte(string encoded, int index, IList<byte> buffer)
        {
            if (index >= encoded.Length || encoded[index] != '%')
                return false;

            if (index + 3 > encoded.Length)
                throw new FormatException("Percent encoded UTF-8 character ended prematurely.");

            int result;
            if (!Int32.TryParse(encoded.Substring(index + 1, 2), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out result))
                throw new FormatException("Percent encoded UTF-8 character was not encoded properly.");

            buffer.Add((byte)result);

            return true;
        }

        /// <summary>
        /// Determines whether the specified character is allowed unencoded.
        /// </summary>
        /// <param name="c">The character to test.</param>
        /// <returns><see langword="true"/> when the character is allowed unencoded;
        /// otherwise, <see langword="false"/>.</returns>
        protected virtual bool IsAllowedCharacter(char c)
        {
            return !Char.IsControl(c)
                   && c != '%'
                   && c != '/'
                   && c != '!';
        }

        /// <summary>
        /// Determines whether the specified name is allowed unencoded.
        /// </summary>
        /// <param name="name">The name to test.</param>
        /// <returns><see langword="true"/> when the name is allowed unencoded;
        /// otherwise, <see langword="false"/>.</returns>
        /// <remarks>
        /// This method doesn't have to take into account whether the name contains
        /// non-allowed characters.
        /// </remarks>
        protected virtual bool IsAllowedName(string name)
        {
            return name != "."
                && name != "..";
        }
    }
}
