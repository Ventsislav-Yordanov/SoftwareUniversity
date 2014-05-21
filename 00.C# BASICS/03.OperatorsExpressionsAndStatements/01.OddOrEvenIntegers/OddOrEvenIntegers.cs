/*Write an expression that checks if given integer is odd or even. */
using System;

    class OddOrEvenIntegers
    {
        static void Main()
        {
            Console.Write("Enter number : ");
            int number = Int32.Parse(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine("The number is even");
            }
            else
            {
                Console.WriteLine("The number is odd");
            }
        }
    }