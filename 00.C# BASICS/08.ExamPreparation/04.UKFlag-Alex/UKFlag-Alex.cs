using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Telerik.UKFlag
{
    class UKFLAG
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int height = n;
            int width = n;
            char symbol = '|';
            char symbol1 = '\\';
            char symbol2 = '/';
            char dot = '.';
            char dash = '-';
            char star = '*';

            int symbolsOnRow = width;
            int dotsOnRow = symbolsOnRow - 3;
            int dotsBeforeAndAfter = 0;
            int innerDots = (dotsOnRow - dotsBeforeAndAfter) / 2;

            do
            {
                string dotsOutside = new string(dot, dotsBeforeAndAfter);
                string dotsInside = new string(dot, innerDots);
                string row = dotsOutside + symbol1 + dotsInside + symbol + dotsInside + symbol2 + dotsOutside;
                Console.WriteLine(row);
                dotsBeforeAndAfter++;
                innerDots--;
            } while (innerDots >= 0);


            int dashesOnRow = symbolsOnRow - 1;
            string dashes = new string(dash, dashesOnRow / 2);
            Console.WriteLine(dashes + star + dashes);


            do
            {
                dotsBeforeAndAfter--;
                innerDots++;
                string dotsOutside = new string(dot, dotsBeforeAndAfter);
                string dotsInside = new string(dot, innerDots);
                string row = dotsOutside + symbol2 + dotsInside + symbol + dotsInside + symbol1 + dotsOutside;
                Console.WriteLine(row);
            }
            while (dotsBeforeAndAfter > 0);
        }
    }
}