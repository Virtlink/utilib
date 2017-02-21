namespace Virtlink.Utilib.Text
{
	/// <summary>
	/// Tests the <see cref="UriEncoding"/> class.
	/// </summary>
	public abstract partial class UriEncodingTests
	{
		/// <summary>
		/// Creates a new instance of the subject under test (SUT).
		/// </summary>
		/// <returns>The created instance.</returns>
		protected virtual PathEncoding CreateNew()
		{
			return new UriEncoding();
		}
        
		public class EncodeTests2 : PathEncodingTests.EncodeTests
		{
			protected override PathEncoding CreateNew()
			{
				return new UriEncoding();
			}
		}
        
		public class DecodeTests2 : PathEncodingTests.DecodeTests
		{
			protected override PathEncoding CreateNew()
			{
				return new UriEncoding();
			}
		}
	}
}
