using Xunit;

namespace Virtlink.Utilib.Text
{
	partial class UriEncodingTests
	{
		/// <summary>
		/// Tests the <see cref="UriEncoding.Decode"/> method.
		/// </summary>
		public class DecodeTests : UriEncodingTests
		{
			[Fact]
			public void ShouldDecodeExtendedAscii()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%C3%AB";						// U+EB

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.Equal("ë", unencoded);
			}

			[Fact]
			public void ShouldDecodeUtf16()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%C6%B5";						// U+1B5

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.Equal("Ƶ", unencoded);
			}

			[Fact]
			public void ShouldDecodeUtf32()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%F0%9F%98%80";				// U+1F600

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.Equal("😀", unencoded);
			}
		}
	}
}
