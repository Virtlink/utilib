using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Virtlink.Utilib
{
    partial class StringExtTests
    {
        [TestFixture]
        public sealed class CountNewlinesTests
        {
            [TestCase("", ExpectedResult = 0)]
            [TestCase("abc", ExpectedResult = 0)]
            [TestCase("\n", ExpectedResult = 1)]
            [TestCase("abc\n", ExpectedResult = 1)]
            [TestCase("\ndef", ExpectedResult = 1)]
            [TestCase("abc\ndef", ExpectedResult = 1)]
            [TestCase("\r", ExpectedResult = 1)]
            [TestCase("abc\r", ExpectedResult = 1)]
            [TestCase("\rdef", ExpectedResult = 1)]
            [TestCase("abc\rdef", ExpectedResult = 1)]
            [TestCase("\r\n", ExpectedResult = 1)]
            [TestCase("abc\r\n", ExpectedResult = 1)]
            [TestCase("\r\ndef", ExpectedResult = 1)]
            [TestCase("abc\r\ndef", ExpectedResult = 1)]
            [TestCase("abc\rdef\rghi", ExpectedResult = 2)]
            [TestCase("abc\ndef\nghi", ExpectedResult = 2)]
            [TestCase("abc\r\ndef\r\nghi", ExpectedResult = 2)]
            [TestCase("abc\r\rghi", ExpectedResult = 2)]
            [TestCase("abc\n\nghi", ExpectedResult = 2)]
            [TestCase("abc\n\rghi", ExpectedResult = 2)]
            public int CountNewlinesTest(string str)
            {
                return StringExt.CountNewlines(str);
            }
        }
    }
}
