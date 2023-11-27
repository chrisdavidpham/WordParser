using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordParser;

namespace ParsedWordTests
{
    [TestClass]
    public class ParsedWordTests
    {
        [TestMethod]
        public void ParsedWordToStringNull_ShouldParseEmptyString()
        {
            string parsed = new ParsedWord(null).ToString();
            Assert.AreEqual(string.Empty, parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenEmptyString_ShouldParseEmptyString()
        {
            string parsed = new ParsedWord(string.Empty).ToString();
            Assert.AreEqual(string.Empty, parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenOneLetterWord_ShouldNotModifyWord()
        {
            string parsed = new ParsedWord("a").ToString();
            Assert.AreEqual("a", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenTwoLetterWords_ShouldParseWord()
        {
            string parsed = new ParsedWord("in").ToString();
            Assert.AreEqual("i0n", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenThreeLetterWord_ShouldParseWord()
        {
            string parsed = new ParsedWord("inn").ToString();
            Assert.AreEqual("i1n", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenWord_ShouldParseWorld()
        {
            string parsed = new ParsedWord("Smooth").ToString();
            Assert.AreEqual("S3h", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenLargeWord_ShouldParseWord()
        {
            string parsed = new ParsedWord("supercalifragilisticexpialidocious").ToString();
            Assert.AreEqual("s15s", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenAllLettersInWord_ShouldParseWord()
        {
            string parsed = new ParsedWord("aabcdefghijklmnopqrstuvwxyzz").ToString();
            Assert.AreEqual("a26z", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenNumbers_ShouldParseWord()
        {
            string parsed = new ParsedWord("2021").ToString();
            Assert.AreEqual("221", parsed);
        }
    }
}
