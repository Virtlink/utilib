using NUnit.Framework;

namespace Virtlink.Utilib.Text
{
	partial class UriEncodingTests
	{
		/// <summary>
		/// Tests the <see cref="UriEncoding.Encode"/> method.
		/// </summary>
		[TestFixture]
		public class EncodeTests : UriEncodingTests
		{
			// NOTE: We assume percent encoded characters are written in uppercase ("%2F" and not "%2f").
			
			[Test]
			public void EncodesExtendedAscii()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "ë";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.That(encoded, Is.EqualTo("%C3%AB"));		// U+EB
			}

			[Test]
			public void EncodesUtf16()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "Ƶ";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.That(encoded, Is.EqualTo("%C6%B5"));     // U+1B5
			}

			[Test]
			public void EncodesUtf32()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "😀";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.That(encoded, Is.EqualTo("%F0%9F%98%80"));		// U+1F600
			}
		}
	}
}
