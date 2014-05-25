using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class House
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());

        //print first row
        Console.Write(new string('.', n / 2));
        Console.Write("*");
        Console.Write(new string('.', n / 2));
        Console.WriteLine();

        int dotsBeforeAndAfter = n / 2 - 1;
        int dotsBetween = 1;

        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.Write(new string('.', dotsBeforeAndAfter));
            Console.Write("*");
            Console.Write(new string('.', dotsBetween));
            Console.Write("*");
            Console.Write(new string('.', dotsBeforeAndAfter));
            Console.WriteLine();

            dotsBetween += 2;
            dotsBeforeAndAfter--;
        }

        Console.WriteLine(new string('*', n));

        dotsBeforeAndAfter = n / 4;

        for (int i = n / 2 - 1; i > 0; i--)
        {
            Console.Write(new string('.', dotsBeforeAndAfter));
            Console.Write("*");
            Console.Write(new string('.', n - (2*dotsBeforeAndAfter + 2)));
            Console.Write("*");
            Console.Write(new string('.', dotsBeforeAndAfter));
            Console.WriteLine();
        }

        //print last row
        Console.Write(new string('.', dotsBeforeAndAfter));
        Console.Write(new string('*', n - 2*dotsBeforeAndAfter));
        Console.Write(new string('.', dotsBeforeAndAfter));
    }
}
