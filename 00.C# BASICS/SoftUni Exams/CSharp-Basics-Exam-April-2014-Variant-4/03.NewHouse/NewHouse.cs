using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NewHouse
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());

        int stars = 1;
        int dashes = n / 2;

        for (int i = 0; i < n / 2 + 1; i++)
        {
            Console.Write(new string('-',dashes));
            Console.Write(new string('*', stars));
            Console.Write(new string('-', dashes));
            Console.WriteLine();

            dashes--;
            stars += 2;
        }

        stars = 0; //reset
        stars = n - 2;

        for (int i = n; i > 0; i--)
        {
            Console.Write("|");
            Console.Write(new string('*', stars));
            Console.Write("|");
            Console.WriteLine();
        }
    }
}