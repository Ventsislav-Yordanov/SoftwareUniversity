namespace PermutationsWithoutRepetition
{
    using System;
    using System.Linq;

    public class PermutationsGenerator
    {
        private static int permutationsCount;

        public static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            var numbers = Enumerable.Range(1, n).ToArray();
            GeneratePermutations(numbers, 0);
            Console.WriteLine("Total permutations: {0}", permutationsCount);
        }

        private static void GeneratePermutations<T>(T[] array, int k)
        {
            if (k >= array.Length)
            {
                Print(array);
                permutationsCount++;
            }
            else
            {
                GeneratePermutations(array, k + 1);
                for (int i = k + 1; i < array.Length; i++)
                {
                    Swap(ref array[k], ref array[i]);
                    GeneratePermutations(array, k + 1);
                    Swap(ref array[k], ref array[i]);
                }
            }
        }

        private static void Print<T>(T[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            T oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}
