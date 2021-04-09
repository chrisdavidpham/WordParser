using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace WordParser_Tests
{
    [TestClass]
    public class WordParser_Tests
    {
        [TestMethod]
        public void Empty_Test()
        {
            WordParser.SentenceParser sentenceParser = new WordParser.SentenceParser(string.Empty);
            Assert.AreEqual(string.Empty, sentenceParser.GetNextWord());
        }

        [TestMethod]
        public void SingleWord_Test()
        {
            WordParser.SentenceParser sentenceParser = new WordParser.SentenceParser("Smooth");
            StringBuilder stringBuilder = new StringBuilder();
            string currentWord = sentenceParser.GetNextWord();
            while (!string.IsNullOrEmpty(currentWord))
            {
                stringBuilder.Append(currentWord);
                currentWord = sentenceParser.GetNextWord();
            }
            Assert.AreEqual("Smooth", stringBuilder.ToString());
        }

        [TestMethod]
        public void Sentence_Test()
        {
            WordParser.SentenceParser sentenceParser = new WordParser.SentenceParser("Smooth code is good code");
            StringBuilder stringBuilder = new StringBuilder();
            string currentWord = sentenceParser.GetNextWord();
            while (!string.IsNullOrEmpty(currentWord))
            {
                stringBuilder.Append(currentWord);
                currentWord = sentenceParser.GetNextWord();
            }
            Assert.AreEqual("Smooth code is good code", stringBuilder.ToString());
        }

        [TestMethod]
        public void SpecialChar_Test()
        {
            WordParser.SentenceParser sentenceParser = new WordParser.SentenceParser("Smooth {code}... is, good (code)!");
            StringBuilder stringBuilder = new StringBuilder();
            string currentWord = sentenceParser.GetNextWord();
            while (!string.IsNullOrEmpty(currentWord))
            {
                stringBuilder.Append(currentWord);
                currentWord = sentenceParser.GetNextWord();
            }
            Assert.AreEqual("Smooth {code}... is, good (code)!", stringBuilder.ToString());
        }

        [TestMethod]
        public void Apostrophe_Test()
        {
            WordParser.SentenceParser sentenceParser = new WordParser.SentenceParser("'This' ol' '01 thing isn't mine.");
            StringBuilder stringBuilder = new StringBuilder();
            string currentWord = sentenceParser.GetNextWord();
            while (!string.IsNullOrEmpty(currentWord))
            {
                stringBuilder.Append(currentWord);
                currentWord = sentenceParser.GetNextWord();
            }
            Assert.AreEqual("'This' ol' '01 thing isnt mine.", stringBuilder.ToString());
        }

        [TestMethod]
        public void ParseEmpty_Test()
        {
            string parsed = WordParser.WordParser.ParseWord(string.Empty);
            Assert.AreEqual(string.Empty, parsed);
        }

        [TestMethod]
        public void ParseWord_Test()
        {
            string parsed = WordParser.WordParser.ParseWord("Smooth");
            Assert.AreEqual("S3h", parsed);
        }

        [TestMethod]
        public void ParseLetter_Test()
        {
            string parsed = WordParser.WordParser.ParseWord("a");
            Assert.AreEqual("a0a", parsed);
        }

        [TestMethod]
        public void ParseTwoLetter_Test()
        {
            string parsed = WordParser.WordParser.ParseWord("in");
            Assert.AreEqual("i0n", parsed);
        }

        [TestMethod]
        public void ParseThreeLetter_Test()
        {
            string parsed = WordParser.WordParser.ParseWord("inn");
            Assert.AreEqual("i1n", parsed);
        }

        [TestMethod]
        public void ParseLargeWord_Test()
        {
            string parsed = WordParser.WordParser.ParseWord("supercalifragilisticexpialidocious");
            Assert.AreEqual("s15s", parsed);
        }

        [TestMethod]
        public void ParseAllLetters_Test()
        {
            string parsed = WordParser.WordParser.ParseWord("aabcdefghijklmnopqrstuvwxyzz");
            Assert.AreEqual("a26z", parsed);
        }

        [TestMethod]
        public void ParseNumbers_Test()
        {
            string parsed = WordParser.WordParser.ParseWord("2021");
            Assert.AreEqual("221", parsed);
        }
    }
}
