namespace VariationsWithoutRepetition
{
    using System;

    public class VariationsGenerator
    {
        public static void Main()
        {
            Console.Write("Please enter n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Please enter k: ");
            int k = int.Parse(Console.ReadLine());
            var elements = new int[k];
            var usedElements = new bool[n + 1];
            Console.WriteLine("Result: ");
            GenerateVariations(elements, n, usedElements);
        }

        private static void GenerateVariations(int[] array, int sizeOfSet, bool[] used, int index = 0)
        {
            if (index >= array.Length)
            {
                Print(array);
            }
            else
            {
                for (int i = 1; i <= sizeOfSet; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        array[index] = i;
                        GenerateVariations(array, sizeOfSet, used, index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
