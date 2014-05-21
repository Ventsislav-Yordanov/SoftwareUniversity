using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class TribonacciTriangle
{
    static void Main()
    {
        long trib1 = long.Parse(Console.ReadLine());
        long trib2 = long.Parse(Console.ReadLine());
        long trib3 = long.Parse(Console.ReadLine());
        long numberOfLines = long.Parse(Console.ReadLine());

        long tribNew = 0;

        Console.WriteLine(trib1);
        Console.WriteLine("{0} {1}",trib2, trib3);

        if (numberOfLines <= 2)
        {
            return;
        }

        for (long row = 2; row < numberOfLines; row++)
        {
            for (long col = 0; col <= row; col++)
            {
                tribNew = trib1 + trib2 + trib3;

                //if (col == row) // този if е за да не печата празно място след последният tribNew
                //{
                //    Console.Write(tribNew);
                //    trib1 = trib2;
                //    trib2 = trib3;
                //    trib3 = tribNew;
                //    break;
                //}

                Console.Write("{0} ", tribNew);
                trib1 = trib2;
                trib2 = trib3;
                trib3 = tribNew;
            }

            Console.WriteLine();
        }
    }
}