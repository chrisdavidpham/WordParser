using System;
using System.Linq;

namespace WordParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var sentenceParser = new SentenceParser();

            if (args.Contains("-i"))
            {
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
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine(sentenceParser.ParseWords(args[i]));
                }
            }
        }
    }
}
