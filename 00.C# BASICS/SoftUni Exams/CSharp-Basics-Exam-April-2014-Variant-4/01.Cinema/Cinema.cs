using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Cinema
{
    static void Main()
    {
        string type = Console.ReadLine();
        int rows = Int32.Parse(Console.ReadLine());
        int columns = Int32.Parse(Console.ReadLine());

        int people = rows * columns;

        decimal money = 0;

        if (type == "Premiere")
        {
            money = people * 12m;
        }
        else if (type == "Normal")
        {
            money = people * 7.50m;
        }
        else if (type == "Discount")
        {
            money = people * 5m;
        }

        Console.WriteLine("{0:0.00} leva",money);
    }
}