namespace CombinationsWithoutRepetitionIteratively
{
    using System;
    using System.Collections.Generic;

    public class CombinationsGenerator
    {
        static void Main()
        {
            // Source: http://rosettacode.org/wiki/Combinations#C.23
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter k: ");
            int k = int.Parse(Console.ReadLine());
            var allCombinations = GenerateCombinations(k, n);
            foreach (int[] c in allCombinations)
            {
                for (int i = 0; i < c.Length; i++)
                {
                    Console.Write(c[i] + 1 + " ");
                }

                Console.WriteLine();
            }
        }

        public static IEnumerable<int[]> GenerateCombinations(int k, int n)
        {
            int[] result = new int[k];
            Stack<int> stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();

                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == k)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }
    }
}
