namespace CombinationsWithRepetition
{
    using System;

    public class CombinationsGenerator
    {
        public static void Main()
        {
            Console.Write("Please enter k: ");
            int k = int.Parse(Console.ReadLine());
            Console.Write("Please enter n: ");
            int n = int.Parse(Console.ReadLine());
            var elements = new int[k];
            Console.WriteLine("Result: ");
            GenerateCombinations(elements, n, 0);
        }

        private static void GenerateCombinations(int[] array, int sizeOfSet, int index, int start = 1)
        {
            if (index >= array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = start; i <= sizeOfSet; i++)
                {
                    array[index] = i;
                    GenerateCombinations(array, sizeOfSet, index + 1, i);
                }
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
