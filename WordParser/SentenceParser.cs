using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordParser
{
    /// <summary>
    /// Parses words in a sentence and itterates each word.
    /// </summary>
    public class SentenceParser
    {
        public List<string> Words { get; private set; }
        private int CurrentIndex;

        /// <summary>
        /// Creates a SentenceParser and parses a sentence.
        /// </summary>
        /// <param name="sentence">Sentence to parse.</param>
        public SentenceParser() { }

        public string ParseSentenceIntoParsedWords(string sentence)
        {
            ParseSentenceIntoWords(sentence);

            var currentWord = GetNextWord();
            var stringBuilder = new StringBuilder();

            while (!string.IsNullOrEmpty(currentWord))
            {
                var currentWordParsed = new ParsedWord(currentWord);
                stringBuilder.Append(currentWordParsed);
                currentWord = GetNextWord();
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Parses a string, splitting words by special characters.
        /// </summary>
        /// <param name="sentence"></param>
        private void ParseSentenceIntoWords(string sentence)
        {
            CurrentIndex = 0;
            var wordList = Regex.Split(sentence, "([^0-9a-zA-Z]+|[0-9a-zA-Z]+)").ToList();
            wordList.RemoveAll(word => word == string.Empty);
            Words = wordList;
        }

        /// <summary>
        /// Get next word in the parsed sentence.
        /// </summary>
        /// <returns></returns>
        private string GetNextWord()
        {
            return Words.ElementAtOrDefault(CurrentIndex++);
        }
    }
}
