using System;

namespace Virtlink.Utilib
{
    /// <summary>
    /// Extension methods for working with strings.
    /// </summary>
    public static class StringExt
    {
        /// <summary>
        /// Counts the number of newlines in the string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>The number of newlines.</returns>
        /// <remarks>
        /// This function calls the number of CR+LR, CR, and LF in a string.
        /// </remarks>
        public static int CountNewlines(this string str)
        {
            #region Contract
            if (str == null)
                throw new ArgumentNullException(nameof(str));
            #endregion

            bool inNewline = false;
            int count = 0;
            foreach (var c in str)
            {
                if (c == '\r')
                {
                    count += 1;
                    inNewline = true;
                }
                else if (!inNewline && c == '\n')
                {
                    count += 1;
                }
                else
                {
                    inNewline = false;
                }
            }
            return count;
        }
    }
}