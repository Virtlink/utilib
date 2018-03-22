using System;
using System.Diagnostics;
using System.Globalization;

namespace Virtlink.Utilib.Text
{
    /// <summary>
	/// A code point.
	/// </summary>
	/// <remarks>
	/// This is a code point for no specific encoding.
	/// </remarks>
    public struct CodePoint : IEquatable<CodePoint>, IComparable<CodePoint>, IComparable, IFormattable
    {
        /// <summary>
        /// The maximum value of a Unicode code point.
        /// </summary>
        private const int MaxCodePoint = 0x10FFFF;
        /// <summary>
        /// The maximum code point value to be encoded as a surrogate pair.
        /// </summary>
        private const int MaxSurrogate = 0x10FFFF;
        /// <summary>
        /// The minimum code point value to be encoded as a surrogate pair.
        /// </summary>
        private const int MinSurrogate = 0x10000;
        /// <summary>
        /// The minimum value of a Unicode code point.
        /// </summary>
        private const int MinCodePoint = 0;
        /// <summary>
        /// Special value used to denote the End-Of-File.
        /// </summary>
        private const int EofValue = -1;

        /// <summary>
        /// Gets the code point representing the End-Of-File.
        /// </summary>
        /// <value>The code point representing the End-Of-File.</value>
        public static CodePoint Eof { get; } = new CodePoint(true);

        /// <summary>
        /// Gets the maximum Unicode code point.
        /// </summary>
        /// <value>The maximum Unicode code point.</value>
        public static CodePoint MaxValue { get; } = new CodePoint(MaxCodePoint);

        /// <summary>
        /// Gets the minium Unicode code point.
        /// </summary>
        /// <value>The minimum Unicode code point.</value>
        public static CodePoint MinValue { get; } = new CodePoint(MinCodePoint);

        /// <summary>
        /// The numeric value of the code point.
        /// </summary>
        /// <value>The numeric value.</value>
        private readonly int value;

        /// <summary>
        /// Gets the numeric value of the code point.
        /// </summary>
        /// <value>The numeric value.</value>
        public int Value
            => this.value >= CodePoint.MinCodePoint
             ? this.value
             : throw new InvalidOperationException("This code point represents EOF, and therefore has no value.");

        /// <summary>
        /// Gets whether the code point represents the End-Of-File.
        /// </summary>
        /// <value><see langword="true"/> when the code point represents the End-Of-File;
        /// otherwise, <see langword="false"/>.</value>
        public bool IsEof => this.value == CodePoint.EofValue;

        /// <summary>
        /// Gets the Unicode category of the code point.
        /// </summary>
        /// <value>The Unicode category.</value>
        public UnicodeCategory Category
        {
            get
            {
                #region Contract
                if (this.IsEof)
                    throw new InvalidOperationException("Operation is not allowed on a code point representing EOF.");
                #endregion

                var cTuple = ToChars();
                var c0 = cTuple.Item1;
                var c1 = cTuple.Item2;
                if (c1 != null)
                {
                    // Surrogate pair.
                    return CharUnicodeInfo.GetUnicodeCategory(new string(new[] { c0, (char)c1 }), 0);
                }
                else
                {
                    // Not a surrogate pair.
                    return CharUnicodeInfo.GetUnicodeCategory(c0);
                }
            }
        }

        /// <summary>
        /// Gets whether the code point is categorized as a control character.
        /// </summary>
        /// <value><see langword="true"/> when the code point is a control character;
        /// otherwise, <see langword="false"/>.</value>
        public bool IsControl => !this.IsEof && IsCategory(UnicodeCategory.Control);

        /// <summary>
        /// Gets whether the code point is categorized as a digit.
        /// </summary>
        /// <value><see langword="true"/> when the code point is a digit;
        /// otherwise, <see langword="false"/>.</value>
        public bool IsDigit => !this.IsEof && IsCategory(UnicodeCategory.DecimalDigitNumber);

        /// <summary>
        /// Gets whether the code point is categorized as a letter.
        /// </summary>
        /// <value><see langword="true"/> when the code point is a letter;
        /// otherwise, <see langword="false"/>.</value>
        /// <remarks>
        /// The space is considered a separator or whitespace, not a letter.
        /// </remarks>
        public bool IsLetter => !this.IsEof
                             && IsCategory(
                                     UnicodeCategory.UppercaseLetter,
                                     UnicodeCategory.LowercaseLetter,
                                     UnicodeCategory.TitlecaseLetter,
                                     UnicodeCategory.ModifierLetter,
                                     UnicodeCategory.OtherLetter);

