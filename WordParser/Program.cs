/* 
 * Author: Chris Pham
 * Email : chris@samspham.com
 * 
 * Problem Description
 * 
 * Write a program that parses a sentence and replaces each word with the following:
 * first letter, number of distinct characters between first and last character, and last letter. For example, Smooth would become S3h.
 * Words are separated by spaces or non-alphabetic characters and these separators should be maintained in their original form and location in the answer.
 */

using System;
using System.Text;

namespace WordParser
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menuOption;
            bool repeatInput = true;
            string input;
            string currentWord;
            string parsedSentence;
            SentenceParser sentenceParser;
            StringBuilder stringBuilder = new StringBuilder();

            while(repeatInput)
            {
                menuOption = true;
                Console.WriteLine("Enter a sentence to be parsed: ");
                input = Console.ReadLine();

                sentenceParser = new SentenceParser(input);
                currentWord = sentenceParser.GetNextWord();

                while (!string.IsNullOrEmpty(currentWord))
                {
                    var currentWordParsed = new ParsedWord(currentWord);
                    stringBuilder.Append(currentWordParsed);
                    currentWord = sentenceParser.GetNextWord();
                }

                parsedSentence = stringBuilder.ToString();
                Console.WriteLine(parsedSentence);
                stringBuilder.Clear();

                while (menuOption)
                {
                    Console.WriteLine("\nSelect an option: \"q\" - quit; \"c\" - continue parsing more sentences");
                    input       = Console.ReadLine().TrimEnd();
                    repeatInput = input == "c";
                    menuOption  = input != "c" && input != "q";
                }
            }

            Console.WriteLine("Goodbye.");
        }
    }
}
