namespace PermutationsWithoutRepetitionIteratively
{
    using System;
    using System.Linq;

    public class IterativePermutationsGenerator
    {
        public static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            var numbers = Enumerable.Range(1, n).ToArray();
            int permutationsCount = 1;
            // create an integer array helperArray[] of size N + 1 to control the iteration
            var helperArray = Enumerable.Range(0, n + 1).ToArray();
            int firstIndex = 1;
            Console.WriteLine(string.Join(", ", numbers));

            while (firstIndex < n)
            {
                helperArray[firstIndex]--;
                int secondIndex = 0;
                if (firstIndex % 2 != 0)
                {
                    secondIndex = helperArray[firstIndex];
                }

                Swap(numbers, firstIndex, secondIndex);
                firstIndex = 1;
                while (helperArray[firstIndex] == 0)
                {
                    helperArray[firstIndex] = firstIndex;
                    firstIndex++;
                }

                Console.WriteLine(string.Join(", ", numbers));
                permutationsCount++;
            }

            Console.WriteLine("Total permutations: {0}", permutationsCount);
        }

        private static void Swap(int[] array, int firstIndex, int secondIndex)
        {
            int oldValue = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = oldValue;
        }
    }
}
