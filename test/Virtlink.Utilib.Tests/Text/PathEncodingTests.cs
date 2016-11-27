namespace Virtlink.Utilib.Text
{
	/// <summary>
	/// Tests the <see cref="PathEncoding"/> class.
	/// </summary>
	public abstract partial class PathEncodingTests
	{
		/// <summary>
		/// Creates a new instance of the subject under test (SUT).
		/// </summary>
		/// <returns>The created instance.</returns>
		protected virtual PathEncoding CreateNew()
		{
			return new PathEncoding();
		}
	}
}
