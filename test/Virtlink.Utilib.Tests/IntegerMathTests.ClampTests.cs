using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib
{
	partial class IntegerMathTests
	{
		/// <summary>
		/// Unit tests for the <see cref="Clamp"/> functions.
		/// </summary>
		[TestFixture]
		public sealed class ClampTests
		{
			[TestCase(Int32.MinValue, Int32.MinValue, Int32.MaxValue, ExpectedResult = Int32.MinValue)]
			[TestCase((int)-20, (int)-30, (int)10, ExpectedResult = (int)-20)]
			[TestCase((int)-20, (int)0, (int)0, ExpectedResult = (int)0)]
			[TestCase((int)0, (int)0, (int)0, ExpectedResult = (int)0)]
			[TestCase((int)20, (int)0, (int)0, ExpectedResult = (int)0)]
			[TestCase((int)20, (int)-30, (int)10, ExpectedResult = (int)10)]
			[TestCase(Int32.MaxValue, Int32.MinValue, Int32.MaxValue, ExpectedResult = Int32.MaxValue)]
			public int OnInt32(int value, int lowerBound, int upperBound)
			{
				return IntegerMath.Clamp(value, lowerBound, upperBound);
			}

			[Test]
			public void OnInt32_ThrowsWhenLowerBoundIsGreaterThanUpperBound()
			{
				// Act/Assert
				Assert.That(() =>
				{
					IntegerMath.Clamp((int)20, (int)20, (int)0);
				}, Throws.InstanceOf<ArgumentOutOfRangeException>());
			}

			[TestCase(Int64.MinValue, Int64.MinValue, Int64.MaxValue, ExpectedResult = Int64.MinValue)]
			[TestCase((long)-20, (long)-30, (long)10, ExpectedResult = (long)-20)]
			[TestCase((long)-20, (long)0, (long)0, ExpectedResult = (long)0)]
			[TestCase((long)0, (long)0, (long)0, ExpectedResult = (long)0)]
			[TestCase((long)20, (long)0, (long)0, ExpectedResult = (long)0)]
			[TestCase((long)20, (long)-30, (long)10, ExpectedResult = (long)10)]
			[TestCase(Int64.MaxValue, Int64.MinValue, Int64.MaxValue, ExpectedResult = Int64.MaxValue)]
			public long OnInt64(long value, long lowerBound, long upperBound)
			{
				return IntegerMath.Clamp(value, lowerBound, upperBound);
			}

			[Test]
			public void OnInt64_ThrowsWhenLowerBoundIsGreaterThanUpperBound()
			{
				// Act/Assert
				Assert.That(() =>
				{
					IntegerMath.Clamp((long)20, (long)20, (long)0);
				}, Throws.InstanceOf<ArgumentOutOfRangeException>());
			}
			
			[TestCase((uint)0, (uint)0, (uint)0, ExpectedResult = (uint)0)]
			[TestCase((uint)20, (uint)0, (uint)0, ExpectedResult = (uint)0)]
			[TestCase((uint)20, (uint)0, (uint)10, ExpectedResult = (uint)10)]
			[TestCase(UInt32.MaxValue, UInt32.MinValue, UInt32.MaxValue, ExpectedResult = UInt32.MaxValue)]
			public uint OnUInt32(uint value, uint lowerBound, uint upperBound)
			{
				return IntegerMath.Clamp(value, lowerBound, upperBound);
			}

			[Test]
			public void OnUInt32_ThrowsWhenLowerBoundIsGreaterThanUpperBound()
			{
				// Act/Assert
				Assert.That(() =>
				{
					IntegerMath.Clamp((uint)20, (uint)20, (uint)0);
				}, Throws.InstanceOf<ArgumentOutOfRangeException>());
			}
			
			[TestCase((ulong)0, (ulong)0, (ulong)0, ExpectedResult = (ulong)0)]
			[TestCase((ulong)20, (ulong)0, (ulong)0, ExpectedResult = (ulong)0)]
			[TestCase((ulong)20, (ulong)0, (ulong)10, ExpectedResult = (ulong)10)]
			[TestCase(UInt64.MaxValue, UInt64.MinValue, UInt64.MaxValue, ExpectedResult = UInt64.MaxValue)]
			public ulong OnUInt64(ulong value, ulong lowerBound, ulong upperBound)
			{
				return IntegerMath.Clamp(value, lowerBound, upperBound);
			}

			[Test]
			public void OnUInt64_ThrowsWhenLowerBoundIsGreaterThanUpperBound()
			{
				// Act/Assert
				Assert.That(() =>
				{
					IntegerMath.Clamp((ulong)20, (ulong)20, (ulong)0);
				}, Throws.InstanceOf<ArgumentOutOfRangeException>());
			}
		}
	}
}
