using NUnit.Framework;

namespace Virtlink.Utilib.Text
{
	partial class UriEncodingTests
	{
		/// <summary>
		/// Tests the <see cref="UriEncoding.Decode"/> method.
		/// </summary>
		[TestFixture]
		public class DecodeTests : UriEncodingTests
		{
			[Test]
			public void DecodesExtendedAscii()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%C3%AB";						// U+EB

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.That(unencoded, Is.EqualTo("ë"));
			}

			[Test]
			public void DecodesUtf16()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%C6%B5";						// U+1B5

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.That(unencoded, Is.EqualTo("Ƶ"));
			}

			[Test]
			public void DecodesUtf32()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%F0%9F%98%80";				// U+1F600

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.That(unencoded, Is.EqualTo("😀"));
			}
		}
	}
}
