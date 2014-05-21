/*Write a program that gets two numbers from the console and prints the greater of them.
 * Try to implement this without if statements. */
using System;

    class NumberComparer
    {
        static void Main()
        {
            Console.Write("Enter first number : ");
            decimal number1 = Decimal.Parse(Console.ReadLine());
            Console.Write("Enter second number : ");
            decimal number2 = Decimal.Parse(Console.ReadLine());

            if (number1 > number2)
            {
                Console.WriteLine("Geater number is : {0}",number1);
            }
            else if (number1 < number2)
            {
                Console.WriteLine("Geater number is : {0}",number2);
            }
            else
            {
                Console.WriteLine("The numbers are equal !");
            }
        }
    }