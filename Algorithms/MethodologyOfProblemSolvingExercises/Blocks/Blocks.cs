namespace Blocks
{
    using System;
    using System.Collections.Generic;

    public class Blocks
    {
        private static readonly HashSet<string> UsedCombinations = new HashSet<string>();
        private const int LettersToChoose = 4;

        public static void Main(string[] args)
        {
            // First Solution
            //int numberOfLetters = int.Parse(Console.ReadLine());
            //var results = FindBlocks(numberOfLetters);
            //PrintBlocks(results);

            // Second Solution
            int numberOfLetters = int.Parse(Console.ReadLine());
            var numberOfBlocks = (numberOfLetters - 3) * (numberOfLetters - 2) * (numberOfLetters - 1) * numberOfLetters / 4;
            Console.WriteLine($"Number of blocks: {numberOfBlocks}");
            int counter = 0;
            var lastLetter = 'A' + numberOfLetters - 1;
            for (char l1 = 'A'; l1 <= lastLetter; l1++)
            {
                for (char l2 = (char)(l1 + 1); l2 <= lastLetter; l2++)
                {
                    for (char l3 = (char)(l1 + 1); l3 <= lastLetter; l3++)
                    {
                        if (l3 != l2)
                        {
                            for (char l4 = (char)(l1 + 1); l4 <= lastLetter; l4++)
                            {
                                if (l4 != l3 && l4 != l2)
                                {
                                    counter++;
                                    Console.WriteLine($"{l1}{l2}{l3}{l4}");
                                }
                            }
                        }
                    }
                }
            }
        }

        public static HashSet<string> FindBlocks(int numberOfLetters)
        {
            var letters = new char[numberOfLetters];
            FillLetters(numberOfLetters, letters);

            var used = new bool[numberOfLetters];
            var currentCombination = new char[LettersToChoose];
            var results = new HashSet<string>();

            GenerateVariations(letters, currentCombination, used, results);

            return results;
        }

        private static void FillLetters(int numberOfLetters, char[] letters)
        {
            for (int i = 0; i < numberOfLetters; i++)
            {
                letters[i] = (char)('A' + i);
            }
        }

        private static void GenerateVariations(
            char[] letters,
            char[] currentCombination,
            bool[] used,
            HashSet<string> results,
            int index = 0)
        {
            if (index >= currentCombination.Length)
            {
                AddResult(currentCombination, results);
            }
            else
            {
                for (int i = 0; i < letters.Length; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        currentCombination[index] = letters[i];
                        GenerateVariations(letters, currentCombination, used, results, index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void AddResult(char[] result, HashSet<string> results)
        {
            string currentCombination = new string(result);
            if (!UsedCombinations.Contains(currentCombination))
            {
                results.Add(currentCombination);

                UsedCombinations.Add(currentCombination);
                UsedCombinations.Add(new string(new[] { result[2], result[0], result[3], result[1] }));
                UsedCombinations.Add(new string(new[] { result[3], result[2], result[1], result[0] }));
                UsedCombinations.Add(new string(new[] { result[1], result[3], result[0], result[2] }));
            }
        }

        private static void PrintBlocks(HashSet<string> results)
        {
            Console.WriteLine("Number of blocks: {0}", results.Count);
            foreach (var combination in results)
            {
                Console.WriteLine(combination);
            }
        }
    }
}