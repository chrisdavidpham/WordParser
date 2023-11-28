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
        /// <summary>
        /// Creates a SentenceParser and parses a sentence.
        /// </summary>
        /// <param name="sentence">Sentence to parse.</param>
        public SentenceParser() { }

        /// <summary>
        /// Parses a sentence's words into DistinctCountBetween words
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns></returns>
        public string ParseWords(string sentence)
        {
            return ParseWords(ParseSentence(sentence));
        }

        /// <summary>
        /// Parses words ine DistinctCountBetween words
        /// </summary>
        /// <param name="words"></param>
        /// <returns></returns>
        public string ParseWords(List<string> words)
        {
            var stringBuilder = new StringBuilder();

            words.ForEach(word =>
            {
                stringBuilder.Append(new DistinctCountBetweenWord(word));
            });

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Splits a sentence by words. A word is a string of consecutive alphanumeric characters,
        /// or a string of consecutive special characters.
        /// </summary>
        /// <param name="sentence"></param>
        public List<string> ParseSentence(string sentence)
        {
            var wordList = Regex.Split(sentence, "([^0-9a-zA-Z]+|[0-9a-zA-Z]+)").ToList();
            wordList.RemoveAll(word => word == string.Empty);
            return wordList;
        }
    }
}
