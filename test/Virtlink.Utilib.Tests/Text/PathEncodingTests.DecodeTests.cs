using Xunit;

namespace Virtlink.Utilib.Text
{
	partial class PathEncodingTests
	{
		/// <summary>
		/// Tests the <see cref="PathEncoding.Decode"/> method.
		/// </summary>
		public class DecodeTests : PathEncodingTests
		{
			[Fact]
			public void ShouldNotDecodeNormalCharacters()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "abcdefABCDEF";

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.Equal(encoded, unencoded);
			}

			[Fact]
			public void ShouldDecodeControlCharacters()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%00";							// U+00

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.Equal("\0", unencoded);
			}

			[Fact]
			public void ShouldDecodeExclamationMark()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%21";							// U+21

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.Equal("!", unencoded);
			}

			[Fact]
			public void ShouldDecodePercent()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%25";							// U+25

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.Equal("%", unencoded);
			}

			[Fact]
			public void ShouldDecodeForwardSlash()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "%2F";							// U+2F

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.Equal("/", unencoded);
			}

			[Fact]
			public void ShouldDecodeEncodedCharacterInTheMiddle()
			{
				// Arrange
				var encoding = CreateNew();
				string encoded = "foo%2Fbar";

				// Act
				string unencoded = encoding.Decode(encoded);

				// Assert
				Assert.Equal("foo/bar", unencoded);
			}
			
		}
	}
}
