/*Write a program that finds the biggest of three numbers. */
using System;

    class TheBiggestOf3Numbers
    {
        static void Main()
        {
            Console.Write("Enter first number : ");
            decimal firstNumber = Decimal.Parse(Console.ReadLine());
            Console.Write("Enter second number : ");
            decimal secondNumber = Decimal.Parse(Console.ReadLine());
            Console.Write("Enter third number : ");
            decimal thirdNumber = Decimal.Parse(Console.ReadLine());

            if (firstNumber > secondNumber )
            {
                if (firstNumber > thirdNumber)
                {
                    Console.WriteLine("Biggest : {0}",firstNumber);
                }
                else
                {
                    Console.WriteLine("Biggest : {0}", thirdNumber);
                }
            }
            else if (firstNumber < secondNumber)
            {
                if (secondNumber > thirdNumber)
                {
                    Console.WriteLine("Biggest : {0}", secondNumber);
                }
                else
                {
                    Console.WriteLine("Biggest : {0}", thirdNumber);
                }
            }
            else
            {
                if (firstNumber > thirdNumber)
                {
                    Console.WriteLine("Biggest : {0}", firstNumber);
                }
                else
                {
                    Console.WriteLine("Biggest : {0}", thirdNumber);
                }
            }
        }
    }