using System;
using System.Globalization;
using System.Text;
using JetBrains.Annotations;

namespace Virtlink.Utilib
{
    /// <summary>
    /// Exception thrown when using an invalid enum value.
    /// </summary>
    public sealed class EnumArgumentException : ArgumentException
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumArgumentException"/> class.
        /// </summary>
        public EnumArgumentException()
            : this(null, null)
        {
            // Nothing to do.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumArgumentException"/> class.
        /// </summary>
        /// <param name="message">The exception message; or <see langword="null"/> to use the default message.</param>
        public EnumArgumentException([CanBeNull] string message)
            : this(message, null)
        {
            // Nothing to do.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumArgumentException"/> class.
        /// </summary>
        /// <param name="message">The exception message; or <see langword="null"/> to use the default message.</param>
        /// <param name="innerException">The exception that caused this exception; or <see langword="null"/>.</param>
        public EnumArgumentException([CanBeNull] string message, [CanBeNull] Exception innerException)
            : base(message ?? ToMessage(null, null, null), innerException)
        {
            // Nothing to do.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnumArgumentException"/> class.
        /// </summary>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="invalidValue">The invalid enum value.</param>
        /// <param name="enumType">The enum type.</param>
        public EnumArgumentException([CanBeNull] string paramName, int invalidValue, [CanBeNull] Type enumType)
            : base(ToMessage(paramName, invalidValue, enumType), paramName)
        {
            // Nothing to do.
        }
        #endregion

        /// <summary>
        /// Returns the exception message.
        /// </summary>
        /// <param name="paramName">The parameter name.</param>
        /// <param name="invalidValue">The invalid enum value.</param>
        /// <param name="enumType">The enum type.</param>
        /// <returns>The exception message.</returns>
        private static string ToMessage([CanBeNull] string paramName, [CanBeNull] int? invalidValue,
            [CanBeNull] Type enumType)
        {
            var sb = new StringBuilder();
            sb.Append("The value of argument");
            if (paramName != null)
                sb.Append(" '").Append(paramName).Append("'");
            if (invalidValue != null)
                sb.Append(" (").Append(((int)invalidValue).ToString(CultureInfo.InvariantCulture)).Append(")");
            sb.Append(" is invalid for Enum type");
            if (enumType != null)
                sb.Append(" '").Append(enumType.Name).Append("'");
            sb.Append(".");
            return sb.ToString();
        }
    }
}