namespace RemoveOddOccurences
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            //var input = new List<int>() { 1, 2, 3, 4, 1 };
            //var input = new List<int>() { 1, 2, 3, 4, 5, 3, 6, 7, 6, 7, 6 };            
            //var input = new List<int>() { 1, 2, 1, 2, 1, 2 };
            var input = new List<int>() { 3, 7, 3, 3, 4, 3, 4, 3, 7 };
            //var input = new List<int>() { 1, 1 };

            var set = new HashSet<int>();
            foreach (var number in input)
            {
                if (!set.Contains(number))
                {
                    set.Add(number);
                }
                else
                {
                    set.Remove(number);
                }
            }

            var output = new List<int>();
            foreach (var element in input)
            {
                if (!set.Contains(element))
                {
                    output.Add(element);
                }
            }

            Console.WriteLine(string.Join(", ", output));
        }
    }
}
