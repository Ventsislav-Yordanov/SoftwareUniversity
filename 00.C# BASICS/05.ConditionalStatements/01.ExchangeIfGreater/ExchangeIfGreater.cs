/*Write an if-statement that takes two integer variables a and b and exchanges their values if
 * the first one is greater than the second one. As a result print the values a and b,
 * separated by a space. */
using System;

    class ExchangeIfGreater
    {
        static void Main()
        {
            Console.Write("Enter first number : ");
            decimal firstNumber = Decimal.Parse(Console.ReadLine());
            Console.Write("Enter second number : ");
            decimal secondNumber = Decimal.Parse(Console.ReadLine());

            if (firstNumber > secondNumber)
            {
                firstNumber = firstNumber + secondNumber;  // a = 5 , b = 10 //   a + b = 15
                secondNumber = firstNumber - secondNumber;                   // b = 15 - 10 = 5              
                firstNumber = firstNumber - secondNumber;                    // a = 15 - 5 = 10
            }
            Console.WriteLine("First number = {0}",firstNumber);
            Console.WriteLine("Second number = {0}",secondNumber);
        }
    }