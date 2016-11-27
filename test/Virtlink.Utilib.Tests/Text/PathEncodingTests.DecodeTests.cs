using NUnit.Framework;

namespace Virtlink.Utilib.Text
{
	partial class PathEncodingTests
	{
		/// <summary>
		/// Tests the <see cref="PathEncoding.Decode"/> method.
		/// </summary>
		[TestFixture]
		public class DecodeTests : PathEncodingTests
		{

			[Test]
			public void DoesNotDecodeNormalCharacters()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "abcdefABCDEF";

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.That(unencoded, Is.EqualTo(encoded));
			}

			[Test]
			public void DecodesControlCharacters()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%00";							// U+00

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.That(unencoded, Is.EqualTo("\0"));
			}

			[Test]
			public void DecodesExclamationMark()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%21";							// U+21

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.That(unencoded, Is.EqualTo("!"));
			}

			[Test]
			public void DecodesPercent()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%25";							// U+25

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.That(unencoded, Is.EqualTo("%"));
			}

			[Test]
			public void DecodesForwardSlash()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%2F";							// U+2F

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.That(unencoded, Is.EqualTo("/"));
			}

			[Test]
			public void DecodesEncodedCharacterInTheMiddle()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "foo%2Fbar";

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.That(unencoded, Is.EqualTo("foo/bar"));
			}
			
		}
	}
}
