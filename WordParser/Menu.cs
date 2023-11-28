using System;

namespace WordParser
{
    public class Menu
    {
        public Menu() { }

        public void OpenInteractiveMenu()
        {
            SentenceParser sentenceParser = new SentenceParser();
            bool repeatInput = true;

            while (repeatInput)
            {
                var menuOption = true;
                Console.WriteLine("Enter a sentence to be parsed: ");
                var input = Console.ReadLine();

                Console.WriteLine(sentenceParser.ParseWords(input));

                while (menuOption)
                {
                    Console.WriteLine("\nSelect an option: \"q\" - quit; \"c\" - continue parsing more sentences");
                    input = Console.ReadLine().TrimEnd();
                    repeatInput = input == "c";
                    menuOption = input != "c" && input != "q";
                }
            }

            Console.WriteLine("Goodbye.");
        }
    }
}
