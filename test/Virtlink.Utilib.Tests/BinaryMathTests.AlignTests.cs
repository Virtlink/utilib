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
		/// Unit tests for the <see cref="Align"/> functions.
		/// </summary>
		[TestFixture]
		public sealed class AlignTests
		{
			[TestCase((int)0, 1, ExpectedResult = (int)0)]
			[TestCase((int)13, 1, ExpectedResult = (int)13)]
			[TestCase((int)-7, 1, ExpectedResult = (int)-7)]
			[TestCase((int)4, 1, ExpectedResult = (int)4)]
			[TestCase((int)13, 4, ExpectedResult = (int)16)]
			[TestCase((int)16, 4, ExpectedResult = (int)16)]
			[TestCase((int)-7, 4, ExpectedResult = (int)-4)]
			[TestCase((int)-16, 4, ExpectedResult = (int)-16)]
			[TestCase((int)0, 7, ExpectedResult = (int)0)]
			[TestCase((int)13, 7, ExpectedResult = (int)14)]
			[TestCase((int)16, 7, ExpectedResult = (int)21)]
			[TestCase((int)-7, 7, ExpectedResult = (int)-7)]
			[TestCase((int)-16, 7, ExpectedResult = (int)-14)]
			[TestCase(Int32.MinValue, 1, ExpectedResult = Int32.MinValue)]
			[TestCase(Int32.MinValue, 7, ExpectedResult = Int32.MinValue + 2)]
			[TestCase(Int32.MinValue, 16, ExpectedResult = Int32.MinValue)]
			[TestCase(Int32.MaxValue, 1, ExpectedResult = Int32.MaxValue)]
			public int OnInt32(int offset, int boundary)
			{
				return BinaryMath.Align(offset, boundary);
			}

			[Test]
			public void OnInt32_ThrowsOnOverflow()
			{
				// Act/Assert
				Assert.That(() =>
				{
					BinaryMath.Align(Int32.MaxValue, 7);
				}, Throws.InstanceOf<OverflowException>());
			}

			[TestCase((uint)0, 1, ExpectedResult = (uint)0)]
			[TestCase((uint)13, 1, ExpectedResult = (uint)13)]
			[TestCase((uint)4, 1, ExpectedResult = (uint)4)]
			[TestCase((uint)13, 4, ExpectedResult = (uint)16)]
			[TestCase((uint)16, 4, ExpectedResult = (uint)16)]
			[TestCase((uint)0, 7, ExpectedResult = (uint)0)]
			[TestCase((uint)13, 7, ExpectedResult = (uint)14)]
			[TestCase((uint)16, 7, ExpectedResult = (uint)21)]
			[TestCase(UInt32.MaxValue, 1, ExpectedResult = UInt32.MaxValue)]
			public uint OnUInt32(uint offset, int boundary)
			{
				return BinaryMath.Align(offset, boundary);
			}

			[Test]
			public void OnUInt32_ThrowsOnOverflow()
			{
				// Act/Assert
				Assert.That(() =>
				{
					BinaryMath.Align(UInt32.MaxValue, 7);
				}, Throws.InstanceOf<OverflowException>());
			}

			[TestCase((long)0, 1, ExpectedResult = (long)0)]
			[TestCase((long)13, 1, ExpectedResult = (long)13)]
			[TestCase((long)-7, 1, ExpectedResult = (long)-7)]
			[TestCase((long)4, 1, ExpectedResult = (long)4)]
			[TestCase((long)13, 4, ExpectedResult = (long)16)]
			[TestCase((long)16, 4, ExpectedResult = (long)16)]
			[TestCase((long)-7, 4, ExpectedResult = (long)-4)]
			[TestCase((long)-16, 4, ExpectedResult = (long)-16)]
			[TestCase((long)0, 7, ExpectedResult = (long)0)]
			[TestCase((long)13, 7, ExpectedResult = (long)14)]
			[TestCase((long)16, 7, ExpectedResult = (long)21)]
			[TestCase((long)-7, 7, ExpectedResult = (long)-7)]
			[TestCase((long)-16, 7, ExpectedResult = (long)-14)]
			[TestCase(Int64.MinValue, 1, ExpectedResult = Int64.MinValue)]
			[TestCase(Int64.MinValue, 7, ExpectedResult = Int64.MinValue + 1)]
			[TestCase(Int64.MinValue, 16, ExpectedResult = Int64.MinValue)]
			[TestCase(Int64.MaxValue, 1, ExpectedResult = Int64.MaxValue)]
			public long OnInt64(long offset, int boundary)
			{
				return BinaryMath.Align(offset, boundary);
			}

			[Test]
			public void OnInt64_ThrowsOnOverflow()
			{
				// Act/Assert
				Assert.That(() =>
				{
					BinaryMath.Align(Int64.MaxValue, 17);
				}, Throws.InstanceOf<OverflowException>());
			}

			[TestCase((ulong)0, 1, ExpectedResult = (ulong)0)]
			[TestCase((ulong)13, 1, ExpectedResult = (ulong)13)]
			[TestCase((ulong)4, 1, ExpectedResult = (ulong)4)]
			[TestCase((ulong)13, 4, ExpectedResult = (ulong)16)]
			[TestCase((ulong)16, 4, ExpectedResult = (ulong)16)]
			[TestCase((ulong)0, 7, ExpectedResult = (ulong)0)]
			[TestCase((ulong)13, 7, ExpectedResult = (ulong)14)]
			[TestCase((ulong)16, 7, ExpectedResult = (ulong)21)]
			[TestCase(UInt64.MaxValue, 1, ExpectedResult = UInt64.MaxValue)]
			public ulong OnUInt64(ulong offset, int boundary)
			{
				return BinaryMath.Align(offset, boundary);
			}

			[Test]
			public void OnUInt64_ThrowsOnOverflow()
			{
				// Act/Assert
				Assert.That(() =>
				{
					BinaryMath.Align(UInt64.MaxValue, 7);
				}, Throws.InstanceOf<OverflowException>());
			}
		}
	}
}
