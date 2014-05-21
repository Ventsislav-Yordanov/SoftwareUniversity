// Write a program to read your age from the console and print how old you will be after 10 years.

using System;

class DateAfter10Years
{
    static void Main()
    {
        Console.Write("Write your Birthday (date.month.year): ");
        DateTime YourBirthDay = DateTime.Parse(Console.ReadLine());
        DateTime TimeNow = DateTime.Today;

        int CurrentAge = TimeNow.Year - YourBirthDay.Year;

        if (TimeNow.Month < YourBirthDay.Month)
        {
                Console.WriteLine("After 10 years you will be {0}", CurrentAge + 9);
        }
        else if (TimeNow.Month == YourBirthDay.Month)
        {
            if (TimeNow.Day > YourBirthDay.Day)
            {
                Console.WriteLine("After 10 years you will be {0}", CurrentAge + 9);
            }
            else if (TimeNow.Day <= YourBirthDay.Day)
            {
                Console.WriteLine("After 10 years you will be {0}", CurrentAge + 10);
            }
        }
        else
        {
            Console.WriteLine("After then years you will be {0}", CurrentAge + 10);
        }
    }
}