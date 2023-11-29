using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordParser
{
    /// <summary>
    /// Parses words by replacing characters between the beginning and last character with the count of distinct characters replaced.
    /// </summary>
    public class DistinctCountBetweenWord
    {
        private string Word;
        private bool IsParsable { get { return Regex.IsMatch(Word, "[0-9a-zA-Z]{2,}"); } }
        private char? FirstLetter;
        private char? LastLetter;
        private int DistinctBetweenLetterCount;

        /// <summary>
        /// Converts a string word into a parsed word.
        /// </summary>
        /// <param name="word">Word to be parsed</param>
        public DistinctCountBetweenWord(string word)
        {
            Parse(word);
        }

        /// <summary>
        /// Gets the value of a parsed word as a string.
        /// </summary>
        /// <returns>String value of the parsed word</returns>
        override public string ToString()
        {
            return IsParsable ? $"{FirstLetter}{DistinctBetweenLetterCount}{LastLetter}" : Word;
        }

        /// <summary>
        /// Parses a word if it contains at least two alphanumeric characters and no special characters.
        /// </summary>
        public void Parse(string word)
        {
            Word = word ?? string.Empty;

            if (IsParsable)
            {
                bool containsSpecialCharacters = Regex.IsMatch(Word, "[^0-9a-zA-Z]+");
                if (containsSpecialCharacters)
                {
                    throw new NotImplementedException($"Invalid word \"{word}\". Alphanumeric words must not contain special characters.");
                }

                FirstLetter = word[0];
                LastLetter = word[word.Length - 1];
                DistinctBetweenLetterCount = GetDistinctCountBetween(word);
            }
        }

        /// <summary>
        /// Counts the distinct number of characters between the first and last character of a word.
        /// </summary>
        /// <param name="word"></param>
        /// <returns>Distinct character count</returns>
        private int GetDistinctCountBetween(string word)
        {
            return word.Length == 1 ? 0 : word.Substring(1, word.Length - 2).Distinct().Count();
        }
    }
}
