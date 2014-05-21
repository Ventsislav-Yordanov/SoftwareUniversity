using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class UKFlag
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());
        int height = n;
        int width = n;

        int dotsBetween = n / 2 - 1;

        for (int i = 0; i < height / 2; i++)
        {
            string dotsBeforeAndAfter = new string('.', i);
            string dotsBetweenSTtring = new string('.', dotsBetween);
            Console.WriteLine("{0}\\{1}|{1}/{0}", dotsBeforeAndAfter, dotsBetweenSTtring);
            dotsBetween = dotsBetween - 1;
        }

        //middle
        int dashes = width / 2;
        string dasheshString = new string('-', dashes);
        Console.WriteLine("{0}*{0}", dasheshString);


        dotsBetween = dotsBetween + 1;
        for (int i = height / 2 - 1; i >= 0; i--)
        {
            string dotsBeforeAndAfter = new string('.', i);
            string dotsBetweenSTtring = new string('.', dotsBetween);
            Console.WriteLine("{0}/{1}|{1}\\{0}", dotsBeforeAndAfter, dotsBetweenSTtring);
            dotsBetween = dotsBetween + 1;
        }
    }
}