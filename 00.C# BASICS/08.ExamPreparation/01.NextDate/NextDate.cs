using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NextDate
{
    static void Main()
    {
        int day = int.Parse(Console.ReadLine());
        int month = int.Parse(Console.ReadLine());
        int year = int.Parse(Console.ReadLine());

        CalculateNextDay(day, month, year);
    }

    private static void CalculateNextDay(int day, int month, int year)
    {
        DateTime currentDate = new DateTime(year, month, day);
        DateTime nextDate = currentDate.AddDays(1);
        Console.WriteLine("{0}.{1}.{2}", nextDate.Day, nextDate.Month , nextDate.Year);
    }
}