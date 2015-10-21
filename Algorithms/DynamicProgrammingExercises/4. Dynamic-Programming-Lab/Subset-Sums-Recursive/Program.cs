using System;
using System.Collections.Generic;

namespace SubsetSumsRecursive
{
    public class Program
    {
        static int[] numbers = { 5, 5, 15, 20, 1 };
        static int sum = 26;
        static bool[,] possibleSum = new bool[numbers.Length, sum + 1];
        static bool[,] isCalculated = new bool[numbers.Length, sum + 1];

        static void Main()
        {
            bool possibleSum = CalculatePossibleSums(numbers.Length - 1, sum);
            if (possibleSum)
            {
                PrintSubset(numbers.Length - 1, sum);
            }
            else
            {
                Console.WriteLine("Not possible!");
            }
        }

        private static bool CalculatePossibleSums(int i, int sum)
        {
            if (sum < 0 || i < 0)
            {
                return false;
            }

            if (!isCalculated[i, sum])
            {
                possibleSum[i, sum] =
                    (numbers[i] == sum) ||
                    CalculatePossibleSums(i - 1, sum) ||
                    CalculatePossibleSums(i - 1, sum - numbers[i]);
                isCalculated[i, sum] = true;
            }

            return possibleSum[i, sum];
        }

        private static void PrintSubset(int i, int sum)
        {
            Console.Write(sum + " = ");
            var subset = new List<int>();
            while (true)
            {
                if (numbers[i] == sum)
                {
                    // Take the last sum
                    subset.Add(numbers[i]);
                    break;
                }
                else if (CalculatePossibleSums(i - 1, sum - numbers[i]))
                {
                    // Take arr[i]
                    subset.Add(numbers[i]);
                    sum = sum - numbers[i];
                    i = i - 1;
                }
                else if (CalculatePossibleSums(i - 1, sum))
                {
                    // Skip arr[i]
                    i = i - 1;
                }
            }
            Console.WriteLine(string.Join(" + ", subset));
        }
    }
}
