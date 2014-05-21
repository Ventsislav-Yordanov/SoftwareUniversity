/*Write a program that enters from the console a positive integer n and prints all the numbers from 1 to n,
 * on a single line, separated by a space.*/
using System;

    class NumbersFrom1ToN
    {
        static void Main()
        {
            Console.Write("Enter number : ");
            int number = Int32.Parse(Console.ReadLine());

            Console.Write("All numbers from 1 to n : ");

            for (int i = 1; i <= number; i++)
            {
                Console.Write("{0} ",i);
            }
            Console.WriteLine();
        }
    }