        /// <summary>
        /// Gets whether the code point is categorized as a letter or digit.
        /// </summary>
        /// <value><see langword="true"/> when the code point is a letter or digit;
        /// otherwise, <see langword="false"/>.</value>
        public bool IsLetterOrDigit => !this.IsEof && (this.IsLetter || this.IsDigit);

        /// <summary>
        /// Gets whether the code point is categorized as a lowercase letter.
        /// </summary>
        /// <value><see langword="true"/> when the code point is a lowercase letter;
        /// otherwise, <see langword="false"/>.</value>
        public bool IsLower => !this.IsEof && IsCategory(UnicodeCategory.LowercaseLetter);

        /// <summary>
        /// Gets whether the code point is categorized as an uppercase letter.
        /// </summary>
        /// <value><see langword="true"/> when the code point is an uppercase letter;
        /// otherwise, <see langword="false"/>.</value>
        public bool IsUpper => !this.IsEof && IsCategory(UnicodeCategory.UppercaseLetter);

        /// <summary>
        /// Gets whether the code point is categorized as a number.
        /// </summary>
        /// <value><see langword="true"/> when the code point is a number;
        /// otherwise, <see langword="false"/>.</value>
        public bool IsNumber => !this.IsEof
                             && IsCategory(
                                    UnicodeCategory.DecimalDigitNumber,
                                    UnicodeCategory.LetterNumber,
                                    UnicodeCategory.OtherNumber);

        /// <summary>
        /// Gets whether the code point is categorized as punctuation.
        /// </summary>
        /// <value><see langword="true"/> when the code point is punctuation;
        /// otherwise, <see langword="false"/>.</value>
        public bool IsPunctuation => !this.IsEof
                                  && IsCategory(
                                        UnicodeCategory.ConnectorPunctuation,
                                        UnicodeCategory.DashPunctuation,
                                        UnicodeCategory.OpenPunctuation,
                                        UnicodeCategory.ClosePunctuation,
                                        UnicodeCategory.InitialQuotePunctuation,
                                        UnicodeCategory.FinalQuotePunctuation,
                                        UnicodeCategory.OtherPunctuation);

        /// <summary>
        /// Gets whether the code point is categorized as a separator.
        /// </summary>
        /// <value><see langword="true"/> when the code point is a separator;
        /// otherwise, <see langword="false"/>.</value>
        public bool IsSeparator => !this.IsEof
                                && IsCategory(
                                        UnicodeCategory.SpaceSeparator,
                                        UnicodeCategory.LineSeparator,
                                        UnicodeCategory.ParagraphSeparator);

        /// <summary>
        /// Gets whether the code point is categorized as whitespace.
        /// </summary>
        /// <value><see langword="true"/> when the code point is whitespace;
        /// otherwise, <see langword="false"/>.</value>
        public bool IsWhitespace => !this.IsEof
                                 && (this.IsSeparator
                                  || (this.value >= 0x0009 && this.value <= 0x000D)  // TAB, LINE FEED, VERTICAL TAB, FORM FEED, CARRIAGE RETURN
                                  || this.value == 0x0085);      // NEXT LINE (NEL)

