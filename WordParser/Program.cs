using System;

namespace WordParser
{
    class Program
    {
        static void Main(string[] args)
        {
            var sentenceParser = new SentenceParser();

            if (args.Length == 1 && args[0] == "-i")
            {
                new Menu().OpenInteractiveMenu();
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
