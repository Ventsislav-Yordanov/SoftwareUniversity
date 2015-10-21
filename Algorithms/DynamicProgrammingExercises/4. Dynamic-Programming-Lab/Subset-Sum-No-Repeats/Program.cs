namespace Subset_Sum_No_Repeats
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            int[] numbers = { 3, 2, 2, 77, 89, 23, 90, 11 };
            int targetSum = 91;
            var possibleSums = CalculatePossibleSums(numbers, targetSum);
            var sequence = RecoverSequence(numbers, targetSum, possibleSums);
            Console.WriteLine(string.Join(", ", sequence));
        }

        private static IDictionary<int, int> CalculatePossibleSums(int[] numbers, int targetSum)
        {
            var possibleSums = new Dictionary<int, int>();
            possibleSums.Add(0, 0);

            for (int i = 0; i < numbers.Length; i++)
            {
                var newSums = new Dictionary<int, int>();
                foreach (var sum in possibleSums.Keys)
                {
                    int newSum = sum + numbers[i];
                    if (!possibleSums.ContainsKey(newSum))
                    {
                        newSums.Add(newSum, numbers[i]);
                    }
                }

                foreach (var sum in newSums)
                {
                    possibleSums.Add(sum.Key, sum.Value);
                }
            }


            return possibleSums;
        }

        private static int[] RecoverSequence(int[] numbers, int targetSum, IDictionary<int, int> possibleSums)
        {
            var subset = new List<int>();
            while (targetSum > 0)
            {
                int lastNumber = possibleSums[targetSum];
                subset.Add(lastNumber);
                targetSum -= lastNumber;
            }

            subset.Reverse();
            return subset.ToArray();

        }
    }
}