        /// <summary>
        /// Gets whether the code point is categorized as a symbol.
        /// </summary>
        /// <value><see langword="true"/> when the code point is a symbol;
        /// otherwise, <see langword="false"/>.</value>
        public bool IsSymbol => !this.IsEof && IsCategory(
                                    UnicodeCategory.MathSymbol,
                                    UnicodeCategory.CurrencySymbol,
                                    UnicodeCategory.ModifierSymbol,
                                    UnicodeCategory.OtherSymbol);



        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CodePoint"/> class.
        /// </summary>
        /// <param name="value">The value of the code point.</param>
        public CodePoint(int value)
        {
            #region Contract
            if (value < MinCodePoint || MaxCodePoint < value)
                throw new ArgumentOutOfRangeException(nameof(value));
            #endregion

            this.value = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodePoint"/> class.
        /// </summary>
        /// <param name="value">The value of the code point.</param>
        public CodePoint(char value) : this((int)value) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodePoint"/> class.
        /// </summary>
        /// <param name="value">The value of the code point.</param>
        /// <remarks>
        /// The value must be a single character or a surrogate pair.
        /// </remarks>
        public CodePoint(string value)
        {
            if (value.Length == 1)
            {
                // A single character.
                this.value = value[0];
            }
            else if (value.Length == 2 && Char.IsSurrogatePair(value, 0))
            {
                // A surrogate pair.
                this.value = 0x10000
                           + (value[0] & 0x03FF) << 10
                           + (value[1] & 0x03FF);
            }
            else
            {
                throw new ArgumentException("The value must be a single character or a surrogate pair.", nameof(value));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CodePoint"/> class.
        /// </summary>
        /// <param name="eof">Always <see langword="true"/>.</param>
        private CodePoint(bool eof)
        {
            #region Contract
            Debug.Assert(eof);
            #endregion

            this.value = CodePoint.EofValue;
        }
        #endregion

        #region Equality
        /// <inheritdoc />
        public override bool Equals(object obj) => obj is CodePoint && Equals((CodePoint)obj);

        /// <inheritdoc />
        public bool Equals(CodePoint other)
        {
            return this.value == other.value;
        }

        /// <inheritdoc />
        // ReSharper disable once ImpureMethodCallOnReadonlyValueField
        public override int GetHashCode() => this.value.GetHashCode();

        /// <summary>
        /// Returns a value that indicates whether two specified <see cref="CodePoint"/> objects are equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are equal;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(CodePoint left, CodePoint right) => Object.Equals(left, right);

        /// <summary>
        /// Returns a value that indicates whether two specified <see cref="CodePoint"/> objects are not equal.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> and <paramref name="right"/> are not equal;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator !=(CodePoint left, CodePoint right) => !(left == right);
        #endregion

        #region Comparity
        /// <inheritdoc />
        public int CompareTo(CodePoint other)
        {
            // Only EOF is equal to EOF;
            // all other code points are greater than EOF.

            // ReSharper disable once ImpureMethodCallOnReadonlyValueField
            return this.value.CompareTo(other.value);
        }

        /// <inheritdoc />
        public int CompareTo(object obj)
        {
            if (!(obj is CodePoint))
                throw new ArgumentException("Type mismatch.");
            return CompareTo((CodePoint)obj);
        }

        /// <summary>
        /// Returns a value that indicates whether one <see cref="CodePoint"/> is greater than another.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> is greater than <paramref name="right"/>;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator >(CodePoint left, CodePoint right) => left.CompareTo(right) > 0;

        /// <summary>
        /// Returns a value that indicates whether one <see cref="CodePoint"/> is greater than or equal to another.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> is greater than or equal to <paramref name="right"/>;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator >=(CodePoint left, CodePoint right) => left.CompareTo(right) >= 0;

        /// <summary>
        /// Returns a value that indicates whether one <see cref="CodePoint"/> is less than another.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> is less than <paramref name="right"/>;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator <(CodePoint left, CodePoint right) => left.CompareTo(right) < 0;

        /// <summary>
        /// Returns a value that indicates whether one <see cref="CodePoint"/> is less than or equal to another.
        /// </summary>
        /// <param name="left">The first object to compare.</param>
        /// <param name="right">The second object to compare.</param>
        /// <returns><see langword="true"/> if <paramref name="left"/> is less than or equal to <paramref name="right"/>;
        /// otherwise, <see langword="false"/>.</returns>
        public static bool operator <=(CodePoint left, CodePoint right) => left.CompareTo(right) <= 0;
        #endregion

        #region Arithmetic
        /// <summary>
        /// Computes adding an offset to a <see cref="CodePoint"/>.
        /// </summary>
        /// <param name="codePoint">The code point.</param>
        /// <param name="offset">The offset to add.</param>
        /// <returns>The resulting code point.</returns>
        /// <exception cref="InvalidOperationException">
        /// The addition would result in a code point outside the range of allowed values.
        /// </exception>
        public static CodePoint operator +(CodePoint codePoint, int offset)
        {
            #region Contract
            if (codePoint.IsEof)
                throw new InvalidOperationException("Operation is not allowed on a code point representing EOF.");
            #endregion

            try
            {
                return new CodePoint(codePoint.Value + offset);
            }
            catch (ArgumentException)
            {
                throw new InvalidOperationException("The addition would result in a code point outside the range of allowed values.");
            }
        }

        /// <summary>
        /// Computes incrementing a <see cref="CodePoint"/>.
        /// </summary>
        /// <param name="codePoint">The code point.</param>
        /// <returns>The resulting code point.</returns>
        /// <exception cref="InvalidOperationException">
        /// The addition would result in a code point outside the range of allowed values.
        /// </exception>
        public static CodePoint operator ++(CodePoint codePoint)
        {
            #region Contract
            if (codePoint.IsEof)
                throw new InvalidOperationException("Operation is not allowed on a code point representing EOF.");
            #endregion

            return codePoint + 1;
        }

        /// <summary>
        /// Computes subtracting an offset from a <see cref="CodePoint"/>.
        /// </summary>
        /// <param name="codePoint">The code point.</param>
        /// <param name="offset">The offset to subtarct.</param>
        /// <returns>The resulting code point.</returns>
        /// <exception cref="InvalidOperationException">
        /// The subtraction would result in a code point outside the range of allowed values.
        /// </exception>
        public static CodePoint operator -(CodePoint codePoint, int offset)
        {
            #region Contract
            if (codePoint.IsEof)
                throw new InvalidOperationException("Operation is not allowed on a code point representing EOF.");
            #endregion

            try
            {
                return new CodePoint(codePoint.Value - offset);
            }
            catch (ArgumentException)
            {
                throw new InvalidOperationException("The subtraction would result in a code point outside the range of allowed values.");
            }
        }

        /// <summary>
        /// Computes decrementing a <see cref="CodePoint"/>.
        /// </summary>
        /// <param name="codePoint">The code point.</param>
        /// <returns>The resulting code point.</returns>
        /// <exception cref="InvalidOperationException">
        /// The subtraction would result in a code point outside the range of allowed values.
        /// </exception>
        public static CodePoint operator --(CodePoint codePoint)
        {
            #region Contract
            if (codePoint.IsEof)
                throw new InvalidOperationException("Operation is not allowed on a code point representing EOF.");
            #endregion

            return codePoint - 1;
        }

        /// <summary>
        /// Computes subtracting a <see cref="CodePoint"/> from another <see cref="CodePoint"/>.
        /// </summary>
        /// <param name="left">The first code point.</param>
        /// <param name="right">The second code point.</param>
        /// <returns>The resulting difference.</returns>
        public static int operator -(CodePoint left, CodePoint right)
        {
            #region Contract
            if (left.IsEof || right.IsEof)
                throw new InvalidOperationException("Operation is not allowed on a code point representing EOF.");
            #endregion

            return unchecked(left.Value - right.Value);
        }
        #endregion

        /// <summary>
        /// Returns this code point as one or two characters.
        /// When the code points must be represented as a surrogate pair,
        /// this method returns the surrogate pair.
        /// </summary>
        /// <returns>The character representation of this code point,
        /// or the surrogate pair.</returns>
        private Tuple<Char, Char?> ToChars()
        {
            if (this.IsEof)
            {
                throw new InvalidOperationException("Operation is not allowed on a code point representing EOF.");
            }
            else if (MinSurrogate <= this.value && this.value <= MaxSurrogate)
            {
                // Surrogate pair.
                // Return high surrogate.
                char c0 = (char)(0xD800 | ((this.value - 0x10000) >> 10));     // Low surrogate
                char c1 = (char)(0xDC00 | ((this.value - 0x10000) & 0x3FF));   // High surrogate
                return Tuple.Create(c0, (char?)c1);
            }
            else
            {
                Debug.Assert(this.value <= Char.MaxValue);
                char c = (char)this.value;
                return Tuple.Create(c, (char?)null);
            }
        }

        /// <summary>
        /// Determines whether the category of this code point is one of the specified categories.
        /// </summary>
        /// <param name="categories">The categories to test.</param>
        /// <returns><see langword="true"/> when this category is one of the specified categories;
        /// otherwise, <see langword="false"/>.</returns>
        private bool IsCategory(params UnicodeCategory[] categories)
        {
            var category = this.Category;
            foreach (var c in categories)
            {
                if (c == category) return true;
            }

            return false;
        }

        /// <inheritdoc />
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (this.IsEof) return "EOF";
            switch (format)
            {
                case null:
                case "G":
                    return Char.ConvertFromUtf32(this.Value);
                default:
                    return this.Value.ToString(format, formatProvider);
            }
        }

        /// <summary>
        /// Formats the value of the current instance using the specified format provider.
        /// </summary>
        /// <param name="formatProvider">The provider to use to format the value;
        /// or <see langword="null"/> to use the current culture.</param>
        /// <returns>The value of the current instance in the specified format.</returns>
        public string ToString(IFormatProvider formatProvider)
        {
            return ToString(null, formatProvider);
        }

        /// <summary>
        /// Formats the value of the current instance using the specified format.
        /// </summary>
        /// <param name="format">The format to use; or <see langword="null"/> to use
        /// the default format defined for the type of the System.IFormattable implementation.</param>
        /// <returns>The value of the current instance in the specified format.</returns>
        public string ToString(string format)
        {
            return ToString(format, CultureInfo.CurrentCulture);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return ToString(null, CultureInfo.CurrentCulture);
        }
    }
}
