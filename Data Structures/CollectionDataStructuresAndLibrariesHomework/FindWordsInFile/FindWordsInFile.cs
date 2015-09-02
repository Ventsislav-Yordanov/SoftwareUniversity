namespace FindWordsInFile
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FindWordsInFile
    {
        public static void Main()
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            var text = new StringBuilder();
            for (int i = 0; i < numberOfRows; i++)
            {
                string line = Console.ReadLine();
                text.AppendLine(line);
            }

            var wordsCount = new Dictionary<string, int>();
            string[] separators = new string[] { " ", ",", ".", "!", "?", ":", ";", Environment.NewLine };
            var words = text.ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (!wordsCount.ContainsKey(word))
                {
                    wordsCount[word] = 1;
                }
                else
                {
                    wordsCount[word]++;
                }
            }

            int numberOfSearchedWords = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfSearchedWords; i++)
            {
                string searchedWord = Console.ReadLine();
                if (!wordsCount.ContainsKey(searchedWord))
                {
                    Console.WriteLine("The word isn't in the text.");
                }
                else
                {
                    Console.WriteLine("{0} -> {1}", searchedWord, wordsCount[searchedWord]);
                }
            }
        }
    }
}
