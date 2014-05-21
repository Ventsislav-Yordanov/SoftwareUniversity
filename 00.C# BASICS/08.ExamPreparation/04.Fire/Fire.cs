using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Fire
{
    static void Main()
    {
        int fireWidth = Int32.Parse(Console.ReadLine());
        int sideDots = (fireWidth - 2) / 2;
        int middleDots = 0;

        for (int i = sideDots; i >= 0; i--)
        {
            Console.Write(new string('.', i));
            Console.Write(new string('#', 1));
            Console.Write(new string('.', middleDots));
            Console.Write(new string('#', 1));
            Console.Write(new string('.', i));
            Console.WriteLine();

            middleDots += 2;
        }

        middleDots = fireWidth - 2;

        for (int i = 0; i < fireWidth / 4; i++)
        {
            Console.Write(new string('.', i));
            Console.Write(new string('#', 1));
            Console.Write(new string('.', middleDots));
            Console.Write(new string('#', 1));
            Console.Write(new string('.', i));
            Console.WriteLine();

            middleDots -= 2;
        }

        Console.WriteLine(new string('-', fireWidth));

        int middleSlashes = fireWidth / 2;

        for (int i = 0; i < fireWidth / 2; i++)
        {
            Console.Write(new string('.', i));
            Console.Write(new string('\\', middleSlashes));
            Console.Write(new string('/', middleSlashes));
            Console.Write(new string('.', i));
            Console.WriteLine();

            middleSlashes--;
        }
    }
}