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
            Assert.AreEqual(sentenceParser.GetNextWord(), string.Empty);
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
            Assert.AreEqual(stringBuilder.ToString(), "Smooth");
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
            Assert.AreEqual(stringBuilder.ToString(), "Smooth code is good code");
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
            Assert.AreEqual(stringBuilder.ToString(), "Smooth {code}... is, good (code)!");
        }

        [TestMethod]
        public void ParseEmpty_Test()
        {
            string parsed = WordParser.WordParser.ParseWord(string.Empty);
            Assert.AreEqual(parsed, string.Empty);
        }

        [TestMethod]
        public void ParseWord_Test()
        {
            string parsed = WordParser.WordParser.ParseWord("Smooth");
            Assert.AreEqual(parsed, "S3h");
        }

        [TestMethod]
        public void ParseLetter_Test()
        {
            string parsed = WordParser.WordParser.ParseWord("a");
            Assert.AreEqual(parsed, "a0a");
        }

        [TestMethod]
        public void ParseTwoLetter_Test()
        {
            string parsed = WordParser.WordParser.ParseWord("in");
            Assert.AreEqual(parsed, "i0n");
        }

        [TestMethod]
        public void ParseThreeLetter_Test()
        {
            string parsed = WordParser.WordParser.ParseWord("inn");
            Assert.AreEqual(parsed, "i1n");
        }

        [TestMethod]
        public void ParseLargeWord_Test()
        {
            string parsed = WordParser.WordParser.ParseWord("supercalifragilisticexpialidocious");
            Assert.AreEqual(parsed, "s15s");
        }


        [TestMethod]
        public void ParseAllLetters_Test()
        {
            string parsed = WordParser.WordParser.ParseWord("aabcdefghijklmnopqrstuvwxyzz");
            Assert.AreEqual(parsed, "a26z");
        }
    }
}
