using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
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
            _sentenceParser = new SentenceParser(string.Empty);
        }

        [TestMethod]
        public void GetNextWord_GivenEmptySentence_ShouldReturnNull()
        {
            _sentenceParser.ParseSentenceIntoWords(string.Empty);
            
            Assert.AreEqual(null, _sentenceParser.GetNextWord());
        }

        [TestMethod]
        public void ParseSentence_GivenOneWord_ShouldParseOneWord()
        {
            const string word = "Smooth";
            _sentenceParser.ParseSentenceIntoWords(word);

            var nextWord = _sentenceParser.GetNextWord();

            Assert.AreEqual(word, nextWord);
        }

        [TestMethod]
        public void ParseSentence_GivenMultipleWords_ShouldParseEachWord()
        {
            const string sentence = "Clean code";
            _sentenceParser = new SentenceParser(sentence);

            var firstWord = _sentenceParser.GetNextWord();
            var secondWord = _sentenceParser.GetNextWord();
            var thirdWord = _sentenceParser.GetNextWord();

            Assert.AreEqual(sentence, $"{firstWord}{secondWord}{thirdWord}");
        }

        [TestMethod]
        public void ParseSentence_GivenSpecialCharacters_ShouldMaintainSpecialCharacters()
        {
            const string sentence = "  Smooth...";
            _sentenceParser.ParseSentenceIntoWords(sentence);

            var firstWord = _sentenceParser.GetNextWord();
            var secondWord = _sentenceParser.GetNextWord();
            var thirdWord = _sentenceParser.GetNextWord();

            Assert.AreEqual(sentence, $"{firstWord}{secondWord}{thirdWord}");
        }

        [TestMethod]
        public void ParseSentence_GivenComplexSentence_ShouldParseWordsAndMaintainSpecialCharacters()
        {
            const string sentence = "... A Smooth's good, smooth {code} from 01'!";
            _sentenceParser.ParseSentenceIntoWords(sentence);
            
            Assert.AreEqual(sentence, string.Join(string.Empty, _sentenceParser.Words));
        }
    }
}
