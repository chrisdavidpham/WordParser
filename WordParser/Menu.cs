using System;

namespace WordParser
{
    public class Menu
    {
        public Menu() { }

        /// <summary>
        /// Starts an interactive menu in the console.
        /// </summary>
        public void OpenInteractiveMenu()
        {
            SentenceParser sentenceParser = new SentenceParser();
            string input = string.Empty;
            
            while (input != "q")
            {
                Console.WriteLine("\nEnter a sentence to be parsed, or \"q\" to quit: ");
                input = Console.ReadLine();

                Console.WriteLine(sentenceParser.ParseWords(input));
            }

            Console.WriteLine("Goodbye.");
        }
    }
}
