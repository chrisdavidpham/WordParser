using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WordParser;

namespace ParsedWordTests
{
    [TestClass]
    public class SentenceParserTests
    {
        private SentenceParser _sentenceParser;

        [TestInitialize]
        public void Setup()
        {
            _sentenceParser = new SentenceParser();
        }

        [TestMethod]
        public void ParseSentence_GivenEmptySentence_ShouldEmptyList()
        {
            var actual = _sentenceParser.ParseSentence(string.Empty);
            
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void ParseSentence_GivenOneWord_ShouldParseOneWord()
        {
            var actual = _sentenceParser.ParseSentence("Smooth");
            var expected = new List<string>()
            {
                "Smooth"
            };

            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }

        [TestMethod]
        public void ParseSentence_GivenMultipleWords_ShouldParseEachWord()
        {
            var actual = _sentenceParser.ParseSentence("Clean code");
            var expected = new List<string>()
            {
                "Clean", " ", "code"
            };

            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }

        [TestMethod]
        public void ParseSentence_GivenSpecialCharacters_ShouldMaintainSpecialCharacters()
        {
            var actual = _sentenceParser.ParseSentence("  Smooth...");
            var expected = new List<string>()
            {
                "  ", "Smooth", "..."
            };

            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }

        [TestMethod]
        public void ParseSentence_GivenComplexSentence_ShouldParseWordsAndMaintainSpecialCharacters()
        {
            const string sentence = "... Smooth's good {code}, from 01'!";
            var actual = _sentenceParser.ParseSentence(sentence);
            var expected = new List<string>()
            {
                "... ", "Smooth", "'", "s", " ", "good", " {", "code", "}, ", "from", " ", "01", "'!",
            };

            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }

        [TestMethod]
        public void ParseWords_GivenWords_ShouldParseAndConcatenateWords()
        {
            var words = new List<string>()
            {
                "... ", "Smooth", "'", "s", " ", "good", " {", "code", "}, ", "from", " ", "01", "'!",
            };
            var expected = "... S3h's g1d {c2e}, f2m 001'!";

            var actual = _sentenceParser.ParseWords(words);

            Assert.IsTrue(Enumerable.SequenceEqual(expected, actual));
        }
    }
}
