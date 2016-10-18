using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Virtlink.Utilib
{
	partial class IntegerMathTests
	{
		[TestFixture]
		public sealed class ModuloTests
		{
			[TestCase(Int32.MinValue, (int)3, ExpectedResult = (int)1)]
			[TestCase((int)-17, (int)7, ExpectedResult = (int)4)]
			[TestCase((int)-16, (int)4, ExpectedResult = (int)0)]
			[TestCase((int)-15, (int)8, ExpectedResult = (int)1)]
			[TestCase((int)-4, (int)3, ExpectedResult = (int)2)]
			[TestCase((int)-3, (int)3, ExpectedResult = (int)0)]
			[TestCase((int)-2, (int)1, ExpectedResult = (int)0)]
			[TestCase((int)-1, (int)2, ExpectedResult = (int)1)]
			[TestCase((int)0, (int)1, ExpectedResult = (int)0)]
			[TestCase((int)1, (int)2, ExpectedResult = (int)1)]
			[TestCase((int)2, (int)1, ExpectedResult = (int)0)]
			[TestCase((int)3, (int)3, ExpectedResult = (int)0)]
			[TestCase((int)4, (int)3, ExpectedResult = (int)1)]
			[TestCase((int)15, (int)8, ExpectedResult = (int)7)]
			[TestCase((int)16, (int)4, ExpectedResult = (int)0)]
			[TestCase((int)17, (int)7, ExpectedResult = (int)3)]
			[TestCase(Int32.MaxValue, (int)3, ExpectedResult = (int)1)]
			[TestCase(Int32.MinValue, (int)-3, ExpectedResult = (int)1)]
			[TestCase((int)-17, (int)-7, ExpectedResult = (int)4)]
			[TestCase((int)-16, (int)-4, ExpectedResult = (int)0)]
			[TestCase((int)-15, (int)-8, ExpectedResult = (int)1)]
			[TestCase((int)-4, (int)-3, ExpectedResult = (int)2)]
			[TestCase((int)-3, (int)-3, ExpectedResult = (int)0)]
			[TestCase((int)-2, (int)-1, ExpectedResult = (int)0)]
			[TestCase((int)-1, (int)-2, ExpectedResult = (int)1)]
			[TestCase((int)0, (int)-1, ExpectedResult = (int)0)]
			[TestCase((int)1, (int)-2, ExpectedResult = (int)1)]
			[TestCase((int)2, (int)-1, ExpectedResult = (int)0)]
			[TestCase((int)3, (int)-3, ExpectedResult = (int)0)]
			[TestCase((int)4, (int)-3, ExpectedResult = (int)1)]
			[TestCase((int)15, (int)-8, ExpectedResult = (int)7)]
			[TestCase((int)16, (int)-4, ExpectedResult = (int)0)]
			[TestCase((int)17, (int)-7, ExpectedResult = (int)3)]
			[TestCase(Int32.MaxValue, -3, ExpectedResult = (int)1)]
			public int OnInt32(int dividend, int divisor)
			{
				return IntegerMath.Modulo(dividend, divisor);
			}

			[Test]
			public void OnInt32_ThrowsWhenDivisorIsZero()
			{
				// Act/Assert
				Assert.That(() =>
				{
					IntegerMath.Modulo((int)10, (int)0);
				}, Throws.InstanceOf<DivideByZeroException>());
			}

			[TestCase(Int64.MinValue, (long)3, ExpectedResult = (long)1)]
			[TestCase((long)-17, (long)7, ExpectedResult = (long)4)]
			[TestCase((long)-16, (long)4, ExpectedResult = (long)0)]
			[TestCase((long)-15, (long)8, ExpectedResult = (long)1)]
			[TestCase((long)-4, (long)3, ExpectedResult = (long)2)]
			[TestCase((long)-3, (long)3, ExpectedResult = (long)0)]
			[TestCase((long)-2, (long)1, ExpectedResult = (long)0)]
			[TestCase((long)-1, (long)2, ExpectedResult = (long)1)]
			[TestCase((long)0, (long)1, ExpectedResult = (long)0)]
			[TestCase((long)1, (long)2, ExpectedResult = (long)1)]
			[TestCase((long)2, (long)1, ExpectedResult = (long)0)]
			[TestCase((long)3, (long)3, ExpectedResult = (long)0)]
			[TestCase((long)4, (long)3, ExpectedResult = (long)1)]
			[TestCase((long)15, (long)8, ExpectedResult = (long)7)]
			[TestCase((long)16, (long)4, ExpectedResult = (long)0)]
			[TestCase((long)17, (long)7, ExpectedResult = (long)3)]
			[TestCase(Int64.MaxValue, (long)3, ExpectedResult = (long)1)]
			[TestCase(Int64.MinValue, (long)-3, ExpectedResult = (long)1)]
			[TestCase((long)-17, (long)-7, ExpectedResult = (long)4)]
			[TestCase((long)-16, (long)-4, ExpectedResult = (long)0)]
			[TestCase((long)-15, (long)-8, ExpectedResult = (long)1)]
			[TestCase((long)-4, (long)-3, ExpectedResult = (long)2)]
			[TestCase((long)-3, (long)-3, ExpectedResult = (long)0)]
			[TestCase((long)-2, (long)-1, ExpectedResult = (long)0)]
			[TestCase((long)-1, (long)-2, ExpectedResult = (long)1)]
			[TestCase((long)0, (long)-1, ExpectedResult = (long)0)]
			[TestCase((long)1, (long)-2, ExpectedResult = (long)1)]
			[TestCase((long)2, (long)-1, ExpectedResult = (long)0)]
			[TestCase((long)3, (long)-3, ExpectedResult = (long)0)]
			[TestCase((long)4, (long)-3, ExpectedResult = (long)1)]
			[TestCase((long)15, (long)-8, ExpectedResult = (long)7)]
			[TestCase((long)16, (long)-4, ExpectedResult = (long)0)]
			[TestCase((long)17, (long)-7, ExpectedResult = (long)3)]
			[TestCase(Int64.MaxValue, -3, ExpectedResult = (long)1)]
			public long OnInt64(long dividend, long divisor)
			{
				return IntegerMath.Modulo(dividend, divisor);
			}

			[Test]
			public void OnInt64_ThrowsWhenDivisorIsZero()
			{
				// Act/Assert
				Assert.That(() =>
				{
					IntegerMath.Modulo((long)10, (long)0);
				}, Throws.InstanceOf<DivideByZeroException>());
			}
		}
	}
}
