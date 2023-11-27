using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordParser
{
    /// <summary>
    /// Parses words by replacing alhpanumeric characters between the beginning and last character with the count of distinct characters replaced.
    /// </summary>
    public class ParsedWord
    {
        private string Word;
        private bool IsAlphaNumeric;
        private char? FirstLetter;
        private char? LastLetter;
        private int DistinctBetweenLetterCount;

        /// <summary>
        /// Converts a string word into a parsed word.
        /// </summary>
        /// <param name="word">Word to be parsed</param>
        public ParsedWord(string word)
        {
            ParseWord(word);
        }

        /// <summary>
        /// Gets the value of a parsed word as a string.
        /// </summary>
        /// <returns>String value of the parsed word</returns>
        override public string ToString()
        {
            return IsAlphaNumeric ? $"{FirstLetter}{DistinctBetweenLetterCount}{LastLetter}" : Word;
        }

        /// <summary>
        /// Parses an alphanumeric word.
        /// </summary>
        public void ParseWord(string word)
        {
            Word = word;
            IsAlphaNumeric = Regex.IsMatch(Word, "[0-9a-zA-Z]+");
            bool isSpecial = Regex.IsMatch(Word, "[^0-9a-zA-Z]+");

            if (IsAlphaNumeric && isSpecial)
            {
                throw new NotImplementedException($"Cannot parse word \"{word}\". Words must not contain both alphanumeric and special characters.");
            }

            if (IsAlphaNumeric)
            {
                FirstLetter = word[0];
                LastLetter = word[word.Length - 1];
                DistinctBetweenLetterCount = GetDistinctCountBetween(word);
            }
        }

        public int GetDistinctCountBetween(string word)
        {
            return word.Length == 1 ? 0 : word.Substring(1, word.Length - 2).Distinct().Count();
        }
    }
}
