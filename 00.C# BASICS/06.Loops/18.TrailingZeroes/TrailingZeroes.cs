/*Write a program that calculates with how many zeroes the factorial of a given number n has at its end.
 * Your program should work well for very big numbers, e.g. n=100000. */
using System;
using System.Numerics;

    class TrailingZeroes
    {
        static void Main()
        {
            Console.Write("Enter n : ");
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = 1;
            

            for (int i = 1; i <= n; i++)
            {
                factorial = factorial * i;
            }
            string factorialString = factorial.ToString();

            int counter = 0;

            for (int i = factorialString.Length - 1 ; i >= 0; i--)
            {
                if (factorialString[i] == '0')
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("trailing zeroes of n! : {0}",counter);
            Console.WriteLine("explaination : {0}",factorial);
        }
    }