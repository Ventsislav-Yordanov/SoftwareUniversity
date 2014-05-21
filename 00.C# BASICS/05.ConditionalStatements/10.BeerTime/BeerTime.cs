/*A beer time is after 1:00 PM and before 3:00 AM. Write a program that enters a time in format “hh:mm tt”
 * (an hour in range [01...12], a minute in range [00…59] and AM / PM designator) and prints “beer time” or
 * “non-beer time” according to the definition above or “invalid time” if the time cannot be parsed.
 * Note that you may need to learn how to parse dates and times. */
using System;
using System.Globalization;
using System.Threading;

    class BeerTime
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Console.WriteLine(@"Please, enter your time in format ""hh:mm TT"",(example 05:30 PM)");
            Console.Write("YOUR TIME = ");
            string timeStr = Console.ReadLine();
            DateTime customTime;

            if (DateTime.TryParse(timeStr, out customTime))
            {
                Console.WriteLine("Converted '{0}' to {1}", timeStr, customTime);
            }
            else
            {
                Console.WriteLine("'{0}' is not in an acceptable format.", timeStr);
                Console.WriteLine("Error - Invalid Time !!!");
                return;
            }

            DateTime startBeerTime = DateTime.Parse("01:00 PM");
            DateTime endBeerTime = DateTime.Parse("03:00 AM");
            if ((customTime >= endBeerTime) && (customTime < startBeerTime))
            {
                Console.WriteLine("Now is NON-BEER TIME !");
            }
            else
            {
                Console.WriteLine("Now is BEER TIME !");
            }
        }
    }