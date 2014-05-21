/*Write a program that reads from the console a positive integer number n (1 ≤ n ≤ 20)
 * and prints a matrix like in the examples below. Use two nested loops.
 Examples: https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx */
using System;

    class MatrixOfNumbers
    {
        static void Main()
        {
            int n;
            string input;

            do
            {
                Console.Write("Enter N : ");
                input = Console.ReadLine();
            }
            while (!(int.TryParse(input, out n) && (n < 21) && (n > 0)));

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j <= n + i; j++)
                {
                    Console.Write(j + " ");
                }

                Console.WriteLine();
            }
        }
    }