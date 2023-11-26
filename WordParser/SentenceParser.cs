using System.Collections.Generic;
using System.Linq;
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
        public SentenceParser(string sentence)
        {
            ParseSentence(sentence);
        }

        /// <summary>
        /// Parses a string, splitting words by special characters.
        /// </summary>
        /// <param name="sentence"></param>
        public void ParseSentence(string sentence)
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
        public string GetNextWord()
        {
            return Words.ElementAtOrDefault(CurrentIndex++);
        }
    }
}
