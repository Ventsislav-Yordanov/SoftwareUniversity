using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class WineGlass
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());

        int stars = n - 2;

        // print first row
        Console.Write("\\");
        Console.Write(new string('*', stars));
        Console.Write("/");
        Console.WriteLine();

        stars -= 2;
        int dots = 1;

        for (int i = 0; i < n / 2 - 1; i++)
        {
            Console.Write(new string('.', dots));
            Console.Write("\\");
            Console.Write(new string('*', stars));
            Console.Write("/");
            Console.Write(new string('.', dots));
            Console.WriteLine();

            stars -= 2;
            dots++;
        }

        dots--; //reset

        int RowsCount = 0;

        if (n >= 12)
        {
            RowsCount = (n / 2) - 2;
        }
        else
        {
            RowsCount = (n / 2) - 1;
        }

        for (int i = RowsCount; i > 0; i--)
        {
            Console.Write(new string('.', dots));
            Console.Write("||");
            Console.Write(new string('.', dots));
            Console.WriteLine();
        }

        int height = n;
        int dashes = height - (n / 2 + RowsCount); // calculate rows of dashes

        // print dashes
        for (int i = 0; i < dashes; i++)
        {
            Console.Write(new string('-', n));
            Console.WriteLine();
        }
    }
}