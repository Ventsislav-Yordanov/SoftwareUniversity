/*Write a program that enters two dates in format dd.MM.yyyy and returns the number of days between them. */
using System;

    class DifferenceBetweenDates
    {
        static void Main()
        {
            Console.Write("Enter first date : ");
            DateTime firstDateInput = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter second date : ");
            DateTime secondDateInput = DateTime.Parse(Console.ReadLine());
            int different = DifferenceDates(firstDateInput, secondDateInput);
            Console.WriteLine(different);
        }

        static int DifferenceDates(DateTime firstDate, DateTime secondDate)
        {
            return (int)(secondDate - firstDate).TotalDays;
        }
    }