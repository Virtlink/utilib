using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
#if NET45
using System;
using System.Runtime.Remoting;
#endif

namespace Virtlink.Utilib.IO
{
    /// <summary>
    /// Wrapper for a <see cref="Stream"/> that prevent the underlying
    /// stream from being closed or disposed.
    /// </summary>
    internal sealed class NonClosingStreamWrapper : Stream
    {
        /// <summary>
        /// Gets the underlying base stream.
        /// </summary>
        /// <value>The base stream.</value>
        public Stream BaseStream { get; }

        /// <inheritdoc />
        public override bool CanRead => this.BaseStream.CanRead;

        /// <inheritdoc />
        public override bool CanSeek => this.BaseStream.CanSeek;

        /// <inheritdoc />
        public override bool CanWrite => this.BaseStream.CanWrite;

        /// <inheritdoc />
        public override long Length => this.BaseStream.Length;

        /// <inheritdoc />
        public override bool CanTimeout => this.BaseStream.CanTimeout;

        /// <inheritdoc />
        public override int ReadTimeout => this.BaseStream.ReadTimeout;

        /// <inheritdoc />
        public override int WriteTimeout => this.BaseStream.WriteTimeout;

        /// <inheritdoc />
        public override long Position
        {
            get { return this.BaseStream.Position; }
            set { this.BaseStream.Position = value; }
        }

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NonClosingStreamWrapper"/> class.
        /// </summary>
        /// <param name="baseStream">The underlying base stream.</param>
        internal NonClosingStreamWrapper(Stream baseStream)
        {
            #region Contract
            Debug.Assert(baseStream != null);
            #endregion

            this.BaseStream = baseStream;
        }
        #endregion

        /// <inheritdoc />
        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.BaseStream.Seek(offset, origin);
        }

        /// <inheritdoc />
        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.BaseStream.Read(buffer, offset, count);
        }

        /// <inheritdoc />
        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return this.BaseStream.ReadAsync(buffer, offset, count, cancellationToken);
        }

        /// <inheritdoc />
        public override int ReadByte()
        {
            return this.BaseStream.ReadByte();
        }

#if NET45
        /// <inheritdoc />
		public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return this.BaseStream.BeginRead(buffer, offset, count, callback, state);
		}

		/// <inheritdoc />
		public override int EndRead(IAsyncResult asyncResult)
		{
			return this.BaseStream.EndRead(asyncResult);
		}
#endif

        /// <inheritdoc />
        public override void Write(byte[] buffer, int offset, int count)
        {
            this.BaseStream.Write(buffer, offset, count);
        }

        /// <inheritdoc />
        public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return this.BaseStream.WriteAsync(buffer, offset, count, cancellationToken);
        }

        /// <inheritdoc />
        public override void WriteByte(byte value)
        {
            this.BaseStream.WriteByte(value);
        }

#if NET45
        /// <inheritdoc />
		public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return this.BaseStream.BeginWrite(buffer, offset, count, callback, state);
		}

		/// <inheritdoc />
		public override void EndWrite(IAsyncResult asyncResult)
		{
			this.BaseStream.EndWrite(asyncResult);
		}
#endif

        /// <inheritdoc />
        public override void Flush()
        {
            this.BaseStream.Flush();
        }

        /// <inheritdoc />
        public override Task FlushAsync(CancellationToken cancellationToken)
        {
            return this.BaseStream.FlushAsync(cancellationToken);
        }

        /// <inheritdoc />
        public override void SetLength(long value)
        {
            this.BaseStream.SetLength(value);
        }

        /// <inheritdoc />
        public override Task CopyToAsync(Stream destination, int bufferSize, CancellationToken cancellationToken)
        {
            return this.BaseStream.CopyToAsync(destination, bufferSize, cancellationToken);
        }

#if NET45
        /// <inheritdoc />
		public override object InitializeLifetimeService()
		{
			return this.BaseStream.InitializeLifetimeService();
		}

		/// <inheritdoc />
		public override ObjRef CreateObjRef(Type requestedType)
		{
			return this.BaseStream.CreateObjRef(requestedType);
		}

		/// <inheritdoc />
		public override void Close()
		{
			// Ignored.
		}
#endif

        /// <inheritdoc />
        protected override void Dispose(bool disposing)
        {
            // Ignored.
        }
    }
}