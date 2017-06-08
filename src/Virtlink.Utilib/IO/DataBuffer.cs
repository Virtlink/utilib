using System;
using System.Diagnostics;
using System.Text;
using JetBrains.Annotations;

namespace Virtlink.Utilib.IO
{
    /// <summary>
    /// A data buffer.
    /// </summary>
    public sealed class DataBuffer : IBuffer
    {
        /// <summary>
        /// The default capacity of the buffer if none is given.
        /// </summary>
        private const int DefaultCapacity = 16;

        /// <summary>
        /// The minimum buffer size.
        /// </summary>
        private const int MinimumBufferSize = 16;
        
        /// <inheritdoc />
        public byte[] BufferArray { get; private set; }

        /// <inheritdoc />
        public int Offset { get; private set; }

        /// <inheritdoc />
        public int Count { get; private set; }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBuffer"/> class.
        /// </summary>
        public DataBuffer()
            : this(DefaultCapacity)
        {
            // Nothing to do.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBuffer"/> class.
        /// </summary>
        /// <param name="capacity">The initial minimum capacity of the buffer.</param>
        public DataBuffer(int capacity)
        {
            #region Contract
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));
            #endregion

            this.BufferArray = new byte[GetNewBufferSize(capacity)];
        }
        #endregion

        /// <summary>
        /// Writes to the buffer.
        /// </summary>
        /// <param name="buffer">The buffer to read from.</param>
        /// <param name="offset">The zero-based offset at which to start reading.</param>
        /// <param name="count">The number of bytes to read.</param>
        public void Write(byte[] buffer, int offset, int count)
        {
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (offset < 0 || offset > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(offset));
            if (count < 0 || offset + count > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(count));
            #endregion

            // Is the remaining size of the buffer big enough?
            int remaining = this.BufferArray.Length - (this.Offset + this.Count);
            if (count > remaining)
            {
                // The buffer is too small.
                // We need to copy stuff.
                byte[] newBuffer;

                // Would the buffer be big enough if we removed all the bytes before the offset?
                int available = this.BufferArray.Length - this.Count;
                if (count > available)
                {
                    // No, the buffer is still too small.
                    // Let's allocate a new buffer that's big enough.
                    int newSize = GetNewBufferSize(this.Count + count);
                    newBuffer = new byte[newSize];
                }
                else
                {
                    // The buffer would be big enough. Let's reuse it.
                    newBuffer = this.BufferArray;
                }

                // The buffer is big enough to copy our stuff backward.
                Debug.Assert(count <= (newBuffer.Length - this.Count));

                // Copy our stuff.
                Buffer.BlockCopy(this.BufferArray, this.Offset, newBuffer, 0, this.Count);

                this.BufferArray = newBuffer;
                this.Offset = 0;
            }

            // The buffer is big enough.
            Debug.Assert(count <= (this.BufferArray.Length - (this.Offset + this.Count)));

            // Copy their stuff.
            Buffer.BlockCopy(buffer, offset, this.BufferArray, this.Offset + this.Count, count);
            this.Count += count;
        }

        /// <summary>
        /// Determines the new size of the buffer.
        /// </summary>
        /// <param name="minimumSize">The minimum size of the buffer.</param>
        /// <returns>The new size of the buffer.</returns>
        [Pure]
        private int GetNewBufferSize(int minimumSize)
        {
            var size = Math.Max(BinaryMath.RoundToNextPowerOfTwoOrZero(minimumSize), MinimumBufferSize);
            Debug.Assert(size > (this.BufferArray?.Length ?? 0));
            return size;
        }

        /// <summary>
        /// Removes a number of bytes from the start of the buffer.
        /// </summary>
        /// <param name="count">The number of bytes to remove.</param>
        public void Advance(int count)
        {
            #region Contract
            if (count < 0 || count > this.Count)
                throw new ArgumentOutOfRangeException(nameof(count));
            #endregion

            this.Offset += count;
            this.Count -= count;
        }

        /// <summary>
        /// Returns a new array with the bytes of this buffer.
        /// </summary>
        /// <returns>A new array with the bytes of this buffer.</returns>
        public byte[] ToArray()
        {
            return ToArray(this.Count);
        }

        /// <summary>
        /// Returns a new array with the specified number of bytes from the start of this buffer.
        /// </summary>
        /// <param name="count">The number of bytes to return.</param>
        /// <returns>A new array with the specified number of bytes from this buffer.</returns>
        public byte[] ToArray(int count)
        {
            #region Contract
            if (count < 0 || count > this.Count)
                throw new ArgumentOutOfRangeException(nameof(count));
            #endregion

            if (count == 0)
                return new byte[0];

            var array = new byte[count];
            Buffer.BlockCopy(this.BufferArray, this.Offset, array, 0, count);
            return array;
        }

        /// <summary>
        /// Gets a string from this buffer.
        /// </summary>
        /// <returns>A string with the UTF-8 decoded bytes of this buffer.</returns>
        public override string ToString()
        {
            // Assumption: the data uses UTF-8.
            return ToString(Encoding.UTF8);
        }

        /// <summary>
        /// Gets a string from this buffer.
        /// </summary>
        /// <param name="encoding">The encoding to use.</param>
        /// <returns>A string with the decoded bytes of this buffer.</returns>
        public string ToString(Encoding encoding)
        {
            return ToString(encoding, this.Count);
        }

        /// <summary>
        /// Gets a string from this buffer.
        /// </summary>
        /// <param name="encoding">The encoding to use.</param>
        /// <param name="count">The number of bytes to use.</param>
        /// <returns>A string with the specified number of decoded bytes from this buffer.</returns>
        public string ToString(Encoding encoding, int count)
        {
            #region Contract
            if (count > this.Count)
                throw new ArgumentOutOfRangeException(nameof(count));
            #endregion

            if (count == 0)
                return String.Empty;

            return encoding.GetString(this.BufferArray, this.Offset, count);
        }
    }
}
