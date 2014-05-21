/*Write a program that reads 3 integer numbers from the console and prints their sum. */
using System;

    class SumOf3Integers
    {
        static void Main()
        {
            Console.Write("Enter number 1 : ");
            decimal number1 = Decimal.Parse(Console.ReadLine());
            Console.Write("Enter number 2 : ");
            decimal number2 = Decimal.Parse(Console.ReadLine());
            Console.Write("Enter number 3 : ");
            decimal number3 = Decimal.Parse(Console.ReadLine());

            var sum = number1 + number2 + number3;

            Console.WriteLine("{0} + {1} + {2} = {3}", number1, number2, number3, sum );
        }
    }