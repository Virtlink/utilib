using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Virtlink.Utilib.IO
{
	/// <summary>
	/// An exception that is thrown when the binary representation of data is incorrect.
	/// </summary>
	public class DataFormatException : InvalidOperationException
	{
		/// <summary>
		/// The default message.
		/// </summary>
		private const string DefaultMessage = "The binary representation is incorrect.";

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="DataFormatException"/> class.
		/// </summary>
		public DataFormatException()
			: this((string)null)
		{
			// Nothing to do.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataFormatException"/> class.
		/// </summary>
		/// <param name="innerException">The inner exception; or <see langword="null"/> to specify none.</param>
		public DataFormatException(Exception innerException)
			: this(null, innerException)
		{
			// Nothing to do.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataFormatException"/> class.
		/// </summary>
		/// <param name="message">The exception message; or <see langword="null"/> to use the default message.</param>
		public DataFormatException(string message)
			: base(message ?? DefaultMessage)
		{
			// Nothing to do.
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DataFormatException"/> class.
		/// </summary>
		/// <param name="message">The exception message; or <see langword="null"/> to use the default message.</param>
		/// <param name="innerException">The inner exception; or <see langword="null"/> to specify none.</param>
		public DataFormatException(string message, Exception innerException)
			: base(message ?? DefaultMessage, innerException)
		{
			// Nothing to do.
		}
		#endregion
	}
}
