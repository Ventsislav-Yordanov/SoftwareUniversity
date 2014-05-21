using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Carpets
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());

        for (int i = 1; i <= n / 2; i++) // i = rows
        {
            string filler = new string('.', n / 2 - i);
            Console.Write(filler);

            for (int j = 1; j <= i ; j++) // j = cols
            {
                if (j % 2 != 0) // if col % 2 != 0 , ако колоната е нечетна
                {
                    Console.Write("/");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            for (int j = 1; j <= i; j++)
            {
                if (i % 2 == 0) // if row % 2 == 0 , ако редът е четен ( 2,4,6...)
                {
                    if (j % 2 != 0) // ако колоната е нечетна ( 1,3,5...)
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("\\");
                    }
                }
                else // ако редът е нечетен ( 1,3,5...)
                {
                    if (j % 2 != 0) // ако колоната е нечетна ( 1,3,5...)
                    {
                        Console.Write("\\");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }

            Console.Write(filler);
            Console.WriteLine();
        }

        // second part
        int counter = 0;

        for (int i = n / 2; i >= 1; i--) // i = rows
        {
            string filler = new string('.', counter);
            Console.Write(filler);

            for (int j = 1; j <= i; j++) // j = cols
            {
                if (j % 2 != 0) // ако колоната е нечетна
                {
                    Console.Write("\\");
                }
                else
                {
                    Console.Write(" ");
                }
            }

            for (int j = 1; j <= i; j++)
            {
                if (i % 2 == 0) // ако редът е четен
                {
                    if (j % 2 != 0) // ако колоната е нечетна
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("/");
                    }
                }
                else
                {
                    if (j % 2 == 0) // ако колоната е четна
                    {
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.Write("/");
                    }
                }
            }

            Console.Write(filler);
            Console.WriteLine();
            counter++;
        }
    }
}