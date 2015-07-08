namespace LongestSubsequence
{
    using System;
    using System.Linq;
    using System.Collections.Generic;


    class Program
    {
        static void Main()
        {
            //var numbers = new List<int>() { 12, 2, 7, 4, 3, 3, 8 };            
            //var numbers = new List<int>() { 1, 2, 3 };
            var numbers = new List<int>() { 2, 2, 2, 3, 3, 3 };

            var longestSubsequence = FindLongerstSubsequence(numbers);
            foreach (var item in longestSubsequence)
            {
                Console.Write("{0} ", item);
            }
        }

        static List<int> FindLongerstSubsequence(List<int> source)
        {
            var mostCommonElement = source[0];
            var bestCount = 1;

            var count = 1;
            var currentElement = source[0];

            for (int i = 1; i < source.Count; i++)
            {
                if (currentElement == source[i])
                {
                    count++;
                    if (count > bestCount)
                    {
                        bestCount = count;
                        mostCommonElement = source[i];
                    }
                }
                else
                {
                    count = 1;
                    currentElement = source[i];
                }
            }

            var mostCommonNumberList = Enumerable.Repeat(mostCommonElement, bestCount).ToList();
            return mostCommonNumberList;
        }
    }
}
