/**/
using System;

    class NumbersFrom1ToN
    {
        static void Main()
        {
            Console.Write("Enter number : ");
            int number = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Number from 1 to {0} : ",number);
            for (int i = 1; i <= number; i++)
            {
                Console.WriteLine(i);
            }
        }
    }