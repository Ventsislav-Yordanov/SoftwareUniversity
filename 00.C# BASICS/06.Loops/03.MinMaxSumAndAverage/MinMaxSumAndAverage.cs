/*Write a program that reads from the console a sequence of n integer numbers and returns the minimal,
 * the maximal number, the sum and the average of all numbers (displayed with 2 digits after the decimal point).
 * The input starts by the number n (alone in a line) followed by n lines, each holding an integer number.
 * The output is like in the examples below.*/
using System;
using System.Collections.Generic;

    class MinMaxSumAndAverage
    {
        static void Main()
        {
            Console.Write("Enter length of loop: ");
            int length = int.Parse(Console.ReadLine());

            int min = int.MaxValue;
            int max = int.MinValue;
            double sum = 0;
            double average = 0;

            for (int i = 0; i < length; i++)
            {
                Console.Write("Enter number#{0} = ",i+1);
                int number = int.Parse(Console.ReadLine());

                //min
                min = Math.Min(min, number);

                //max
                max = Math.Max(max, number);

                //sum
                sum += number;

                //average
                average = sum / length;
            }

            Console.WriteLine("Min = " + min);
            Console.WriteLine("Max = " + max);
            Console.WriteLine("Sum = " + sum);
            Console.WriteLine("Avg = {0:F2}", average);
        }
    }