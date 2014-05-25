using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class WorkHours
{
    static void Main()
    {
        int hours = Int32.Parse(Console.ReadLine());
        int days = Int32.Parse(Console.ReadLine());
        int productivityInPercent = Int32.Parse(Console.ReadLine());

        decimal bikeTime = days * 0.1m;
        decimal workTime = (days - bikeTime) * 12m;
        decimal productivity = productivityInPercent / 100m;
        workTime = workTime * productivity;


        decimal difference = (int)workTime - (int)hours;
        if (workTime < hours)
        {
            Console.WriteLine("No");
            Console.WriteLine((int)difference);
        }
        else
        {
            Console.WriteLine("Yes");
            Console.WriteLine((int)difference);
        }
    }
}