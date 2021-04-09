/*
 * This static class provides the method to replace a word using parse rules described in the problem statement.
 */

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordParser
{
    public struct Word
    {
        public char first;
        public char last;
        public string distinct;

        public string ToParsedString() => $"{first}{distinct.Length}{last}";
    }

    public static class WordParser
    {
        public static string ParseWord(string word)
        {
            if (Regex.IsMatch(word, "[^0-9a-zA-Z]+") || string.IsNullOrEmpty(word))
            {
                return word;
            }

            Word parsedWord     = new Word();
            int wordLastIndex   = word.Length - 1;
            parsedWord.first    = word[0];
            parsedWord.last     = word[wordLastIndex];
            parsedWord.distinct = GetDistinctBetween(word);

            string parsedString = parsedWord.ToParsedString();
            return parsedString;
        }

        public static string GetDistinctBetween(string word)
        {
            if (word.Length <= 2)
            {
                return string.Empty;
            }
            char[] characters   = word.ToCharArray();
            int lastIndex = characters.Length - 1;
            string between      = new string(characters[1..lastIndex]);
            string distinct     = string.Concat(between.Distinct());
            return distinct;
        }
    }
}
