using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Volleyball
{
    static void Main()
    {
        string leapOrNormal = Console.ReadLine();
        int numberOfHolidays = Int32.Parse(Console.ReadLine());
        int weekendsHometown = Int32.Parse(Console.ReadLine());

        const int totalWeekends = 48;

        int normalWeekends = totalWeekends - weekendsHometown;

        double plays = normalWeekends * 3 / 4d;
        double holidaysPlays = numberOfHolidays * 2 / 3d;
        double totalPlays = holidaysPlays + plays;

        totalPlays += weekendsHometown;

        if (leapOrNormal == "leap")
        {
            totalPlays += totalPlays * 0.15;
        }
        
        Console.WriteLine((int)totalPlays);
    }
}