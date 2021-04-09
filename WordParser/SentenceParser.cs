/*
 * This class takes a string and splits it into an array of strings divided by special characters.
 * Each word or consecutive delimiters in the original string can be accessed using the GetNextWord method.
 * An empty string is returned after all words have been accessed, indicating the end of the sentence.
 */

using System;
using System.Text.RegularExpressions;

namespace WordParser
{
    public class SentenceParser
    {
        string[] Words;
        int CurrentIndex;

        public SentenceParser(string sentence)
        {
            CurrentIndex = 0;
            // This regex will split by any special character but not apostrophes that are surrounded by non-special characters, and keep the delimiters
            sentence = Regex.Replace(sentence, "(?<=[0-9a-zA-Z])+'(?=[0-9a-zA-Z])", string.Empty);
            Words = Regex.Split(sentence, "([^0-9a-zA-Z]+)");

            // If the first character of the sentence is a special character, the split introduces an empty string as the first split element.
            // Remove the first element if it is empty.
            if (Words.Length > 0 && string.Equals(Words[0], string.Empty))
            {
                Words = Words[1..Words.Length];
            }
        }

        private string GetWord(int index)
        {
            if (index >= Words.Length || index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            return Words[index];
        }

        public string GetNextWord()
        {
            string word = CurrentIndex >= Words.Length ? string.Empty : Words[CurrentIndex];
            CurrentIndex++;
            return word;
        }
    }
}
