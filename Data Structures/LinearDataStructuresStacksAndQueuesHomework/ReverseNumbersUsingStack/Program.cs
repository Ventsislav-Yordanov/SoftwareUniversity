namespace ReverseNumbersUsingStack
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var numberAsStringArray = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numberAsIntArray = Array.ConvertAll(numberAsStringArray, s => int.Parse(s));
            Stack<int> numbers = new Stack<int>(numberAsIntArray);

            if (numbers.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                foreach (var number in numbers)
                {
                    Console.Write("{0} ", number);
                }
            }

        }
    }
}
