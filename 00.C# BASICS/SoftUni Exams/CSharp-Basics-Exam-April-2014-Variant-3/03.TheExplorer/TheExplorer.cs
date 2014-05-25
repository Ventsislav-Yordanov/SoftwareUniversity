using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TheExplorer
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());

        int underscoresBeforeAndAfter = n / 2;

        // print first row
        Console.Write(new string('-', underscoresBeforeAndAfter));
        Console.Write("*");
        Console.Write(new string('-', underscoresBeforeAndAfter));

        underscoresBeforeAndAfter--;
        Console.WriteLine();

        int underscoresBetween = 1;

        for (int i = 0; i < n / 2; i++)
        {
            Console.Write(new string('-', underscoresBeforeAndAfter));
            Console.Write("*");
            Console.Write(new string('-', underscoresBetween));
            Console.Write("*");
            Console.Write(new string('-', underscoresBeforeAndAfter));
            Console.WriteLine();

            underscoresBetween += 2;
            underscoresBeforeAndAfter--;
        }

        underscoresBetween -= 4;        //undo 2 process
        underscoresBeforeAndAfter +=2;  //undo 2 process

        for (int i = n /2 - 1; i > 0; i--)
        {
            Console.Write(new string('-', underscoresBeforeAndAfter));
            Console.Write("*");
            Console.Write(new string('-', underscoresBetween));
            Console.Write("*");
            Console.Write(new string('-', underscoresBeforeAndAfter));
            Console.WriteLine();

            underscoresBetween -= 2;
            underscoresBeforeAndAfter++;
        }

        // print last row
        Console.Write(new string('-', underscoresBeforeAndAfter));
        Console.Write("*");
        Console.Write(new string('-', underscoresBeforeAndAfter));
    }
}