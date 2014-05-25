using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Eclipse
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());

        // print 1st row
        Console.Write(" ");
        Console.Write(new string('*', 2*n - 2));
        Console.Write(" ");
        Console.Write(new string(' ', n - 1));
        Console.Write(" ");
        Console.Write(new string('*', 2 * n - 2));
        Console.Write(" ");
        Console.WriteLine();

        for (int row = 0; row < n - 2; row++)
        {
            if (row == n / 2 - 1)
            {
                Console.Write("*");
                Console.Write(new string('/', 2 * n - 2));
                Console.Write("*");
                Console.Write(new string('-', n - 1));
                Console.Write("*");
                Console.Write(new string('/', 2 * n - 2));
                Console.Write("*");
                Console.WriteLine();
            }
            else
            {
                Console.Write("*");
                Console.Write(new string('/', 2 * n - 2));
                Console.Write("*");
                Console.Write(new string(' ', n - 1));
                Console.Write("*");
                Console.Write(new string('/', 2 * n - 2));
                Console.Write("*");
                Console.WriteLine();
            }
        }

        // print last row
        Console.Write(" ");
        Console.Write(new string('*', 2 * n - 2));
        Console.Write(" ");
        Console.Write(new string(' ', n - 1));
        Console.Write(" ");
        Console.Write(new string('*', 2 * n - 2));
        Console.Write(" ");
    }
}