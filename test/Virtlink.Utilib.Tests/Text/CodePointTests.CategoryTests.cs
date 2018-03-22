using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using Xunit;

namespace Virtlink.Utilib.Text
{
    partial class CodePointTests
    {
        /// <summary>
        /// Tests the <see cref="CodePoint.Category"/> property.
        /// </summary>
        public sealed class CategoryTests
        {
            public static IEnumerable<object[]> CategoriesOfCodePoints => new List<object[]>
            {
                new object[] { new CodePoint('\u0095'), UnicodeCategory.Control },                 // [Cc] Other, Control
                new object[] { new CodePoint('\u0600'), UnicodeCategory.Format },                  // [Cf] Other, Format
                new object[] { new CodePoint('\uD800'), UnicodeCategory.Surrogate },               // [Cs] Other, Surrogate
                new object[] { new CodePoint('ø'),      UnicodeCategory.LowercaseLetter },         // [Ll] Letter, Lowercase
                new object[] { new CodePoint('ʺ'),      UnicodeCategory.ModifierLetter },          // [Lm] Letter, Modifier
                new object[] { new CodePoint('א'),      UnicodeCategory.OtherLetter },             // [Lo] Letter, Other
                new object[] { new CodePoint('ǅ'),      UnicodeCategory.TitlecaseLetter },         // [Lt] Letter, Titlecase
                new object[] { new CodePoint('Ø'),      UnicodeCategory.UppercaseLetter },         // [Lu] Letter, Uppercase
                new object[] { new CodePoint('\u0903'), UnicodeCategory.SpacingCombiningMark },    // [Mc] Mark, Spacing Combining
                new object[] { new CodePoint('\u20DE'), UnicodeCategory.EnclosingMark },           // [Me] Mark, Enclosing
                new object[] { new CodePoint('\u030C'), UnicodeCategory.NonSpacingMark },          // [Mn] Mark, Nonspacing
                new object[] { new CodePoint('٧'),      UnicodeCategory.DecimalDigitNumber },      // [Nd] Number, Decimal Digit
                new object[] { new CodePoint('Ⅳ'),      UnicodeCategory.LetterNumber },           // [Nl] Number, Letter
                new object[] { new CodePoint('½'),      UnicodeCategory.OtherNumber },             // [No] Number, Other
                new object[] { new CodePoint('⁀'),      UnicodeCategory.ConnectorPunctuation },    // [Pc] Punctuation, Connector
                new object[] { new CodePoint('⸗'),      UnicodeCategory.DashPunctuation },         // [Pd] Punctuation, Dash
                new object[] { new CodePoint(']'),      UnicodeCategory.ClosePunctuation },        // [Pe] Punctuation, Close
                new object[] { new CodePoint('»'),      UnicodeCategory.FinalQuotePunctuation },   // [Pf] Punctuation, Final quote
                new object[] { new CodePoint('«'),      UnicodeCategory.InitialQuotePunctuation }, // [Pi] Punctuation, Initial quote
                new object[] { new CodePoint('¶'),      UnicodeCategory.OtherPunctuation },        // [Po] Punctuation, Other
                new object[] { new CodePoint('['),      UnicodeCategory.OpenPunctuation },         // [Ps] Punctuation, Open
                new object[] { new CodePoint('¥'),      UnicodeCategory.CurrencySymbol },          // [Sc] Symbol, Currency
                new object[] { new CodePoint('\u02DA'), UnicodeCategory.ModifierSymbol },          // [Sk] Symbol, Modifier
                new object[] { new CodePoint('±'),      UnicodeCategory.MathSymbol },              // [Sm] Symbol, Math
                new object[] { new CodePoint('☺'),      UnicodeCategory.OtherSymbol },             // [So] Symbol, Other
                new object[] { new CodePoint('\u2028'), UnicodeCategory.LineSeparator },           // [Zl] Separator, Line
                new object[] { new CodePoint('\u2029'), UnicodeCategory.ParagraphSeparator },      // [Zp] Separator, Paragraph
                new object[] { new CodePoint('\u2000'), UnicodeCategory.SpaceSeparator },          // [Zs] Separator, Space
                new object[] { new CodePoint('9'),      UnicodeCategory.DecimalDigitNumber },      // DIGIT NINE [Nd]
                new object[] { new CodePoint('r'),      UnicodeCategory.LowercaseLetter },         // LATIN SMALL LETTER R [Ll]
                new object[] { new CodePoint('R'),      UnicodeCategory.UppercaseLetter },         // LATIN CAPITAL LETTER R [Lu]
                new object[] { new CodePoint('\0'),     UnicodeCategory.Control },                 // NULL [Cc]
                new object[] { new CodePoint('\u0009'), UnicodeCategory.Control },                 // CHARACTER TABULATION [Cc]
                new object[] { new CodePoint('\u000A'), UnicodeCategory.Control },                 // LINE FEED (LF) [Cc]
                new object[] { new CodePoint('\u000B'), UnicodeCategory.Control },                 // LINE TABULATION [Cc]
                new object[] { new CodePoint('\u000C'), UnicodeCategory.Control },                 // FORM FEED (FF) [Cc]
                new object[] { new CodePoint('\u000D'), UnicodeCategory.Control },                 // CARRIAGE RETURN (CR) [Cc]
                new object[] { new CodePoint('\u0020'), UnicodeCategory.SpaceSeparator },          // SPACE [Zs]
                new object[] { new CodePoint('\u0085'), UnicodeCategory.Control },                 // NEXT LINE (NEL) [Cc]
                new object[] { new CodePoint('\u00A0'), UnicodeCategory.SpaceSeparator },          // NO-BREAK SPACE [Zs]
            };

            [Theory]
            [MemberData(nameof(CategoriesOfCodePoints))]
            public void ShouldReturnExpectedCategory_ForCodePoint(CodePoint codepoint, UnicodeCategory expected)
            {
                // Act
                var result = codepoint.Category;

                // Assert
                Assert.Equal(expected, result);
            }

            [Fact]
            public void ShouldReturnCategoryOfSingleCharacter()
            {
                // Arrange
                int value = 0x263A;         // ☺
                var instance = new CodePoint(value);

                // Act
                var result = instance.Category;

                // Assert
                Assert.Equal(UnicodeCategory.OtherSymbol, result);
            }

            [Fact]
            public void ShouldReturnCategoryOfSurrogateCharacter()
            {
                // Arrange
                int value = 0x1F44D;        // 👍
                var instance = new CodePoint(value);

                // Act
                var result = instance.Category;

                // Assert
                Assert.Equal(UnicodeCategory.OtherSymbol, result);
            }

            [Fact]
            public void ShouldThrow_WhenCodePointIsEof()
            {
                // Arrange
                var instance = CodePoint.Eof;

                // Act
                var exception = Record.Exception(() =>
                {
                    // ReSharper disable once UnusedVariable
                    var result = instance.Category;
                });

                // Assert
                Assert.IsAssignableFrom<InvalidOperationException>(exception);
            }
        }
    }
}
