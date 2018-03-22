using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using Virtlink.Utilib.Collections;

namespace Virtlink.Utilib.Text
{
    /// <summary>
    /// Tests the <see cref="CodePointSet"/> class.
    /// </summary>
    public sealed partial class CodePointSetTests
    {
        internal static ISet<CodePoint> CreateSet(IEnumerable<CodePoint> codePoints)
        {
            return new CodePointSet(codePoints);
        }

        /// <summary>
        /// Returns concatenated code points.
        /// </summary>
        /// <param name="codePoints">The code points.</param>
        /// <returns>The resulting enumerable.</returns>
        internal static IReadOnlyList<CodePoint> Of(params object[] codePoints)
        {
            return codePoints.Select(v => v as IEnumerable<CodePoint> ?? new [] { (CodePoint)v }).SelectMany(c => c).ToList();
        }

        /// <summary>
        /// Returns a range of code points.
        /// </summary>
        /// <param name="from">The first code point.</param>
        /// <param name="to">The last code point.</param>
        /// <returns>The resulting enumerable.</returns>
        internal static IEnumerable<CodePoint> Range(int from, int to)
        {
            for (int i = from; i <= to; i++)
            {
                yield return new CodePoint(i);
            }
        }
    }
}
