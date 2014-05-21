/*Write an expression that calculates trapezoid's area by given sides a and b and height h. */
using System;

    class Trapezoids
    {
        static void Main()
        {
            Console.Write("Enter a : ");
            double a = Double.Parse(Console.ReadLine());
            Console.Write("Enter b : ");
            double b = Double.Parse(Console.ReadLine());
            Console.Write("Enter h : ");
            double h = Double.Parse(Console.ReadLine());

            Console.WriteLine("Area : {0}", (a+b) / 2 * h);
        }
    }