/*Write a program that reads two positive integer numbers and prints how many numbers p exist
 * between them such that the reminder of the division by 5 is 0. */
using System;

    class DividableByGivenNumber
    {
        static void Main()
        {
            Console.Write("Enter start : ");
            int start = Int32.Parse(Console.ReadLine());
            Console.Write("Enter end : ");
            int end = Int32.Parse(Console.ReadLine());
            int count = 0;

            Console.Write("Comments : ");
            for (int i = start; i <= end; i++)
            {
                int divider = i % 5;

                if (divider == 0)
                {
                    count = count + 1;
                    Console.Write("{0} ", i);
                }
            }
            Console.WriteLine();
            Console.WriteLine("P : {0}",count);

        }
    }