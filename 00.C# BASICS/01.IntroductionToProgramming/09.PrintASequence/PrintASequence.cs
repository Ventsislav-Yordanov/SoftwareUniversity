// Write a program that prints the first 10 members of the sequence: 2, -3, 4, -5, 6, -7, ...
using System;

class PrintASequence
{
    static void Main()
    {
        int a = 2;
        int b = -3;

        for (int i = 0; i < 10; i = i + 2) // i = i + 2 because the program print 2 numbers while i < 10
        {
            Console.WriteLine("{0} {1}", a, b);
            a = a + 2;
            b = b - 2;
        }

        //second variant 

        //for (int i = 2; i <= 11; i++) // Минаваме през числата от 2 до 11 ( включително ).
        //{
        //    if (i % 2 == 0)
        //    {
        //        Console.WriteLine(i); // проверяваме дали числото е четно, ако да го печатаме
        //    }
        //    else
        //    {
        //        Console.WriteLine(-i); // ако не е - печатаме числото със знак минус 
        //    }
        //}
    }
}