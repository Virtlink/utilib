using Xunit;

namespace Virtlink.Utilib.Text
{
	partial class UriEncodingTests
	{
		/// <summary>
		/// Tests the <see cref="UriEncoding.Encode"/> method.
		/// </summary>
		public class EncodeTests : UriEncodingTests
		{
			// NOTE: We assume percent encoded characters are written in uppercase ("%2F" and not "%2f").
			
			[Fact]
			public void ShouldEncodeExtendedAscii()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "ë";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.Equal("%C3%AB", encoded);		// U+EB
			}

			[Fact]
			public void ShouldEncodeUtf16()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "Ƶ";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.Equal("%C6%B5", encoded);     // U+1B5
			}

			[Fact]
			public void ShouldEncodeUtf32()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "😀";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.Equal("%F0%9F%98%80", encoded);		// U+1F600
			}
		}
	}
}
