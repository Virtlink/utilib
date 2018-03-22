using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Xunit;

namespace Virtlink.Utilib.Text
{
    partial class CodePointTests
    {
        /// <summary>
        /// Tests the <see cref="CodePoint.IsControl"/> property.
        /// </summary>
        public sealed class IsControlTests
        {
            public static IEnumerable<object[]> Valid => new List<object[]>
            {
                new object[] { new CodePoint('\u0095') },   // [Cc] Other, Control
                new object[] { new CodePoint('\0') },       // NULL [Cc]
                new object[] { new CodePoint('\u0009') },   // CHARACTER TABULATION [Cc]
                new object[] { new CodePoint('\u000A') },   // LINE FEED (LF) [Cc]
                new object[] { new CodePoint('\u000B') },   // LINE TABULATION [Cc]
                new object[] { new CodePoint('\u000C') },   // FORM FEED (FF) [Cc]
                new object[] { new CodePoint('\u000D') },   // CARRIAGE RETURN (CR) [Cc]
                new object[] { new CodePoint('\u0085') },   // NEXT LINE (NEL) [Cc]
            };

            [Theory]
            [MemberData(nameof(Valid))]
            public void ShouldReturnTrue_WhenCodepointIsControl(CodePoint codepoint)
            {
                // Act
                var result = codepoint.IsControl;

                // Assert
                Assert.True(result);
            }

            public static IEnumerable<object[]> Invalid => new List<object[]>
            {
                new object[] { CodePoint.Eof },
                new object[] { new CodePoint('\u0600') },   // [Cf] Other, Format
                new object[] { new CodePoint('\uD800') },   // [Cs] Other, Surrogate
                new object[] { new CodePoint('ø') },        // [Ll] Letter, Lowercase
                new object[] { new CodePoint('ʺ') },        // [Lm] Letter, Modifier
                new object[] { new CodePoint('א') },        // [Lo] Letter, Other
                new object[] { new CodePoint('ǅ') },        // [Lt] Letter, Titlecase
                new object[] { new CodePoint('Ø') },        // [Lu] Letter, Uppercase
                new object[] { new CodePoint('\u0903') },   // [Mc] Mark, Spacing Combining
                new object[] { new CodePoint('\u20DE') },   // [Me] Mark, Enclosing
                new object[] { new CodePoint('\u030C') },   // [Mn] Mark, Nonspacing
                new object[] { new CodePoint('٧') },        // [Nd] Number, Decimal Digit
                new object[] { new CodePoint('Ⅳ') },        // [Nl] Number, Letter
                new object[] { new CodePoint('½') },        // [No] Number, Other
                new object[] { new CodePoint('⁀') },        // [Pc] Punctuation, Connector
                new object[] { new CodePoint('⸗') },        // [Pd] Punctuation, Dash
                new object[] { new CodePoint(']') },        // [Pe] Punctuation, Close
                new object[] { new CodePoint('»') },        // [Pf] Punctuation, Final quote
                new object[] { new CodePoint('«') },        // [Pi] Punctuation, Initial quote
                new object[] { new CodePoint('¶') },        // [Po] Punctuation, Other
                new object[] { new CodePoint('[') },        // [Ps] Punctuation, Open
                new object[] { new CodePoint('¥') },        // [Sc] Symbol, Currency
                new object[] { new CodePoint('\u02DA') },   // [Sk] Symbol, Modifier
                new object[] { new CodePoint('±') },        // [Sm] Symbol, Math
                new object[] { new CodePoint('☺') },        // [So] Symbol, Other
                new object[] { new CodePoint('\u2028') },   // [Zl] Separator, Line
                new object[] { new CodePoint('\u2029') },   // [Zp] Separator, Paragraph
                new object[] { new CodePoint('\u2000') },   // [Zs] Separator, Space
                new object[] { new CodePoint('9') },        // DIGIT NINE [Nd]
                new object[] { new CodePoint('r') },        // LATIN SMALL LETTER R [Ll]
                new object[] { new CodePoint('R') },        // LATIN CAPITAL LETTER R [Lu]
                new object[] { new CodePoint('\u0020') },   // SPACE [Zs]
                new object[] { new CodePoint('\u00A0') },   // NO-BREAK SPACE [Zs]
            };

            [Theory]
            [MemberData(nameof(Invalid))]
            public void ShouldReturnFalse_WhenCodepointNotIsControl(CodePoint codepoint)
            {
                // Act
                var result = codepoint.IsControl;

                // Assert
                Assert.False(result);
            }

            [Fact]
            public void ShouldReturnFalse_WhenCodePointIsEof()
            {
                // Arrange
                var instance = CodePoint.Eof;

                // Act
                var result = instance.IsControl;

                // Assert
                Assert.False(result);
            }
        }
    }
}
