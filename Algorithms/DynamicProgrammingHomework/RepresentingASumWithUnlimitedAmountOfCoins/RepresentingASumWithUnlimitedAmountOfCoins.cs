namespace RepresentingASumWithUnlimitedAmountOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepresentingASumWithUnlimitedAmountOfCoins
    {
        private static HashSet<List<int>> uniqueSubsequences = new HashSet<List<int>>(new ListComparer());
        private static int uniqueSubsequencesCount = 0;

        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            //var numbers = new List<int>() { 1, 2, 5, 10, 20, 50, 100 };
            int target = 100;
            SumUp(numbers, target);
            Console.WriteLine("The combinations are: ");
            foreach (var item in uniqueSubsequences)
            {
                Console.WriteLine(string.Join(", ", item));
                uniqueSubsequencesCount++;
            }
            Console.WriteLine("Count: {0}", uniqueSubsequencesCount);
        }

        private static void SumUp(List<int> numbers, int target)
        {
            SumUpRecursive(numbers, target, new List<int>());
        }

        private static void SumUpRecursive(List<int> numbers, int target, List<int> partial)
        {
            int sum = partial.Sum();

            if (sum == target)
            {
                uniqueSubsequences.Add(partial);
            }

            if (sum >= target)
            {
                return;
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                List<int> remaining = new List<int>();
                for (int j = i; j < numbers.Count; j++)
                {
                    remaining.Add(numbers[j]);
                }

                List<int> partialRecursive = new List<int>(partial);
                partialRecursive.Add(numbers[i]);
                SumUpRecursive(remaining, target, partialRecursive);
            }
        }
    }
}
