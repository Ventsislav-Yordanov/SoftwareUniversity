// Create a console application that prints the current date and time. Find in Internet how.
using System;

class CurrentDateAndTime
{
    static void Main()
    {
        Console.WriteLine("Date and time now : ");
        DateTime dateAndTimeNow = DateTime.Now;
        Console.WriteLine(dateAndTimeNow);
    }
}