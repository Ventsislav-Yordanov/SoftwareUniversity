using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FirTree
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int hegiht = n;
        int width = 2 * n - 3;

        int stars = 1;
        int dots = width/2;
        for (int i = 0; i < hegiht - 1; i++)
        {
            string dotsString = new string('.', dots);
            string starsString = new string('*', stars);
            Console.WriteLine("{0}{1}{0}",dotsString, starsString);
            stars = stars + 2;
            dots = dots - 1;
        }

        string lastDotsString = new string('.', width / 2);
        string lastStarsString = new string('*', 1);
        Console.WriteLine("{0}{1}{0}", lastDotsString, lastStarsString);
    }
}