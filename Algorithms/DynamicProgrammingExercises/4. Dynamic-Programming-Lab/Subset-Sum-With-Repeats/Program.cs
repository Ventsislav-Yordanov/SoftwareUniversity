namespace SubsetSumWithRepeats
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 6 };
            int targetSum = 6;
            bool[] possibleSums = CalculatePossibleSums(numbers, targetSum);
            int[] subset = FindSubset(numbers, targetSum, possibleSums);
            Console.WriteLine(string.Join(", ", subset));
        }

        private static bool[] CalculatePossibleSums(int[] numbers, int targetSum)
        {
            var possible = new bool[targetSum + 1];
            possible[0] = true;
            for (int sum = 0; sum < possible.Length; sum++)
            {
                if (possible[sum])
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        int newSum = sum + numbers[i];
                        if (newSum <= targetSum)
                        {
                            possible[newSum] = true;
                        }
                    }
                }
            }

            return possible;
        }

        private static int[] FindSubset(int[] numbers, int targetSum, bool[] possibleSums)
        {
            var subset = new List<int>();
            while (targetSum > 0)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    int newSum = targetSum - numbers[i];
                    if (newSum >= 0 && possibleSums[newSum])
                    {
                        targetSum = newSum;
                        subset.Add(numbers[i]);
                    }
                }
            }

            return subset.ToArray();
        }

    }
}
