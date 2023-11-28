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
            string parsed = new DistinctCountBetweenWord(null).ToString();
            Assert.AreEqual(string.Empty, parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenEmptyString_ShouldParseEmptyString()
        {
            string parsed = new DistinctCountBetweenWord(string.Empty).ToString();
            Assert.AreEqual(string.Empty, parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenOneLetterWord_ShouldNotChangeWord()
        {
            string parsed = new DistinctCountBetweenWord("a").ToString();
            Assert.AreEqual("a", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenTwoLetterWords_ShouldParseWord()
        {
            string parsed = new DistinctCountBetweenWord("in").ToString();
            Assert.AreEqual("i0n", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenThreeLetterWord_ShouldParseWord()
        {
            string parsed = new DistinctCountBetweenWord("inn").ToString();
            Assert.AreEqual("i1n", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenWord_ShouldParseWorld()
        {
            string parsed = new DistinctCountBetweenWord("Smooth").ToString();
            Assert.AreEqual("S3h", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenLargeWord_ShouldParseWord()
        {
            string parsed = new DistinctCountBetweenWord("supercalifragilisticexpialidocious").ToString();
            Assert.AreEqual("s15s", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenAllLettersInWord_ShouldParseWord()
        {
            string parsed = new DistinctCountBetweenWord("aabcdefghijklmnopqrstuvwxyzz").ToString();
            Assert.AreEqual("a26z", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenAllLettersInWord_ShouldParseWordCaseSensitive()
        {
            string parsed = new DistinctCountBetweenWord("aabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZz").ToString();
            Assert.AreEqual("a52z", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenNumbers_ShouldParseWord()
        {
            string parsed = new DistinctCountBetweenWord("2021").ToString();
            Assert.AreEqual("221", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenLettersAndNumbersInWord_ShouldParseWord()
        {
            string parsed = new DistinctCountBetweenWord("aabcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789z").ToString();
            Assert.AreEqual("a62z", parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenSpecialCharacter_ShouldNotChangeWord()
        {
            const string word = " ";
            string parsed = new DistinctCountBetweenWord(word).ToString();
            Assert.AreEqual(word, parsed);
        }

        [TestMethod]
        public void ParsedWordToString_GivenConsecutiveSpecialCharacter_ShouldNotChangeWord()
        {
            const string word = "...";
            string parsed = new DistinctCountBetweenWord(word).ToString();
            Assert.AreEqual(word, parsed);
        }
    }
}
