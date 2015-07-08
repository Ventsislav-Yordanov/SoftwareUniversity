namespace CountOfOccurences
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    class Program
    {

        static void Main()
        {
            var inputNumbers = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            var stopwatch = new Stopwatch();
   
            // First solution
            stopwatch.Start();
            var groups = inputNumbers.GroupBy(i => i).OrderBy(x => x.Key);
            foreach (var group in groups)
            {
                Console.WriteLine("{0} -> {1} times", group.Key, group.Count());
            }
            stopwatch.Stop();
            Console.WriteLine("Elapsed Milliseconds using GroupBy: {0:0000}", stopwatch.ElapsedMilliseconds);

            Console.WriteLine(new string('-', 20));

            // Second solution
            stopwatch.Start();
            var occurrences = new SortedDictionary<int, int>();

            foreach (var number in inputNumbers)
            {
                if (!occurrences.ContainsKey(number))
                {
                    occurrences[number] = 1;
                }
                else
                {
                    occurrences[number]++;
                }
            }

            foreach (var oc in occurrences)
            {
                Console.WriteLine("{0} -> {1} times", oc.Key, oc.Value);
            }
            stopwatch.Stop();
            Console.WriteLine("Elapsed Milliseconds using SortedDictionary: {0:0000}", stopwatch.ElapsedMilliseconds);
        }
    }
}
