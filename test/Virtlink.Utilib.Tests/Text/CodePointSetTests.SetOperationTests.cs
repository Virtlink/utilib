using System.Collections.Generic;
using System.Linq;
using Xunit;
// ReSharper disable ArrangeStaticMemberQualifier
// ReSharper disable AccessToStaticMemberViaDerivedType
#pragma warning disable 1574

namespace Virtlink.Utilib.Text
{
    partial class CodePointSetTests
    {
        /// <summary>
        /// Tests the <see cref="CodePointSet.UnionWith"/>, <see cref="CodePointSet.IntersectWth"/>,
        /// <see cref="CodePointSet.ExceptWith"/>, and <see cref="CodePointSet.SymmetricExceptWith"/> methods.
        /// </summary>
        public sealed class SetOperationTests
        {
            public static IEnumerable<object[]> TestObjects => new List<object[]>
            {
                // Low code points only:
                // With no EOF
                new object[]
                {
                    Of(),
                    //
                    //
                    Of(),
                },
                new object[]
                {
                    Of(Range(40, 50)),
                    //    |----|
                    //
                    Of(),
                },
                new object[]
                {
                    Of(),
                    //
                    //    |----|
                    Of(Range(40, 50)),
                },
                new object[]
                {
                    Of(Range(40, 50)),
                    //    |----|
                    //    |----|
                    Of(Range(40, 50)),
                },
                new object[]
                {
                    Of(Range(40, 50)),
                    //    |----|
                    //  |--------|
                    Of(Range(35, 55)),
                },
                new object[]
                {
                    Of(Range(35, 55)),
                    //  |--------|
                    //    |----|
                    Of(Range(40, 50)),
                },
                new object[]
                {
                    Of(Range(25, 35)),
                    // |----|
                    //        |----|
                    Of(Range(40, 50)),
                },
                new object[]
                {
                    Of(Range(30, 40)),
                    //   |----|
                    //        |----|
                    Of(Range(40, 50)),
                },
                new object[]
                {
                    Of(Range(35, 45)),
                    //     |----|
                    //        |----|
                    Of(Range(40, 50)),
                },
                new object[]
                {
                    Of(Range(40, 50)),
                    //        |----|
                    //     |----|
                    Of(Range(35, 45)),
                },
                new object[]
                {
                    Of(Range(40, 50)),
                    //          |----|
                    //     |----|
                    Of(Range(30, 40)),
                },
                new object[]
                {
                    Of(Range(40, 50)),
                    //               |----|
                    //        |----|
                    Of(Range(25, 35)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //
                    Of(),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    // |-|
                    Of(Range(35, 37)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |-|
                    Of(Range(38, 40)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //   |-|
                    Of(Range(39, 41)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //    |-|
                    Of(Range(40, 42)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //     |-|
                    Of(Range(41, 43)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //       |-|
                    Of(Range(43, 45)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //        |-|
                    Of(Range(44, 46)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //         |-|
                    Of(Range(45, 47)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //           |-|
                    Of(Range(47, 49)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //             |-|
                    Of(Range(48, 50)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //              |-|
                    Of(Range(49, 51)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //               |-|
                    Of(Range(50, 52)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                |-|
                    Of(Range(51, 53)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                  |-|
                    Of(Range(53, 55)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                   |-|
                    Of(Range(54, 56)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                    |-|
                    Of(Range(55, 57)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                     |-|
                    Of(Range(56, 58)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //         |-----|
                    Of(Range(45, 50)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //        |-------|
                    Of(Range(44, 51)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //    |---------------|
                    Of(Range(40, 55)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |-------------------|
                    Of(Range(38, 57)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |-----------------|
                    Of(Range(38, 55)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |---------------|
                    Of(Range(38, 52)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |------------|
                    Of(Range(38, 50)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //    |-----------------|
                    Of(Range(40, 57)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //      |---------------|
                    Of(Range(42, 57)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //         |------------|
                    Of(Range(45, 57)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //      |----|     |----|
                    // |----|     |----|
                    Of(Range(35, 40), Range(46, 50)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |----|     |----|
                    Of(Range(38, 43), Range(48, 53)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //    |----|     |----|
                    Of(Range(40, 45), Range(50, 55)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //      |----|     |----|
                    Of(Range(42, 47), Range(52, 57)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //         |----|     |----|
                    Of(Range(45, 49), Range(52, 57)),
                },

                // With one EOF
                new object[]
                {
                    Of(),
                    //
                    //
                    Of(CodePoint.Eof),
                },
                new object[]
                {
                    Of(Range(40, 50)),
                    //    |----|
                    //
                    Of(CodePoint.Eof),
                },
                new object[]
                {
                    Of(),
                    //
                    //    |----|
                    Of(CodePoint.Eof, Range(40, 50)),
                },
                new object[]
                {
                    Of(Range(40, 50)),
                    //    |----|
                    //    |----|
                    Of(CodePoint.Eof, Range(40, 50)),
                },
                new object[]
                {
                    Of(Range(40, 50)),
                    //    |----|
                    //  |--------|
                    Of(CodePoint.Eof, Range(35, 55)),
                },
                new object[]
                {
                    Of(Range(35, 55)),
                    //  |--------|
                    //    |----|
                    Of(CodePoint.Eof, Range(40, 50)),
                },
                new object[]
                {
                    Of(Range(25, 35)),
                    // |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(40, 50)),
                },
                new object[]
                {
                    Of(Range(30, 40)),
                    //   |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(40, 50)),
                },
                new object[]
                {
                    Of(Range(35, 45)),
                    //     |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(40, 50)),
                },
                new object[]
                {
                    Of(Range(40, 50)),
                    //        |----|
                    //     |----|
                    Of(CodePoint.Eof, Range(35, 45)),
                },
                new object[]
                {
                    Of(Range(40, 50)),
                    //          |----|
                    //     |----|
                    Of(CodePoint.Eof, Range(30, 40)),
                },
                new object[]
                {
                    Of(Range(40, 50)),
                    //               |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(25, 35)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //
                    Of(CodePoint.Eof),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    // |-|
                    Of(CodePoint.Eof, Range(35, 37)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |-|
                    Of(CodePoint.Eof, Range(38, 40)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //   |-|
                    Of(CodePoint.Eof, Range(39, 41)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //    |-|
                    Of(CodePoint.Eof, Range(40, 42)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //     |-|
                    Of(CodePoint.Eof, Range(41, 43)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //       |-|
                    Of(CodePoint.Eof, Range(43, 45)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //        |-|
                    Of(CodePoint.Eof, Range(44, 46)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //         |-|
                    Of(CodePoint.Eof, Range(45, 47)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //           |-|
                    Of(CodePoint.Eof, Range(47, 49)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //             |-|
                    Of(CodePoint.Eof, Range(48, 50)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //              |-|
                    Of(CodePoint.Eof, Range(49, 51)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //               |-|
                    Of(CodePoint.Eof, Range(50, 52)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                |-|
                    Of(CodePoint.Eof, Range(51, 53)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                  |-|
                    Of(CodePoint.Eof, Range(53, 55)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                   |-|
                    Of(CodePoint.Eof, Range(54, 56)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                    |-|
                    Of(CodePoint.Eof, Range(55, 57)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                     |-|
                    Of(CodePoint.Eof, Range(56, 58)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //         |-----|
                    Of(CodePoint.Eof, Range(45, 50)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //        |-------|
                    Of(CodePoint.Eof, Range(44, 51)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //    |---------------|
                    Of(CodePoint.Eof, Range(40, 55)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |-------------------|
                    Of(CodePoint.Eof, Range(38, 57)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |-----------------|
                    Of(CodePoint.Eof, Range(38, 55)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |---------------|
                    Of(CodePoint.Eof, Range(38, 52)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |------------|
                    Of(CodePoint.Eof, Range(38, 50)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //    |-----------------|
                    Of(CodePoint.Eof, Range(40, 57)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //      |---------------|
                    Of(CodePoint.Eof, Range(42, 57)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //         |------------|
                    Of(CodePoint.Eof, Range(45, 57)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //      |----|     |----|
                    // |----|     |----|
                    Of(CodePoint.Eof, Range(35, 40), Range(46, 50)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |----|     |----|
                    Of(CodePoint.Eof, Range(38, 43), Range(48, 53)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //    |----|     |----|
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //      |----|     |----|
                    Of(CodePoint.Eof, Range(42, 47), Range(52, 57)),
                },
                new object[]
                {
                    Of(Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //         |----|     |----|
                    Of(CodePoint.Eof, Range(45, 49), Range(52, 57)),
                },

                // With two EOFs
                new object[]
                {
                    Of(CodePoint.Eof),
                    //
                    //
                    Of(CodePoint.Eof),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 50)),
                    //    |----|
                    //
                    Of(CodePoint.Eof),
                },
                new object[]
                {
                    Of(CodePoint.Eof),
                    //
                    //    |----|
                    Of(CodePoint.Eof, Range(40, 50)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 50)),
                    //    |----|
                    //    |----|
                    Of(CodePoint.Eof, Range(40, 50)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 50)),
                    //    |----|
                    //  |--------|
                    Of(CodePoint.Eof, Range(35, 55)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(35, 55)),
                    //  |--------|
                    //    |----|
                    Of(CodePoint.Eof, Range(40, 50)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(25, 35)),
                    // |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(40, 50)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(30, 40)),
                    //   |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(40, 50)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(35, 45)),
                    //     |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(40, 50)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 50)),
                    //        |----|
                    //     |----|
                    Of(CodePoint.Eof, Range(35, 45)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 50)),
                    //          |----|
                    //     |----|
                    Of(CodePoint.Eof, Range(30, 40)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 50)),
                    //               |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(25, 35)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //
                    Of(CodePoint.Eof),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    // |-|
                    Of(CodePoint.Eof, Range(35, 37)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |-|
                    Of(CodePoint.Eof, Range(38, 40)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //   |-|
                    Of(CodePoint.Eof, Range(39, 41)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //    |-|
                    Of(CodePoint.Eof, Range(40, 42)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //     |-|
                    Of(CodePoint.Eof, Range(41, 43)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //       |-|
                    Of(CodePoint.Eof, Range(43, 45)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //        |-|
                    Of(CodePoint.Eof, Range(44, 46)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //         |-|
                    Of(CodePoint.Eof, Range(45, 47)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //           |-|
                    Of(CodePoint.Eof, Range(47, 49)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //             |-|
                    Of(CodePoint.Eof, Range(48, 50)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //              |-|
                    Of(CodePoint.Eof, Range(49, 51)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //               |-|
                    Of(CodePoint.Eof, Range(50, 52)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                |-|
                    Of(CodePoint.Eof, Range(51, 53)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                  |-|
                    Of(CodePoint.Eof, Range(53, 55)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                   |-|
                    Of(CodePoint.Eof, Range(54, 56)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                    |-|
                    Of(CodePoint.Eof, Range(55, 57)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //                     |-|
                    Of(CodePoint.Eof, Range(56, 58)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //         |-----|
                    Of(CodePoint.Eof, Range(45, 50)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //        |-------|
                    Of(CodePoint.Eof, Range(44, 51)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //    |---------------|
                    Of(CodePoint.Eof, Range(40, 55)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |-------------------|
                    Of(CodePoint.Eof, Range(38, 57)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |-----------------|
                    Of(CodePoint.Eof, Range(38, 55)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |---------------|
                    Of(CodePoint.Eof, Range(38, 52)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |------------|
                    Of(CodePoint.Eof, Range(38, 50)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //    |-----------------|
                    Of(CodePoint.Eof, Range(40, 57)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //      |---------------|
                    Of(CodePoint.Eof, Range(42, 57)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //         |------------|
                    Of(CodePoint.Eof, Range(45, 57)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //      |----|     |----|
                    // |----|     |----|
                    Of(CodePoint.Eof, Range(35, 40), Range(46, 50)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //  |----|     |----|
                    Of(CodePoint.Eof, Range(38, 43), Range(48, 53)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //    |----|     |----|
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //      |----|     |----|
                    Of(CodePoint.Eof, Range(42, 47), Range(52, 57)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(40, 45), Range(50, 55)),
                    //    |----|     |----|
                    //         |----|     |----|
                    Of(CodePoint.Eof, Range(45, 49), Range(52, 57)),
                },



                // High code points only:
                // With no EOF
                new object[]
                {
                    Of(),
                    //
                    //
                    Of(),
                },
                new object[]
                {
                    Of(Range(1000, 1010)),
                    //    |----|
                    //
                    Of(),
                },
                new object[]
                {
                    Of(),
                    //
                    //    |----|
                    Of(Range(1000, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1010)),
                    //    |----|
                    //    |----|
                    Of(Range(1000, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1010)),
                    //    |----|
                    //  |--------|
                    Of(Range(995, 1015)),
                },
                new object[]
                {
                    Of(Range(995, 1015)),
                    //  |--------|
                    //    |----|
                    Of(Range(1000, 1010)),
                },
                new object[]
                {
                    Of(Range(985, 995)),
                    // |----|
                    //        |----|
                    Of(Range(1000, 1010)),
                },
                new object[]
                {
                    Of(Range(990, 1000)),
                    //   |----|
                    //        |----|
                    Of(Range(1000, 1010)),
                },
                new object[]
                {
                    Of(Range(995, 1005)),
                    //     |----|
                    //        |----|
                    Of(Range(1000, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1010)),
                    //        |----|
                    //     |----|
                    Of(Range(995, 1005)),
                },
                new object[]
                {
                    Of(Range(1000, 1010)),
                    //          |----|
                    //     |----|
                    Of(Range(990, 1000)),
                },
                new object[]
                {
                    Of(Range(1000, 1010)),
                    //               |----|
                    //        |----|
                    Of(Range(985, 995)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //
                    Of(),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    // |-|
                    Of(Range(995, 997)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |-|
                    Of(Range(998, 1000)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //   |-|
                    Of(Range(999, 1001)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //    |-|
                    Of(Range(1000, 1002)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //     |-|
                    Of(Range(1001, 1003)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //       |-|
                    Of(Range(1003, 1005)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //        |-|
                    Of(Range(1004, 1006)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //         |-|
                    Of(Range(1005, 1007)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //           |-|
                    Of(Range(1007, 1009)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //             |-|
                    Of(Range(1008, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //              |-|
                    Of(Range(1009, 1011)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //               |-|
                    Of(Range(1010, 1012)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                |-|
                    Of(Range(1011, 1013)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                  |-|
                    Of(Range(1013, 1015)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                   |-|
                    Of(Range(1014, 1016)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                    |-|
                    Of(Range(1015, 1017)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                     |-|
                    Of(Range(1016, 1018)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //         |-----|
                    Of(Range(1005, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //        |-------|
                    Of(Range(1004, 1011)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //    |---------------|
                    Of(Range(1000, 1015)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |-------------------|
                    Of(Range(998, 1017)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |-----------------|
                    Of(Range(998, 1015)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |---------------|
                    Of(Range(998, 1012)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |------------|
                    Of(Range(998, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //    |-----------------|
                    Of(Range(1000, 1017)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //      |---------------|
                    Of(Range(1002, 1017)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //         |------------|
                    Of(Range(1005, 1017)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //      |----|     |----|
                    // |----|     |----|
                    Of(Range(995, 1000), Range(1006, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |----|     |----|
                    Of(Range(998, 1003), Range(1008, 1013)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //    |----|     |----|
                    Of(Range(1000, 1005), Range(1010, 1015)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //      |----|     |----|
                    Of(Range(1002, 1007), Range(1012, 1017)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //         |----|     |----|
                    Of(Range(1005, 1009), Range(1012, 1017)),
                },

                // With one EOF
                new object[]
                {
                    Of(),
                    //
                    //
                    Of(CodePoint.Eof),
                },
                new object[]
                {
                    Of(Range(1000, 1010)),
                    //    |----|
                    //
                    Of(CodePoint.Eof),
                },
                new object[]
                {
                    Of(),
                    //
                    //    |----|
                    Of(CodePoint.Eof, Range(1000, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1010)),
                    //    |----|
                    //    |----|
                    Of(CodePoint.Eof, Range(1000, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1010)),
                    //    |----|
                    //  |--------|
                    Of(CodePoint.Eof, Range(995, 1015)),
                },
                new object[]
                {
                    Of(Range(995, 1015)),
                    //  |--------|
                    //    |----|
                    Of(CodePoint.Eof, Range(1000, 1010)),
                },
                new object[]
                {
                    Of(Range(985, 995)),
                    // |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(1000, 1010)),
                },
                new object[]
                {
                    Of(Range(990, 1000)),
                    //   |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(1000, 1010)),
                },
                new object[]
                {
                    Of(Range(995, 1005)),
                    //     |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(1000, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1010)),
                    //        |----|
                    //     |----|
                    Of(CodePoint.Eof, Range(995, 1005)),
                },
                new object[]
                {
                    Of(Range(1000, 1010)),
                    //          |----|
                    //     |----|
                    Of(CodePoint.Eof, Range(990, 1000)),
                },
                new object[]
                {
                    Of(Range(1000, 1010)),
                    //               |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(985, 995)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //
                    Of(CodePoint.Eof),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    // |-|
                    Of(CodePoint.Eof, Range(995, 997)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |-|
                    Of(CodePoint.Eof, Range(998, 1000)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //   |-|
                    Of(CodePoint.Eof, Range(999, 1001)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //    |-|
                    Of(CodePoint.Eof, Range(1000, 1002)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //     |-|
                    Of(CodePoint.Eof, Range(1001, 1003)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //       |-|
                    Of(CodePoint.Eof, Range(1003, 1005)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //        |-|
                    Of(CodePoint.Eof, Range(1004, 1006)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //         |-|
                    Of(CodePoint.Eof, Range(1005, 1007)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //           |-|
                    Of(CodePoint.Eof, Range(1007, 1009)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //             |-|
                    Of(CodePoint.Eof, Range(1008, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //              |-|
                    Of(CodePoint.Eof, Range(1009, 1011)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //               |-|
                    Of(CodePoint.Eof, Range(1010, 1012)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                |-|
                    Of(CodePoint.Eof, Range(1011, 1013)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                  |-|
                    Of(CodePoint.Eof, Range(1013, 1015)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                   |-|
                    Of(CodePoint.Eof, Range(1014, 1016)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                    |-|
                    Of(CodePoint.Eof, Range(1015, 1017)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                     |-|
                    Of(CodePoint.Eof, Range(1016, 1018)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //         |-----|
                    Of(CodePoint.Eof, Range(1005, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //        |-------|
                    Of(CodePoint.Eof, Range(1004, 1011)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //    |---------------|
                    Of(CodePoint.Eof, Range(1000, 1015)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |-------------------|
                    Of(CodePoint.Eof, Range(998, 1017)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |-----------------|
                    Of(CodePoint.Eof, Range(998, 1015)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |---------------|
                    Of(CodePoint.Eof, Range(998, 1012)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |------------|
                    Of(CodePoint.Eof, Range(998, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //    |-----------------|
                    Of(CodePoint.Eof, Range(1000, 1017)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //      |---------------|
                    Of(CodePoint.Eof, Range(1002, 1017)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //         |------------|
                    Of(CodePoint.Eof, Range(1005, 1017)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //      |----|     |----|
                    // |----|     |----|
                    Of(CodePoint.Eof, Range(995, 1000), Range(1006, 1010)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |----|     |----|
                    Of(CodePoint.Eof, Range(998, 1003), Range(1008, 1013)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //    |----|     |----|
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //      |----|     |----|
                    Of(CodePoint.Eof, Range(1002, 1007), Range(1012, 1017)),
                },
                new object[]
                {
                    Of(Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //         |----|     |----|
                    Of(CodePoint.Eof, Range(1005, 1009), Range(1012, 1017)),
                },

                // With two EOFs
                new object[]
                {
                    Of(CodePoint.Eof),
                    //
                    //
                    Of(CodePoint.Eof),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1010)),
                    //    |----|
                    //
                    Of(CodePoint.Eof),
                },
                new object[]
                {
                    Of(CodePoint.Eof),
                    //
                    //    |----|
                    Of(CodePoint.Eof, Range(1000, 1010)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1010)),
                    //    |----|
                    //    |----|
                    Of(CodePoint.Eof, Range(1000, 1010)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1010)),
                    //    |----|
                    //  |--------|
                    Of(CodePoint.Eof, Range(995, 1015)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(995, 1015)),
                    //  |--------|
                    //    |----|
                    Of(CodePoint.Eof, Range(1000, 1010)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(985, 995)),
                    // |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(1000, 1010)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(990, 1000)),
                    //   |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(1000, 1010)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(995, 1005)),
                    //     |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(1000, 1010)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1010)),
                    //        |----|
                    //     |----|
                    Of(CodePoint.Eof, Range(995, 1005)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1010)),
                    //          |----|
                    //     |----|
                    Of(CodePoint.Eof, Range(990, 1000)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1010)),
                    //               |----|
                    //        |----|
                    Of(CodePoint.Eof, Range(985, 995)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //
                    Of(CodePoint.Eof),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    // |-|
                    Of(CodePoint.Eof, Range(995, 997)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |-|
                    Of(CodePoint.Eof, Range(998, 1000)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //   |-|
                    Of(CodePoint.Eof, Range(999, 1001)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //    |-|
                    Of(CodePoint.Eof, Range(1000, 1002)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //     |-|
                    Of(CodePoint.Eof, Range(1001, 1003)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //       |-|
                    Of(CodePoint.Eof, Range(1003, 1005)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //        |-|
                    Of(CodePoint.Eof, Range(1004, 1006)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //         |-|
                    Of(CodePoint.Eof, Range(1005, 1007)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //           |-|
                    Of(CodePoint.Eof, Range(1007, 1009)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //             |-|
                    Of(CodePoint.Eof, Range(1008, 1010)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //              |-|
                    Of(CodePoint.Eof, Range(1009, 1011)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //               |-|
                    Of(CodePoint.Eof, Range(1010, 1012)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                |-|
                    Of(CodePoint.Eof, Range(1011, 1013)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                  |-|
                    Of(CodePoint.Eof, Range(1013, 1015)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                   |-|
                    Of(CodePoint.Eof, Range(1014, 1016)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                    |-|
                    Of(CodePoint.Eof, Range(1015, 1017)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //                     |-|
                    Of(CodePoint.Eof, Range(1016, 1018)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //         |-----|
                    Of(CodePoint.Eof, Range(1005, 1010)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //        |-------|
                    Of(CodePoint.Eof, Range(1004, 1011)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //    |---------------|
                    Of(CodePoint.Eof, Range(1000, 1015)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |-------------------|
                    Of(CodePoint.Eof, Range(998, 1017)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |-----------------|
                    Of(CodePoint.Eof, Range(998, 1015)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |---------------|
                    Of(CodePoint.Eof, Range(998, 1012)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |------------|
                    Of(CodePoint.Eof, Range(998, 1010)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //    |-----------------|
                    Of(CodePoint.Eof, Range(1000, 1017)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //      |---------------|
                    Of(CodePoint.Eof, Range(1002, 1017)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //         |------------|
                    Of(CodePoint.Eof, Range(1005, 1017)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //      |----|     |----|
                    // |----|     |----|
                    Of(CodePoint.Eof, Range(995, 1000), Range(1006, 1010)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //  |----|     |----|
                    Of(CodePoint.Eof, Range(998, 1003), Range(1008, 1013)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //    |----|     |----|
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //      |----|     |----|
                    Of(CodePoint.Eof, Range(1002, 1007), Range(1012, 1017)),
                },
                new object[]
                {
                    Of(CodePoint.Eof, Range(1000, 1005), Range(1010, 1015)),
                    //    |----|     |----|
                    //         |----|     |----|
                    Of(CodePoint.Eof, Range(1005, 1009), Range(1012, 1017)),
                },
            };

            [Theory]
            [MemberData(nameof(TestObjects))]
            public void UnionTest(IReadOnlyList<CodePoint> xs, IReadOnlyList<CodePoint> ys)
            {
                // Arrange
                var set = CreateSet(xs);

                // Act
                set.UnionWith(CreateSet(ys));

                // Assert
                Assert.Equivalent(xs.Union(ys), set);
            }

            [Theory]
            [MemberData(nameof(TestObjects))]
            public void IntersectTest(IReadOnlyList<CodePoint> xs, IReadOnlyList<CodePoint> ys)
            {
                // Arrange
                var set = CreateSet(xs);

                // Act
                set.IntersectWith(CreateSet(ys));

                // Assert
                Assert.Equivalent(xs.Intersect(ys), set);
            }

            [Theory]
            [MemberData(nameof(TestObjects))]
            public void ExceptTest(IReadOnlyList<CodePoint> xs, IReadOnlyList<CodePoint> ys)
            {
                // Arrange
                var set = CreateSet(xs);

                // Act
                set.ExceptWith(CreateSet(ys));

                // Assert
                Assert.Equivalent(xs.Except(ys), set);
            }

            [Theory]
            [MemberData(nameof(TestObjects))]
            public void SymmetricExceptTest(IReadOnlyList<CodePoint> xs, IReadOnlyList<CodePoint> ys)
            {
                // Arrange
                var set = CreateSet(xs);

                // Act
                set.SymmetricExceptWith(CreateSet(ys));

                // Assert
                Assert.Equivalent(xs.Except(ys).Union(ys.Except(xs)), set);
            }

            [Theory]
            [MemberData(nameof(TestObjects))]
            public void IsSubsetOfTest(IReadOnlyList<CodePoint> xs, IReadOnlyList<CodePoint> ys)
            {
                // Act
                var result = CreateSet(xs).IsSubsetOf(CreateSet(ys));

                // Assert
                Assert.Equal(!xs.Except(ys).Any(), result);
            }

            [Theory]
            [MemberData(nameof(TestObjects))]
            public void IsSupersetOfTest(IReadOnlyList<CodePoint> xs, IReadOnlyList<CodePoint> ys)
            {
                // Act
                var result = CreateSet(xs).IsSupersetOf(CreateSet(ys));

                // Assert
                Assert.Equal(!ys.Except(xs).Any(), result);
            }

            [Theory]
            [MemberData(nameof(TestObjects))]
            public void IsProperSubsetOfTest(IReadOnlyList<CodePoint> xs, IReadOnlyList<CodePoint> ys)
            {
                // Act
                var result = CreateSet(xs).IsProperSubsetOf(CreateSet(ys));

                // Assert
                Assert.Equal(!xs.Except(ys).Any() && ys.Except(xs).Any(), result);
            }

            [Theory]
            [MemberData(nameof(TestObjects))]
            public void IsProperSupersetOfTest(IReadOnlyList<CodePoint> xs, IReadOnlyList<CodePoint> ys)
            {
                // Act
                var result = CreateSet(xs).IsProperSupersetOf(CreateSet(ys));

                // Assert
                Assert.Equal(!ys.Except(xs).Any() && xs.Except(ys).Any(), result);
            }

            [Theory]
            [MemberData(nameof(TestObjects))]
            public void OverlapsTest(IReadOnlyList<CodePoint> xs, IReadOnlyList<CodePoint> ys)
            {
                // Act
                var result = CreateSet(xs).Overlaps(CreateSet(ys));

                // Assert
                Assert.Equal(xs.Intersect(ys).Any(), result);
            }

            [Theory]
            [MemberData(nameof(TestObjects))]
            public void SetEqualsTest(IReadOnlyList<CodePoint> xs, IReadOnlyList<CodePoint> ys)
            {
                // Act
                var result = CreateSet(xs).SetEquals(CreateSet(ys));

                // Assert
                Assert.Equal(!xs.Except(ys).Union(ys.Except(xs)).Any(), result);
            }
        }
    }
}
