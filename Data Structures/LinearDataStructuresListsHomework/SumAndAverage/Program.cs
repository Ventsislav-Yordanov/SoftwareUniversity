namespace SumAndAverage
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            int total = 0;
            double average = 0;

            var numbersAsString = Console.ReadLine();
            if (numbersAsString != null && numbersAsString != string.Empty)
            {
                var numbers = numbersAsString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                int[] numbersAsIntegers = Array.ConvertAll(numbers, int.Parse);
                List<int> list = new List<int>(numbersAsIntegers) { };
                total = list.Sum();
                average = (double)total / list.Count;
            }

            Console.WriteLine("Sum : {0}", total);
            Console.WriteLine("Average : {0:F2}", average);
        }
    }
}
