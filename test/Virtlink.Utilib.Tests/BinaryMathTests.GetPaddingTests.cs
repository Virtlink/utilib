using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtlink.Utilib
{
	partial class BinaryMathTests
	{
		/// <summary>
		/// Unit tests for the <see cref="GetPadding"/> functions.
		/// </summary>
		[TestFixture]
		public sealed class GetPaddingTests
		{
			[TestCase((int)0, 1, ExpectedResult = (int)0)]
			[TestCase((int)13, 1, ExpectedResult = (int)0)]
			[TestCase((int)-7, 1, ExpectedResult = (int)0)]
			[TestCase((int)4, 1, ExpectedResult = (int)0)]
			[TestCase((int)13, 4, ExpectedResult = (int)3)]
			[TestCase((int)16, 4, ExpectedResult = (int)0)]
			[TestCase((int)-7, 4, ExpectedResult = (int)3)]
			[TestCase((int)-16, 4, ExpectedResult = (int)0)]
			[TestCase((int)0, 7, ExpectedResult = (int)0)]
			[TestCase((int)13, 7, ExpectedResult = (int)1)]
			[TestCase((int)16, 7, ExpectedResult = (int)5)]
			[TestCase((int)-7, 7, ExpectedResult = (int)0)]
			[TestCase((int)-16, 7, ExpectedResult = (int)2)]
			[TestCase(Int32.MinValue, 1, ExpectedResult = (int)0)]
			[TestCase(Int32.MinValue, 7, ExpectedResult = (int)2)]
			[TestCase(Int32.MinValue, 16, ExpectedResult = (int)0)]
			[TestCase(Int32.MaxValue, 1, ExpectedResult = (int)0)]
			[TestCase(Int32.MaxValue, 7, ExpectedResult = (int)6)]
			[TestCase(Int32.MaxValue, 16, ExpectedResult = (int)1)]
			public int OnInt32(int offset, int boundary)
			{
				return BinaryMath.GetPadding(offset, boundary);
			}
			
			[TestCase((uint)0, 1, ExpectedResult = (uint)0)]
			[TestCase((uint)13, 1, ExpectedResult = (uint)0)]
			[TestCase((uint)4, 1, ExpectedResult = (uint)0)]
			[TestCase((uint)13, 4, ExpectedResult = (uint)3)]
			[TestCase((uint)16, 4, ExpectedResult = (uint)0)]
			[TestCase((uint)0, 7, ExpectedResult = (uint)0)]
			[TestCase((uint)13, 7, ExpectedResult = (uint)1)]
			[TestCase((uint)16, 7, ExpectedResult = (uint)5)]
			[TestCase(UInt32.MinValue, 1, ExpectedResult = (uint)0)]
			[TestCase(UInt32.MinValue, 7, ExpectedResult = (uint)0)]
			[TestCase(UInt32.MinValue, 16, ExpectedResult = (uint)0)]
			[TestCase(UInt32.MaxValue, 1, ExpectedResult = (uint)0)]
			[TestCase(UInt32.MaxValue, 7, ExpectedResult = (uint)4)]
			[TestCase(UInt32.MaxValue, 16, ExpectedResult = (uint)1)]
			public uint OnUInt32(uint offset, int boundary)
			{
				return BinaryMath.GetPadding(offset, boundary);
			}
			
			[TestCase((long)0, 1, ExpectedResult = (long)0)]
			[TestCase((long)13, 1, ExpectedResult = (long)0)]
			[TestCase((long)-7, 1, ExpectedResult = (long)0)]
			[TestCase((long)4, 1, ExpectedResult = (long)0)]
			[TestCase((long)13, 4, ExpectedResult = (long)3)]
			[TestCase((long)16, 4, ExpectedResult = (long)0)]
			[TestCase((long)-7, 4, ExpectedResult = (long)3)]
			[TestCase((long)-16, 4, ExpectedResult = (long)0)]
			[TestCase((long)0, 7, ExpectedResult = (long)0)]
			[TestCase((long)13, 7, ExpectedResult = (long)1)]
			[TestCase((long)16, 7, ExpectedResult = (long)5)]
			[TestCase((long)-7, 7, ExpectedResult = (long)0)]
			[TestCase((long)-16, 7, ExpectedResult = (long)2)]
			[TestCase(Int64.MinValue, 1, ExpectedResult = (long)0)]
			[TestCase(Int64.MinValue, 7, ExpectedResult = (long)1)]
			[TestCase(Int64.MinValue, 16, ExpectedResult = (long)0)]
			[TestCase(Int64.MaxValue, 1, ExpectedResult = (long)0)]
			[TestCase(Int64.MaxValue, 7, ExpectedResult = (long)0)]
			[TestCase(Int64.MaxValue, 16, ExpectedResult = (long)1)]
			public long OnInt64(long offset, int boundary)
			{
				return BinaryMath.GetPadding(offset, boundary);
			}
			
			[TestCase((ulong)0, 1, ExpectedResult = (ulong)0)]
			[TestCase((ulong)13, 1, ExpectedResult = (ulong)0)]
			[TestCase((ulong)4, 1, ExpectedResult = (ulong)0)]
			[TestCase((ulong)13, 4, ExpectedResult = (ulong)3)]
			[TestCase((ulong)16, 4, ExpectedResult = (ulong)0)]
			[TestCase((ulong)0, 7, ExpectedResult = (ulong)0)]
			[TestCase((ulong)13, 7, ExpectedResult = (ulong)1)]
			[TestCase((ulong)16, 7, ExpectedResult = (ulong)5)]
			[TestCase(UInt64.MinValue, 1, ExpectedResult = (ulong)0)]
			[TestCase(UInt64.MinValue, 7, ExpectedResult = (ulong)0)]
			[TestCase(UInt64.MinValue, 16, ExpectedResult = (ulong)0)]
			[TestCase(UInt64.MaxValue, 1, ExpectedResult = (ulong)0)]
			[TestCase(UInt64.MaxValue, 7, ExpectedResult = (ulong)6)]
			[TestCase(UInt64.MaxValue, 16, ExpectedResult = (ulong)1)]
			public ulong OnUInt64(ulong offset, int boundary)
			{
				return BinaryMath.GetPadding(offset, boundary);
			}
		}

	}
}
