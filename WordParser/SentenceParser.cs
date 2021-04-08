﻿/*
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
            Words = Regex.Split(sentence, "([^0-9a-zA-Z]+)");
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
