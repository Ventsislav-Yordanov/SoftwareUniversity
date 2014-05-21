/*Write a program that enters in integer n and prints the numbers 1, 2, …, n in random order. */
using System;

    class RandomizeTheNumbers
    {
        static void Main()
        {
            Console.Write("Enter n: ");
            int n = int.Parse(Console.ReadLine());
            bool[] printed = new bool[n + 1];
            Random randomNum = new Random();
            int numberToPrint;
            for (int i = 1; i <= n; i++)
            {
                numberToPrint = randomNum.Next(1, n + 1);
                if (!printed[numberToPrint])
                {
                    Console.Write(numberToPrint + " ");
                    printed[numberToPrint] = true;
                }
                else
                {
                    i--;
                }
            }
        }
    }