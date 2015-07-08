namespace SortWords
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var wordsAsString = Console.ReadLine();
            var words = wordsAsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var wordsDesc = words.OrderBy(x => x);

            List<string> wordsList = new List<string>(wordsDesc);
            foreach (var word in wordsList)
            {
                Console.WriteLine(word);
            }
        }
    }
}
