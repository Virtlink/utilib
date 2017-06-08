using System.Text;

namespace Virtlink.Utilib.IO
{
    /// <summary>
    /// A data buffer.
    /// </summary>
    public interface IBuffer
    {
        /// <summary>
        /// Gets the raw buffer array.
        /// </summary>
        /// <value>The raw array.</value>
        byte[] BufferArray { get; }

        /// <summary>
        /// Gets the offset of the start of the valid bytes in the buffer.
        /// </summary>
        /// <value>The zero-based offset.</value>
        int Offset { get; }

        /// <summary>
        /// Gets the number of valid bytes in the buffer.
        /// </summary>
        /// <value>The number of valid bytes.</value>
        int Count { get; }

        /// <summary>
        /// Writes to the buffer.
        /// </summary>
        /// <param name="buffer">The buffer to read from.</param>
        /// <param name="offset">The zero-based offset at which to start reading.</param>
        /// <param name="count">The number of bytes to read.</param>
        void Write(byte[] buffer, int offset, int count);
        
        /// <summary>
        /// Removes a number of bytes from the start of the buffer.
        /// </summary>
        /// <param name="count">The number of bytes to remove.</param>
        void Advance(int count);

        /// <summary>
        /// Returns a new array with the bytes of this buffer.
        /// </summary>
        /// <returns>A new array with the bytes of this buffer.</returns>
        byte[] ToArray();

        /// <summary>
        /// Returns a new array with the specified number of bytes from the start of this buffer.
        /// </summary>
        /// <param name="count">The number of bytes to return.</param>
        /// <returns>A new array with the specified number of bytes from this buffer.</returns>
        byte[] ToArray(int count);

        /// <summary>
        /// Gets a string from this buffer.
        /// </summary>
        /// <returns>A string with the UTF-8 decoded bytes of this buffer.</returns>
        string ToString();

        /// <summary>
        /// Gets a string from this buffer.
        /// </summary>
        /// <param name="encoding">The encoding to use.</param>
        /// <returns>A string with the decoded bytes of this buffer.</returns>
        string ToString(Encoding encoding);

        /// <summary>
        /// Gets a string from this buffer.
        /// </summary>
        /// <param name="encoding">The encoding to use.</param>
        /// <param name="count">The number of bytes to use.</param>
        /// <returns>A string with the specified number of decoded bytes from this buffer.</returns>
        string ToString(Encoding encoding, int count);
    }
}
