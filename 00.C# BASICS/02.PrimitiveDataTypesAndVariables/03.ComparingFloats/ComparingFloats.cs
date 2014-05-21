/*Write a program that safely compares floating-point numbers with precision eps = 0.000001.
 * Note that we cannot directly compare two floating-point numbers a and b by a==b because 
 * of the nature of the floating-point arithmetic.
 * Therefore, we assume two numbers are equal if they are more closely to each other than a fixed constant eps.
 * Examples: http://s29.postimg.org/pujed3yvb/problem_3.jpg */
using System;

    class ComparingFloats
    {
        static void Main()
        {
            Console.Write("Enter the first number: ");
            decimal firstNumber = decimal.Parse(Console.ReadLine());
            Console.Write("Enter the second number: ");
            decimal secondNumber = decimal.Parse(Console.ReadLine());
            decimal difference = Math.Abs(firstNumber - secondNumber);
            decimal eps = Math.Abs(0.000001m);
            bool comparing = (Math.Abs(firstNumber - secondNumber) < 0.000001m);

            Console.WriteLine();
            Console.WriteLine("Equal (with precision eps=0.000001) : {0}",comparing);

            if (difference > eps)
            {
                Console.WriteLine("The difference of {0} is too big (> eps)",difference);
            }
            else if (difference < eps)
            {
                Console.WriteLine("The difference {0} < eps",difference);
            }
            else
            {
                Console.WriteLine("Border case. The difference 0.000001 == eps.");
                Console.WriteLine("We consider the numbers are different.");
            }
        }
    }

