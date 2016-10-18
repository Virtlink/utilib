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
		/// Unit tests for the <see cref="IsPowerOfTwoOrZero"/> functions.
		/// </summary>
		[TestFixture]
		public sealed class IsPowerOfTwoOrZeroTests
		{
			[TestCase(Int32.MinValue, ExpectedResult = false)]
			[TestCase((int)-1, ExpectedResult = false)]
			[TestCase((int)0, ExpectedResult = true)]
			[TestCase((int)1, ExpectedResult = true)]
			[TestCase((int)2, ExpectedResult = true)]
			[TestCase((int)3, ExpectedResult = false)]
			[TestCase((int)4, ExpectedResult = true)]
			[TestCase((int)15, ExpectedResult = false)]
			[TestCase((int)16, ExpectedResult = true)]
			[TestCase((int)17, ExpectedResult = false)]
			[TestCase((int)0x40000000, ExpectedResult = true)]
			[TestCase(Int32.MaxValue, ExpectedResult = false)]
			public bool OnInt32(int input)
			{
				return BinaryMath.IsPowerOfTwoOrZero(input);
			}

			[TestCase(UInt32.MinValue, ExpectedResult = true)]
			[TestCase((uint)0, ExpectedResult = true)]
			[TestCase((uint)1, ExpectedResult = true)]
			[TestCase((uint)2, ExpectedResult = true)]
			[TestCase((uint)3, ExpectedResult = false)]
			[TestCase((uint)4, ExpectedResult = true)]
			[TestCase((uint)15, ExpectedResult = false)]
			[TestCase((uint)16, ExpectedResult = true)]
			[TestCase((uint)17, ExpectedResult = false)]
			[TestCase((uint)0x40000000, ExpectedResult = true)]
			[TestCase(UInt32.MaxValue, ExpectedResult = false)]
			public bool OnUInt32(uint input)
			{
				return BinaryMath.IsPowerOfTwoOrZero(input);
			}

			[TestCase(Int64.MinValue, ExpectedResult = false)]
			[TestCase((long)-1, ExpectedResult = false)]
			[TestCase((long)0, ExpectedResult = true)]
			[TestCase((long)1, ExpectedResult = true)]
			[TestCase((long)2, ExpectedResult = true)]
			[TestCase((long)3, ExpectedResult = false)]
			[TestCase((long)4, ExpectedResult = true)]
			[TestCase((long)15, ExpectedResult = false)]
			[TestCase((long)16, ExpectedResult = true)]
			[TestCase((long)17, ExpectedResult = false)]
			[TestCase((long)0x4000000000000000, ExpectedResult = true)]
			[TestCase(Int64.MaxValue, ExpectedResult = false)]
			public bool OnInt64(long input)
			{
				return BinaryMath.IsPowerOfTwoOrZero(input);
			}

			[TestCase(UInt64.MinValue, ExpectedResult = true)]
			[TestCase((ulong)0, ExpectedResult = true)]
			[TestCase((ulong)1, ExpectedResult = true)]
			[TestCase((ulong)2, ExpectedResult = true)]
			[TestCase((ulong)3, ExpectedResult = false)]
			[TestCase((ulong)4, ExpectedResult = true)]
			[TestCase((ulong)15, ExpectedResult = false)]
			[TestCase((ulong)16, ExpectedResult = true)]
			[TestCase((ulong)17, ExpectedResult = false)]
			[TestCase((ulong)0x4000000000000000, ExpectedResult = true)]
			[TestCase(UInt32.MaxValue, ExpectedResult = false)]
			public bool OnUInt64(ulong input)
			{
				return BinaryMath.IsPowerOfTwoOrZero(input);
			}
		}

	}
}
