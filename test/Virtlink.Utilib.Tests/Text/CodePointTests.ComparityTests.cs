using System;
using System.Collections.Generic;
using Xunit;

namespace Virtlink.Utilib.Text
{
    partial class CodePointTests
    {
        /// <summary>
        /// Tests the <see cref="CodePoint.CompareTo"/> method.
        /// </summary>
        public sealed class ComparityTests
        {
            public static IEnumerable<object[]> GreaterObjects => new List<object[]>
            {
                new object[] { default(CodePoint), CodePoint.Eof },
                new object[] { new CodePoint(1), default(CodePoint) },
                new object[] { new CodePoint(1234), new CodePoint(0) },
                new object[] { new CodePoint(73776), new CodePoint(73770) },
                new object[] { new CodePoint(0x10FFFF), new CodePoint(0x10FFFE) },
            };

            [Theory]
            [MemberData(nameof(GreaterObjects))]
            public void ShouldReturnGreaterThan_ForGreaterObjects(CodePoint value1, CodePoint value2)
            {
                // Act
                int comparity = value1.CompareTo(value2);
                bool gt = (value1 > value2);
                bool ge = (value1 >= value2);
                bool le = (value1 <= value2);
                bool lt = (value1 < value2);

                // Assert
                Assert.True(comparity > 0);
                Assert.True(gt);
                Assert.True(ge);
                Assert.False(le);
                Assert.False(lt);
            }

            public static IEnumerable<object[]> EqualObjects => new List<object[]>
            {
                new object[] { CodePoint.Eof, CodePoint.Eof },
                new object[] { default(CodePoint), new CodePoint(0) },
                new object[] { new CodePoint(1), new CodePoint(1) },
                new object[] { new CodePoint(2), new CodePoint(2) },
                new object[] { new CodePoint(74795), new CodePoint(74795) },
                new object[] { new CodePoint(73776), new CodePoint(73776) },
            };

            [Theory]
            [MemberData(nameof(EqualObjects))]
            public void ShouldReturnEqualTo_ForEqualObjects(CodePoint value1, CodePoint value2)
            {
                // Act
                int comparity = value1.CompareTo(value2);
                bool gt = (value1 > value2);
                bool ge = (value1 >= value2);
                bool le = (value1 <= value2);
                bool lt = (value1 < value2);

                // Assert
                Assert.True(comparity == 0);
                Assert.False(gt);
                Assert.True(ge);
                Assert.True(le);
                Assert.False(lt);
            }

            public static IEnumerable<object[]> LesserObjects => new List<object[]>
            {
                new object[] { CodePoint.Eof, default(CodePoint) },
                new object[] { default(CodePoint), new CodePoint(1) },
                new object[] { new CodePoint(0), new CodePoint(1234) },
                new object[] { new CodePoint(73770), new CodePoint(73776) },
                new object[] { new CodePoint(0x10FFFE), new CodePoint(0x10FFFF) },
            };

            [Theory]
            [MemberData(nameof(LesserObjects))]
            public void ShouldReturnLessThan_ForLesserObjects(CodePoint value1, CodePoint value2)
            {
                // Act
                int comparity = value1.CompareTo(value2);
                bool gt = (value1 > value2);
                bool ge = (value1 >= value2);
                bool le = (value1 <= value2);
                bool lt = (value1 < value2);

                // Assert
                Assert.True(comparity < 0);
                Assert.False(gt);
                Assert.False(ge);
                Assert.True(le);
                Assert.True(lt);
            }
        }
    }
}
