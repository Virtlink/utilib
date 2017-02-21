using Xunit;

namespace Virtlink.Utilib.Text
{
	partial class PathEncodingTests
	{
		/// <summary>
		/// Tests the <see cref="PathEncoding.Encode"/> method.
		/// </summary>
		public class EncodeTests : PathEncodingTests
		{
			[Fact]
			public void ShouldNotEncodeNormalCharacters()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "abcdefABCDEF";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.Equal(unencoded, encoded);
			}

			[Fact]
			public void ShouldEncodeControlCharacters()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "\0";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.Equal("%00", encoded.ToUpperInvariant());        // U+00
			}

			[Fact]
			public void ShouldEncodeExclamationMark()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "!";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.Equal("%21", encoded.ToUpperInvariant());        // U+21
			}

			[Fact]
			public void ShouldEncodePercent()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "%";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.Equal("%25", encoded.ToUpperInvariant());        // U+25
			}

			[Fact]
			public void ShouldEncodeForwardSlash()
			{
				// Arrange
				var encoding = CreateNew();
				string unencoded = "/";

				// Act
				string encoded = encoding.Encode(unencoded);

				// Assert
				Assert.Equal("%2F", encoded.ToUpperInvariant());        // U+2F
			}
			
		}
	}
}
