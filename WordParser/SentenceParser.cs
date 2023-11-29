using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordParser
{
    /// <summary>
    /// Parses the words in a sentence into a list, and can parse words into DistinctCountBetweenWords.
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
        /// <returns>String value of the sentence words parsed as DistinctCountBetweenWords</returns>
        public string ParseWords(string sentence)
        {
            return ParseWords(ParseSentence(sentence));
        }

        /// <summary>
        /// Parses words into DistinctCountBetween words
        /// </summary>
        /// <param name="words"></param>
        /// <returns>String value of the words parsed as DistinctCountBetweenWords</returns>
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
        /// Parses a sentence's words. A word is a string of consecutive alphanumeric characters or a string of consecutive special characters.
        /// </summary>
        /// <param name="sentence"></param>
        /// <returns>List of words in the sentence</returns>
        public List<string> ParseSentence(string sentence)
        {
            var wordList = Regex.Split(sentence, "([^0-9a-zA-Z]+|[0-9a-zA-Z]+)").ToList();
            wordList.RemoveAll(word => word == string.Empty);
            return wordList;
        }
    }
}
