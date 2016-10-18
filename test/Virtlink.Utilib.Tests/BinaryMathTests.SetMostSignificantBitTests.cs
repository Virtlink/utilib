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
		/// Unit tests for the <see cref="SetMostSignificantBit"/> functions.
		/// </summary>
		[TestFixture]
		public sealed class SetMostSignificantBitTests
		{
			[TestCase(0, ExpectedResult = 0)]
			[TestCase(1, ExpectedResult = 1)]
			[TestCase(2, ExpectedResult = 2)]
			[TestCase(3, ExpectedResult = 2)]
			[TestCase(4, ExpectedResult = 4)]
			[TestCase(15, ExpectedResult = 8)]
			[TestCase(16, ExpectedResult = 16)]
			[TestCase(17, ExpectedResult = 16)]
			[TestCase(0x40000000, ExpectedResult = 0x40000000)]
			public int OnInt32(int input)
			{
				return BinaryMath.SetMostSignificantBit(input);
			}
			
			[TestCase(0, ExpectedResult = 0)]
			[TestCase(1, ExpectedResult = 1)]
			[TestCase(2, ExpectedResult = 2)]
			[TestCase(3, ExpectedResult = 2)]
			[TestCase(4, ExpectedResult = 4)]
			[TestCase(15, ExpectedResult = 8)]
			[TestCase(16, ExpectedResult = 16)]
			[TestCase(17, ExpectedResult = 16)]
			[TestCase(0x4000000000000000, ExpectedResult = 0x4000000000000000)]
			public long OnInt64(long input)
			{
				return BinaryMath.SetMostSignificantBit(input);
			}
			
			[TestCase((uint)0, ExpectedResult = (uint)0)]
			[TestCase((uint)1, ExpectedResult = (uint)1)]
			[TestCase((uint)2, ExpectedResult = (uint)2)]
			[TestCase((uint)3, ExpectedResult = (uint)2)]
			[TestCase((uint)4, ExpectedResult = (uint)4)]
			[TestCase((uint)15, ExpectedResult = (uint)8)]
			[TestCase((uint)16, ExpectedResult = (uint)16)]
			[TestCase((uint)17, ExpectedResult = (uint)16)]
			[TestCase((uint)0x80000000, ExpectedResult = (uint)0x80000000)]
			public uint OnUInt32(uint input)
			{
				return BinaryMath.SetMostSignificantBit(input);
			}
			
			[TestCase((ulong)0, ExpectedResult = (ulong)0)]
			[TestCase((ulong)1, ExpectedResult = (ulong)1)]
			[TestCase((ulong)2, ExpectedResult = (ulong)2)]
			[TestCase((ulong)3, ExpectedResult = (ulong)2)]
			[TestCase((ulong)4, ExpectedResult = (ulong)4)]
			[TestCase((ulong)15, ExpectedResult = (ulong)8)]
			[TestCase((ulong)16, ExpectedResult = (ulong)16)]
			[TestCase((ulong)17, ExpectedResult = (ulong)16)]
			[TestCase((ulong)0x8000000000000000, ExpectedResult = (ulong)0x8000000000000000)]
			public ulong OnUInt64(ulong input)
			{
				return BinaryMath.SetMostSignificantBit(input);
			}
		}

	}
}
