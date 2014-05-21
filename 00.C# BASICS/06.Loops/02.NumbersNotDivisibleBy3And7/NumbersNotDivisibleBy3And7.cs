/*Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n
 * not divisible by 3 and 7, on a single line, separated by a space.*/
using System;

    class NumbersNotDivisibleBy3And7
    {
        static void Main()
        {
            Console.Write("Enter number : ");
            int number = Int32.Parse(Console.ReadLine());

            Console.Write("Numbers from 1 to n not divisible by 3 and 7 : ");

            for (int i = 1; i <= number; i++)
            {
                if (i % 3 != 0)
                {
                    if (i % 7 != 0)
                    {
                        Console.Write("{0} ", i);
                    }
                }
            }
            Console.WriteLine();
        }
    }