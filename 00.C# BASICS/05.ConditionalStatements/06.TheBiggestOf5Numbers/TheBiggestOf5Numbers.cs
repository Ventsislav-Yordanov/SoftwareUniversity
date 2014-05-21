/*Write a program that finds the biggest of five numbers by using only five if statements. */
using System;

    class TheBiggestOf5Numbers
    {
        static void Main()
        {
            Console.Write("Enter 1st number : ");
            decimal a = Decimal.Parse(Console.ReadLine());
            Console.Write("Enter 2nd number : ");
            decimal b = Decimal.Parse(Console.ReadLine());
            Console.Write("Enter 3rd number : ");
            decimal c = Decimal.Parse(Console.ReadLine());
            Console.Write("Enter 4th number : ");
            decimal d = Decimal.Parse(Console.ReadLine());
            Console.Write("Enter 5th number : ");
            decimal e = Decimal.Parse(Console.ReadLine());

            decimal theBiggest;

            if (a >= b)
            {
                theBiggest = a;
            }
            else
            {
                theBiggest = b;
            }
            if (c >= theBiggest)
            {
                theBiggest = c;
            }
            if (d >= theBiggest)
            {
                theBiggest = d;
            }
            if (e >= theBiggest)
            {
                theBiggest = e;
            }
            Console.WriteLine("The Biggest from these 5 numbers is THE BIGGEST = {0} !",theBiggest);
        }
    }
