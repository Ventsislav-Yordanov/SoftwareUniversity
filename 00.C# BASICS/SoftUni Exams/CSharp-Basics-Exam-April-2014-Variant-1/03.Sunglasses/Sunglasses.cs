using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Sunglasses
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());

        // print first row
        Console.Write(new string('*', n * 2));
        Console.Write(new string(' ', n));
        Console.Write(new string('*', n * 2));
        Console.WriteLine();


        //print middle
        for (int i = 0; i < n - 2; i++)
        {
            Console.Write('*');
            Console.Write(new string('/', (n * 2) - 2));
            Console.Write('*');

            //print frame
            if (i == (n-2)/2)
	        {
	        	Console.Write(new string('|', n));
	        }
            else
            {
                Console.Write(new string(' ', n));
            }

            Console.Write('*');
            Console.Write(new string('/', (n * 2) - 2));
            Console.Write('*');
            Console.WriteLine();
        }

        // print last row
        Console.Write(new string('*', n * 2));
        Console.Write(new string(' ', n));
        Console.Write(new string('*', n * 2));
    }
}