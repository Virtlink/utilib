using NUnit.Framework;

namespace Virtlink.Utilib.Text
{
	partial class PathEncodingTests
	{
		/// <summary>
		/// Tests the <see cref="PathEncoding.Encode"/> method.
		/// </summary>
		[TestFixture]
		public class EncodeTests : PathEncodingTests
		{
			// NOTE: We assume percent encoded characters are written in uppercase ("%2F" and not "%2f").

			[Test]
			public void DoesNotEncodeNormalCharacters()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "abcdefABCDEF";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.That(encoded, Is.EqualTo(unencoded));
			}

			[Test]
			public void EncodesControlCharacters()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "\0";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.That(encoded, Is.EqualTo("%00"));        // U+00
			}

			[Test]
			public void EncodesExclamationMark()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "!";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.That(encoded, Is.EqualTo("%21"));        // U+21
			}

			[Test]
			public void EncodesPercent()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "%";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.That(encoded, Is.EqualTo("%25"));        // U+25
			}

			[Test]
			public void EncodesForwardSlash()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "/";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.That(encoded, Is.EqualTo("%2F"));        // U+2F
			}
			
		}
	}
}
