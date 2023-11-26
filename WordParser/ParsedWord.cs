using System.Collections.Generic;
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

        public ParsedWord(string word)
        {
            ParseWord(word);
        }

        override public string ToString()
        {
            return IsAlphaNumeric ? $"{FirstLetter}{DistinctBetweenLetterCount}{LastLetter}" : Word;
        }

        public void ParseWord(string word)
        {
            Word = word;
            IsAlphaNumeric = Regex.IsMatch(Word, "[0-9a-zA-Z]+");

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
