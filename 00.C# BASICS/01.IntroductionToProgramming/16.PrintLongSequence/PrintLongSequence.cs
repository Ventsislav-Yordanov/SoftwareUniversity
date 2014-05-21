/*Write a program that prints the first 1000 members of the sequence: 2, -3, 4, -5, 6, -7, … 
 * You might need to learn how to use loops (search in Internet).   */
using System;

class PrintASequence
{
    static void Main()
    {
        int a = 2;
        int b = -3;
        Console.BufferHeight = 505;

        for (int i = 0; i < 1000; i = i + 2)
        {
            Console.WriteLine("{0} {1}", a, b);
            a = a + 2;
            b = b - 2;
        }

        //second variant 

        //Console.BufferHeight = 1010;

        //for (int i = 2; i <= 1001; i++) // Минаваме през числата от 2 до 1001 ( включително ).
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