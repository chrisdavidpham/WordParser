using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordParser;

namespace WordParserTests
{
    [TestClass]
    public class ParsedWordTests
    {
        [TestMethod]
        public void ParseEmpty_Test()
        {
            string parsed = new ParsedWord(string.Empty).ToString();
            Assert.AreEqual(string.Empty, parsed);
        }

        [TestMethod]
        public void ParseWord_Test()
        {
            string parsed = new ParsedWord("Smooth").ToString();
            Assert.AreEqual("S3h", parsed);
        }

        [TestMethod]
        public void ParseLetter_Test()
        {
            string parsed = new ParsedWord("a").ToString();
            Assert.AreEqual("a0a", parsed);
        }

        [TestMethod]
        public void ParseTwoLetter_Test()
        {
            string parsed = new ParsedWord("in").ToString();
            Assert.AreEqual("i0n", parsed);
        }

        [TestMethod]
        public void ParseThreeLetter_Test()
        {
            string parsed = new ParsedWord("inn").ToString();
            Assert.AreEqual("i1n", parsed);
        }

        [TestMethod]
        public void ParseLargeWord_Test()
        {
            string parsed = new ParsedWord("supercalifragilisticexpialidocious").ToString();
            Assert.AreEqual("s15s", parsed);
        }

        [TestMethod]
        public void ParseAllLetters_Test()
        {
            string parsed = new ParsedWord("aabcdefghijklmnopqrstuvwxyzz").ToString();
            Assert.AreEqual("a26z", parsed);
        }

        [TestMethod]
        public void ParseNumbers_Test()
        {
            string parsed = new ParsedWord("2021").ToString();
            Assert.AreEqual("221", parsed);
        }
    }
}
