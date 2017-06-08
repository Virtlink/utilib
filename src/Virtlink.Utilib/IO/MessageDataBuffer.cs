using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Virtlink.Utilib.IO
{
    /// <summary>
    /// A data buffer that can recognize the end of a message.
    /// </summary>
    public sealed class MessageDataBuffer : IBuffer
    {
        /// <summary>
        /// The wrapped buffer.
        /// </summary>
        private readonly IBuffer innerBuffer;

        /// <summary>
        /// The boundary bytes to look for.
        /// </summary>
        private readonly byte[] boundary;

        /// <summary>
        /// Offset (starting at this.Offset) in the buffer that was last checked for the boundary.
        /// </summary>
        private int lastCheckedOffset;

        /// <inheritdoc />
        public byte[] BufferArray => this.innerBuffer.BufferArray;

        /// <inheritdoc />
        public int Offset => this.innerBuffer.Offset;

        /// <inheritdoc />
        public int Count => this.innerBuffer.Count;

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageDataBuffer"/> class.
        /// </summary>
        /// <param name="innerBuffer">The inner buffer.</param>
        /// <param name="messageBoundary">The boundary bytes to look for.</param>
        public MessageDataBuffer(IBuffer innerBuffer, byte[] messageBoundary)
        {
            #region Contract
            if (innerBuffer == null)
                throw new ArgumentNullException(nameof(innerBuffer));
            if (messageBoundary == null)
                throw new ArgumentNullException(nameof(messageBoundary));
            #endregion

            this.lastCheckedOffset = 0;
            this.innerBuffer = innerBuffer;
            this.boundary = messageBoundary.ToArray();
        }
        #endregion

        /// <summary>
        /// Writes to the buffer.
        /// </summary>
        /// <param name="buffer">The buffer to read from.</param>
        /// <param name="offset">The zero-based offset at which to start reading.</param>
        /// <param name="count">The number of bytes to read.</param>
        public void Write(byte[] buffer, int offset, int count)
            => this.innerBuffer.Write(buffer, offset, count);

        /// <summary>
        /// Removes a number of bytes from the start of the buffer.
        /// </summary>
        /// <param name="count">The number of bytes to remove.</param>
        public void Advance(int count)
        {
            #region Contract
            if (count > this.Count)
                throw new ArgumentOutOfRangeException(nameof(count));
            #endregion

            this.innerBuffer.Advance(count);
            this.lastCheckedOffset = Math.Max(this.lastCheckedOffset + count, 0);
            Debug.Assert(this.lastCheckedOffset <= this.Count);
        }

        /// <summary>
        /// Returns a new array with the bytes of this buffer.
        /// </summary>
        /// <returns>A new array with the bytes of this buffer.</returns>
        public byte[] ToArray()
            => this.innerBuffer.ToArray();

        /// <summary>
        /// Returns a new array with the specified number of bytes from the start of this buffer.
        /// </summary>
        /// <param name="count">The number of bytes to return.</param>
        /// <returns>A new array with the specified number of bytes from this buffer.</returns>
        public byte[] ToArray(int count)
            => this.innerBuffer.ToArray(count);

        /// <summary>
        /// Gets a string from this buffer.
        /// </summary>
        /// <returns>A string with the UTF-8 decoded bytes of this buffer.</returns>
        public override string ToString()
            => this.innerBuffer.ToString();

        /// <summary>
        /// Gets a string from this buffer.
        /// </summary>
        /// <param name="encoding">The encoding to use.</param>
        /// <returns>A string with the decoded bytes of this buffer.</returns>
        public string ToString(Encoding encoding)
            => this.innerBuffer.ToString(encoding);

        /// <summary>
        /// Gets a string from this buffer.
        /// </summary>
        /// <param name="encoding">The encoding to use.</param>
        /// <param name="count">The number of bytes to use.</param>
        /// <returns>A string with the specified number of decoded bytes from this buffer.</returns>
        public string ToString(Encoding encoding, int count)
            => this.innerBuffer.ToString(encoding, count);

        /// <summary>
        /// Looks through the buffer and finds the index of the start of the next message boundary.
        /// </summary>
        /// <returns>The length of the message, excluding the boundary; or <see langword="null"/> if not found.</returns>
        public int? TryGetNextMessageBoundary()
        {
            #region Contract
            if (this.boundary == null)
                throw new InvalidOperationException("No boundary bytes where specified when this buffer was instantated.");
            #endregion

            // First byte to check.
            int start = this.Offset + this.lastCheckedOffset;
            // Last byte to check.
            int end = (this.Offset + this.Count) - this.boundary.Length;

            // Check each of the bytes.
            for (int i = start; i <= end; i++)
            {
                if (TryMatch(i))
                {
                    // Match found at i!
                    var match = i - this.Offset;
                    this.lastCheckedOffset = match;
                    Debug.Assert(this.lastCheckedOffset <= this.Count);
                    return match;
                }
            }

            // Nothing found.
            this.lastCheckedOffset = end - this.Offset;
            Debug.Assert(this.lastCheckedOffset <= this.Count);
            return null;
        }

        /// <summary>
        /// Attempts to find a match of the boundary bytes.
        /// </summary>
        /// <param name="offset">The offset to check.</param>
        /// <returns><see langword="true"/> when the boundary bytes were found;
        /// otherwise, <see langword="false"/>.</returns>
        private bool TryMatch(int offset)
        {
            #region Contract
            Debug.Assert(offset >= 0 && offset <= this.Count);
            #endregion

            byte[] rawBuffer = this.BufferArray;
            if (rawBuffer[offset] == this.boundary[0])
            {
                // The first character matches, we have a chance.
                for (int j = 1; j < this.boundary.Length; j++)
                {
                    if (rawBuffer[offset + j] != this.boundary[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
