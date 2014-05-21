using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Eggcelent
{
    static void Main()
    {
        int number = Int32.Parse(Console.ReadLine());

        int height = 2 * number;
        int width = (3 * number) - 1;
        int widthDraw = (3 * number) + 1;
        int top = number - 1;
        int bottom = number - 1;

        //top
        Console.WriteLine("{0}{1}{0}",new string('.',number + 1),new string('*', top));

        int outerDots = number - 1;
        int innerDots = number + 1;
        int counter = 0;

        for (int i = 0; i < height - number - 2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}",new string('.', outerDots),new string('.', innerDots));
            innerDots = innerDots + 4;
            outerDots = outerDots - 2;
            if (outerDots < 0)
            {
                outerDots = 1;
                counter++;
            }
            if (innerDots > width)
            {
                innerDots = width - 2;
            }
        }

        //middle
        Console.Write(".*");
        for (int i = 0; i < width/2; i++)
        {
            Console.Write("@");
            if (i > width/2 - 2)
            {
                break;
            }
            Console.Write(".");
        }
        Console.WriteLine("*."); 
        Console.Write(".*");

        for (int i = 0; i < width / 2; i++)
        {
            Console.Write(".");
            if (i > width / 2 - 2)
            {
                break;
            }
            Console.Write("@");
        }
        Console.WriteLine("*.");

        //bottom

        int innerDots2 = 1;
        int outerDots2 = width - 2;

        for (int i = 0; i < height - number - 2; i++)
        {
            Console.WriteLine("{0}*{1}*{0}",new string('.', innerDots2),new string('.', outerDots2));
            if (counter - 1 > i)
            {
                innerDots2 = widthDraw - width - 1;
                outerDots2 = width - 2;
            }
            else
            {
                innerDots2 = innerDots2 + 2;
                outerDots2 = outerDots2 - 4;
            }
        }
        Console.WriteLine("{0}{1}{0}",new string('.',number + 1), new string('*',bottom));
    }
}