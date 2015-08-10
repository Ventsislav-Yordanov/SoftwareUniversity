namespace CountSymbols
{
    using System;
    using System.Linq;

    using Dictionary;

    class CountSymbols
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var characters = input.ToCharArray();

            var charactersCount = new Dictionary<char, int>();
            foreach (var character in characters)
            {
                if (charactersCount.ContainsKey(character))
                {
                    charactersCount[character]++;
                }
                else
                {
                    charactersCount[character] = 1;
                }
            }

            var alphabeticalOrdered = charactersCount.OrderBy(pair => pair.Key);
            
            foreach (var pair in alphabeticalOrdered)
            {
                Console.WriteLine("{0}: {1} time/s", pair.Key, pair.Value);
            }
        }
    }
}
