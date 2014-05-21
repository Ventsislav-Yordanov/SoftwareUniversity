/*Write a program that reads the coefficients a, b and c of a quadratic equation ax2 + bx + c = 0
 * and solves it (prints its real roots).
 * Examples:
 a	        b	    c	    roots
2	        5	    -3	    x1=-3; x2=0.5
-1	        3	    0	    x1=3; x2=0
-0.5        4	    -8	    x1=x2=4
5	        2	    8	    no real roots
*/
using System;

    class QuadraticEquation
    {
        static void Main()
        {
            Console.WriteLine("axx + bx + c = 0     D = b*b - 4ac");
            Console.WriteLine();
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());

            Console.WriteLine();

            double des = (b * b) - (4 * a * c);
            if (des < 0)
            {
                Console.WriteLine("There is no real roots.");
            }
            if (des > 0)
            {
                Console.Write("X1 = {0} , ", (-b - Math.Sqrt(des)) / (2 * a));
                Console.WriteLine("X2 = {0}", (-b + Math.Sqrt(des)) / (2 * a));
            }
            if (des == 0)
            {
                Console.WriteLine("X1 = X2 = {0}", -b / (2 * a));
            }
        }
    }