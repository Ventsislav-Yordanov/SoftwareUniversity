/*Write a program that calculates the greatest common divisor (GCD) of given two integers a and b.
 * Use the Euclidean algorithm (find it in Internet). */
using System;

    class CalculateGCD
    {
        static void Main()
        {
            Console.Write("a = ");
            int a = Int32.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = Int32.Parse(Console.ReadLine());

            int c = 0;

            while (b != 0)
            {
                c = b;
                b = a % b;
                a = c;
            }
            Console.WriteLine("GCD(a, b) : {0}",a);
        }
    }