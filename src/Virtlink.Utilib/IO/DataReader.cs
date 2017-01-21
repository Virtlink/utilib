using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Virtlink.Utilib.IO
{
	/// <summary>
	/// Reads binary data.
	/// </summary>
	public class DataReader : IDisposable
	{
        /// <summary>
        /// Gets the default buffer size.
        /// </summary>
        /// <value>The default buffer size, in bytes.</value>
	    private static int DefaultBufferSize => 16;

        /// <summary>
        /// Gets the default data encoding.
        /// </summary>
        /// <value>The data encoding.</value>
	    public static DataEncoding DefaultDataEncoding => DataEncoding.LittleEndian;

        /// <summary>
        /// Gets the default text encoding.
        /// </summary>
        /// <value>The text encoding.</value>
        public static Encoding DefaultTextEncoding { get; } = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false);

	    /// <summary>
	    /// Gets the internal buffer.
	    /// </summary>
	    /// <value>The internal buffer.</value>
	    protected byte[] Buffer { get; } = new byte[DefaultBufferSize];

        /// <summary>
        /// Gets the underlying stream of the reader.
        /// </summary>
        /// <value>The underlying stream.</value>
        public Stream BaseStream { get; }

		/// <summary>
		/// Gets the data encoding to use.
		/// </summary>
		/// <value>An instance of the <see cref="DataEncoding"/> class.</value>
		public DataEncoding DataEncoding { get; }
        
		/// <summary>
		/// Gets the text encoding to use.
		/// </summary>
		/// <value>An <see cref="Encoding"/> instance.</value>
		public Encoding TextEncoding { get; }

	    #region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="DataReader"/> class.
		/// </summary>
		/// <param name="stream">The stream to read from.</param>
		/// <param name="dataEncoding">The data encoding to use.</param>
		/// <param name="textEncoding">The text encoding to use.</param>
		/// <remarks>
		/// The <paramref name="stream"/> is not disposed when this reader is disposed.
		/// </remarks>
		public DataReader(Stream stream, DataEncoding dataEncoding, Encoding textEncoding)
		{
            #region Contract
            if (stream == null)
                throw new ArgumentNullException(nameof(stream));
            if (dataEncoding == null)
                throw new ArgumentNullException(nameof(dataEncoding));
            if (textEncoding == null)
                throw new ArgumentNullException(nameof(textEncoding));
			#endregion

		    this.BaseStream = stream;
            this.DataEncoding = dataEncoding;
			this.TextEncoding = textEncoding;
		}

        /// <summary>
		/// Initializes a new instance of the <see cref="DataReader"/> class.
		/// </summary>
		/// <param name="stream">The stream to read from.</param>
		/// <remarks>
		/// <para>The <paramref name="stream"/> is not disposed when this reader is disposed.</para>
		/// <para>The default data encoding is little-endian, and the default text encoding is UTF8 without BOM.</para>
		/// </remarks>
		public DataReader(Stream stream)
            : this(stream, DataEncoding.LittleEndian, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false))
        {
            // Nothing to do.
        }
        #endregion

        #region Disposing
        /// <summary>
        /// Gets whether this object has been dispsoed.
        /// </summary>
        /// <value><see langword="true"/> when the object has been disposed;
        /// otherwise, <see langword="false"/>.</value>
        protected bool IsDisposed { get; private set; }

	    /// <summary>
		/// Asserts that this object has not been disposed, or throws an exception otherwise.
		/// </summary>
		/// <exception cref="ObjectDisposedException">
		/// The object has been disposed.
		/// </exception>
		protected void AssertNotDisposed()
		{
			if (this.IsDisposed)
				throw new ObjectDisposedException(this.GetType().FullName);
		}

		/// <inheritdoc />
		void IDisposable.Dispose()
		{
			Dispose();
		}

		/// <summary>
		/// Disposes resources.
		/// </summary>
		private void Dispose()
		{
			if (this.IsDisposed)
				return;
			DisposeManaged();
			DisposeUnmanaged();
			this.IsDisposed = true;
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Finalizes this object.
		/// </summary>
		~DataReader()
		{
			DisposeUnmanaged();
		}

		/// <summary>
		/// Disposes managed resources.
		/// </summary>
		protected virtual void DisposeManaged()
		{
			// Dispose managed resources here.
			// NOTE: The underlying stream is NOT closed here:
			// only resources created by this class are disposed.
		}

		/// <summary>
		/// Disposes unmanaged resources.
		/// </summary>
		protected virtual void DisposeUnmanaged()
		{
			// Dispose unmanaged resources here.
		}
        #endregion

        /// <summary>
        /// Reads a sequence of bytes from the stream.
        /// </summary>
        /// <param name="count">The number of bytes to read.</param>
        /// <returns>The read bytes.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
	    public byte[] ReadBytes(int count)
	    {
            #region Contract
            if (count < 0)
                throw new ArgumentNullException(nameof(count));
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a sequence of characters from the stream.
        /// </summary>
        /// <param name="count">The number of characters to read.</param>
        /// <returns>The read characters.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
        public char[] ReadChars(int count)
        {
            #region Contract
            if (count < 0)
                throw new ArgumentNullException(nameof(count));
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a single character from the stream.
        /// </summary>
        /// <returns>The read character.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
        public char ReadChar()
        {
            #region Contract
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a single unsigned 8-bit integer from the stream.
        /// </summary>
        /// <returns>The read unsigned byte.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
        public byte ReadByte()
        {
            #region Contract
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a single unsigned 16-bit integer from the stream.
        /// </summary>
        /// <returns>The read unsigned short.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
        public UInt16 ReadUInt16()
        {
            #region Contract
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a single unsigned 32-bit integer from the stream.
        /// </summary>
        /// <returns>The read unsigned int.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
        public UInt32 ReadUInt32()
        {
            #region Contract
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a single unsigned 64-bit integer from the stream.
        /// </summary>
        /// <returns>The read unsigned long.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
        public UInt64 ReadUInt64()
        {
            #region Contract
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a single signed 8-bit integer from the stream.
        /// </summary>
        /// <returns>The read signed byte.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
        public byte ReadSByte()
        {
            #region Contract
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a single signed 16-bit integer from the stream.
        /// </summary>
        /// <returns>The read signed short.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
        public Int16 ReadInt16()
        {
            #region Contract
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a single signed 32-bit integer from the stream.
        /// </summary>
        /// <returns>The read signed int.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
        public Int32 ReadInt32()
        {
            #region Contract
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a single signed 64-bit integer from the stream.
        /// </summary>
        /// <returns>The read signed long.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
        public Int64 ReadInt64()
        {
            #region Contract
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a single 32-bit floating-point value from the stream.
        /// </summary>
        /// <returns>The read float.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
        public Single ReadSingle()
        {
            #region Contract
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a single 64-bit floating-point value from the stream.
        /// </summary>
        /// <returns>The read double.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
        public Double ReadDouble()
        {
            #region Contract
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads a single decimal value from the stream.
        /// </summary>
        /// <returns>The read decimal.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
        public Decimal ReadDecimal()
        {
            #region Contract
            AssertNotDisposed();
            #endregion

            FillBuffer(16);
            int bytesUsed;
            var result = this.DataEncoding.ToDecimal(this.Buffer, 0, out bytesUsed);
            Debug.Assert(bytesUsed == 16);
            return result;
        }

        /// <summary>
        /// Reads a sequence of bytes from the stream into the buffer.
        /// </summary>
        /// <param name="buffer">The buffer into which to write the read data.</param>
        /// <param name="offset">The zero-based offset in the buffer at which to begin writing.</param>
        /// <param name="count">The maximum number of bytes to read.</param>
        /// <returns>The actual number of bytes read; or 0 when the end of the stream has been reached.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
	    public int Read(byte[] buffer, int offset, int count)
	    {
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (offset < 0 || offset > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(offset));
            if (count < 0 || offset + count > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(count));
            AssertNotDisposed();
            #endregion

	        return this.BaseStream.Read(buffer, offset, count);
        }

        /// <summary>
        /// Reads a sequence of characters from the stream into the buffer.
        /// </summary>
        /// <param name="buffer">The buffer into which to write the read data.</param>
        /// <param name="offset">The zero-based offset in the buffer at which to begin writing.</param>
        /// <param name="count">The maximum number of characters to read.</param>
        /// <returns>The actual number of characters read; or 0 when the end of the stream has been reached.</returns>
        /// <exception cref="ObjectDisposedException">
        /// The stream or the reader was closed.
        /// </exception>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
	    public int Read(char[] buffer, int offset, int count)
        {
            #region Contract
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (offset < 0 || offset > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(offset));
            if (count < 0 || offset + count > buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(count));
            AssertNotDisposed();
            #endregion

            throw new NotImplementedException();
        }

        /// <summary>
        /// Fills the internal buffer with the specified number of bytes from the stream.
        /// </summary>
        /// <param name="count">The number of bytes to read from the stream.</param>
        /// <exception cref="EndOfStreamException">
        /// The end of the stream was reached before all bytes could be read.
        /// </exception>
        /// <exception cref="IOException">
        /// An I/O exception occurred.
        /// </exception>
	    protected void FillBuffer(int count)
	    {
            #region Contract
            if (count < 0 || count > this.Buffer.Length)
                throw new ArgumentOutOfRangeException(nameof(count));
            AssertNotDisposed();
            #endregion

            int totalRead = 0;
	        while (totalRead < count)
	        {
	            int read = this.BaseStream.Read(this.Buffer, totalRead, count - totalRead);
                if (read == 0)
                    throw new EndOfStreamException();
	            totalRead += read;
	        }
	    }

        /// <summary>
        /// Closes the reader.
        /// </summary>
        public void Close()
        {
            Dispose();
        }
    }
}
