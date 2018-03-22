using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;
#pragma warning disable 1574

namespace Virtlink.Utilib.Text
{
    partial class CodePointTests
    {
        /// <summary>
        /// Tests the <see cref="CodePoint.Equals"/>
        /// and <see cref="CodePoint.GetHashCode"/> methods.
        /// </summary>
        public sealed class EqualityTests
        {
            public static IEnumerable<object[]> EqualObjects => new List<object[]>
            {
                new object[] { CodePoint.Eof, CodePoint.Eof },
                new object[] { default(CodePoint), new CodePoint(0) },
                new object[] { new CodePoint(1), new CodePoint(1) },
                new object[] { new CodePoint(2), new CodePoint(2) },
                new object[] { new CodePoint(0x1242B), new CodePoint(74795) },
                new object[] { new CodePoint(73776), new CodePoint(0x12030) },
            };

            [Theory]
            [MemberData(nameof(EqualObjects))]
            public void ShouldReturnEqual_ForEqualObjects(CodePoint value1, CodePoint value2)
            {
                // Act
                bool equal1 = value1.Equals(value2);
                bool equal2 = value2.Equals(value1);
                bool equal3 = (value1 == value2);
                bool equal4 = (value2 == value1);
                bool equal5 = (value1 != value2);
                bool equal6 = (value2 != value1);

                // Assert
                Assert.True(equal1);
                Assert.True(equal2);
                Assert.True(equal3);
                Assert.True(equal4);
                Assert.False(equal5);
                Assert.False(equal6);
            }

            [Theory]
            [MemberData(nameof(EqualObjects))]
            public void ShouldReturnSameHashCode_ForEqualObjects(CodePoint value1, CodePoint value2)
            {
                // Act
                int hashcode1 = value1.GetHashCode();
                int hashcode2 = value2.GetHashCode();

                // Assert
                Assert.Equal(hashcode1, hashcode2);
            }

            public static IEnumerable<object[]> UnequalObjects => new List<object[]>
            {
                new object[] { CodePoint.Eof, default(CodePoint) },
                new object[] { default(CodePoint), new CodePoint(1) },
                new object[] { new CodePoint(1), new CodePoint(2) },
                new object[] { new CodePoint(2), new CodePoint(1) },
                new object[] { new CodePoint(0x1242B), new CodePoint(73776) },
                new object[] { new CodePoint(74795), new CodePoint(0x12030) },
            };

            [Theory]
            [MemberData(nameof(UnequalObjects))]
            public void ShouldReturnUnequal_ForUnequalObjects(CodePoint value1, CodePoint value2)
            {
                // Act
                bool equal1 = value1.Equals(value2);
                bool equal2 = value2.Equals(value1);
                bool equal3 = (value1 == value2);
                bool equal4 = (value2 == value1);
                bool equal5 = (value1 != value2);
                bool equal6 = (value2 != value1);

                // Assert
                Assert.False(equal1);
                Assert.False(equal2);
                Assert.False(equal3);
                Assert.False(equal4);
                Assert.True(equal5);
                Assert.True(equal6);
            }

            [Fact]
            [SuppressMessage("ReSharper", "ConditionIsAlwaysTrueOrFalse")]
            [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
            public void ShouldReturnFalse_WhenComparedToNull()
            {
                // Arrange
                var value = new CodePoint(1);
                var other = (object) null;

                // Act
                bool equal1 = value.Equals(other);
                bool equal2 = value == null;
                bool equal3 = value != null;

                // Assert
                Assert.False(equal1);
                Assert.False(equal2);
                Assert.True(equal3);
            }

            [Fact]
            public void ShouldReturnFalse_WhenComparedToDifferentTypeOfObject()
            {
                // Arrange
                var value = new CodePoint(1);
                var other = new {Value = 1};

                // Act
                bool equal = value.Equals(other);

                // Assert
                Assert.False(equal);
            }
        }
    }
}
