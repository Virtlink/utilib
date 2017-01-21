using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Virtlink.Utilib.IO
{
	/// <summary>
	/// An exception that is thrown when a buffer is not big enough.
	/// </summary>
	public class BufferCapacityInsufficientException : InvalidOperationException
	{
		/// <summary>
		/// The default message.
		/// </summary>
		private const string DefaultMessage = "The buffer is not big enough.";

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="BufferCapacityInsufficientException"/> class.
		/// </summary>
		public BufferCapacityInsufficientException()
			: this((string)null)
		{
			// Nothing to do.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BufferCapacityInsufficientException"/> class.
		/// </summary>
		/// <param name="innerException">The inner exception; or <see langword="null"/> to specify none.</param>
		public BufferCapacityInsufficientException(Exception innerException)
			: this(null, innerException)
		{
			// Nothing to do.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BufferCapacityInsufficientException"/> class.
		/// </summary>
		/// <param name="message">The exception message; or <see langword="null"/> to use the default message.</param>
		public BufferCapacityInsufficientException(string message)
			: base(message ?? DefaultMessage)
		{
			// Nothing to do.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BufferCapacityInsufficientException"/> class.
		/// </summary>
		/// <param name="message">The exception message; or <see langword="null"/> to use the default message.</param>
		/// <param name="innerException">The inner exception; or <see langword="null"/> to specify none.</param>
		public BufferCapacityInsufficientException(string message, Exception innerException)
			: base(message ?? DefaultMessage, innerException)
		{
			// Nothing to do.
		}
		#endregion
	}
}
