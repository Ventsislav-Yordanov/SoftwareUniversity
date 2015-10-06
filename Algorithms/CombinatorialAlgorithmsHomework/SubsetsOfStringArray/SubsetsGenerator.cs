namespace SubsetsOfStringArray
{
    using System;
    using System.Linq;

    public class SubsetsGenerator
    {
        static string[] objects;
        static int[] currentSubset;

        public static void Main()
        {
            Console.Write("Please enter strings separated by space for the set: ");
            objects = Console.ReadLine().Split(' ');
            Console.Write("Please enter the number of elements in a subset: ");
            int k = int.Parse(Console.ReadLine());
            currentSubset = new int[k];
            GenerateCombinationsNoRepetitions(0, 0);
        }

        private static void GenerateCombinationsNoRepetitions(int index, int start)
        {
            if (index >= currentSubset.Length)
            {
                PrintCombinations();
            }
            else
            {
                for (int i = start; i < objects.Length; i++)
                {
                    currentSubset[index] = i;
                    GenerateCombinationsNoRepetitions(index + 1, i + 1);
                }
            }
        }

        private static void PrintCombinations()
        {
            Console.WriteLine("({0})", string.Join(" ", currentSubset.Select(i => objects[i])));
        }
    }
}
