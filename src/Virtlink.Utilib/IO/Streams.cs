using System;
using System.IO;
using System.Text;

namespace Virtlink.Utilib.IO
{
    /// <summary>
    /// Functions for working with streams and readers/writers.
    /// </summary>
    public static class Streams
    {
        /// <summary>
        /// The default buffer size.
        /// </summary>
        private const int DefaultBufferSize = 1024;

        /// <summary>
        /// The default encoding: UTF8 without BOM.
        /// </summary>
        private static Encoding DefaultEncoding { get; } = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

        /// <summary>
        /// Opens a binary reader for the stream.
        /// </summary>
        /// <param name="input">The stream.</param>
        /// <returns>The binary reader.</returns>
        /// <remarks>
        /// Closing the binary reader doesn't close the underlying stream.
        /// </remarks>
        public static BinaryReader ReadBinary(this Stream input)
        {
            #region Contract
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            #endregion

            return new BinaryReader(input, Streams.DefaultEncoding, true);
        }

        /// <summary>
        /// Opens a text reader for the stream.
        /// </summary>
        /// <param name="input">The stream.</param>
        /// <returns>The text reader.</returns>
        /// <remarks>
        /// Closing the text reader doesn't close the underlying stream.
        /// </remarks>
        public static TextReader ReadText(this Stream input)
        {
            #region Contract
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            #endregion

            return new StreamReader(input, Streams.DefaultEncoding, false, Streams.DefaultBufferSize, true);
        }

        /// <summary>
        /// Opens a binary writer for the stream.
        /// </summary>
        /// <param name="output">The stream.</param>
        /// <returns>The binary writer.</returns>
        /// <remarks>
        /// Closing the binary writer doesn't close the underlying stream.
        /// </remarks>
        public static BinaryWriter WriteBinary(this Stream output)
        {
            #region Contract
            if (output == null)
                throw new ArgumentNullException(nameof(output));
            #endregion

            return new BinaryWriter(output, Streams.DefaultEncoding, true);
        }

        /// <summary>
        /// Opens a text writer for the stream.
        /// </summary>
        /// <param name="output">The stream.</param>
        /// <returns>The text writer.</returns>
        /// <remarks>
        /// Closing the text writer doesn't close the underlying stream.
        /// </remarks>
        public static TextWriter WriteText(this Stream output)
        {
            #region Contract
            if (output == null)
                throw new ArgumentNullException(nameof(output));
            #endregion

            return new StreamWriter(output, Streams.DefaultEncoding, Streams.DefaultBufferSize, true);
        }

        /// <summary>
        /// Resets the position of the stream and returns the stream.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <returns>The same stream.</returns>
        public static Stream ResetPosition(this Stream stream)
        {
            #region Contract
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            #endregion

            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Wraps the specified stream in a non-closing wrapper.
        /// </summary>
        /// <param name="stream">The stream to wrap.</param>
        /// <returns>The wrapped stream.</returns>
        public static Stream AsNonClosingStream(this Stream stream)
        {
            #region Contract
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            #endregion

            if (stream is NonClosingStreamWrapper)
                return stream;
            else
                return new NonClosingStreamWrapper(stream);
        }
    }
}