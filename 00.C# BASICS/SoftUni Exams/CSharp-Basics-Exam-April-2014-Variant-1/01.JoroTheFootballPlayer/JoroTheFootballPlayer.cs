using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class JoroTheFootballPlayer
{
    static void Main()
    {
        string isLeapYear = Console.ReadLine();
        int hollidaysCount = Int32.Parse(Console.ReadLine());
        int weekendsHomeCount = Int32.Parse(Console.ReadLine());

        const int totalWeekendsInYear = 52;

        int normalWeekends = totalWeekendsInYear - weekendsHomeCount;

        double gamesCount = normalWeekends * 2d / 3d + weekendsHomeCount * 1d + hollidaysCount / 2d;

        if (isLeapYear == "t")
	    {
	    	 gamesCount = gamesCount + 3;
	    }
        Console.WriteLine((int)gamesCount);
    }
}