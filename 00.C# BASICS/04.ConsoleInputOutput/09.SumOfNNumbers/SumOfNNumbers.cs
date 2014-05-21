/*Write a program that enters a number n and after that enters more n numbers 
 * and calculates and prints their sum. Note that you may need to use a for-loop. */
using System;

    class SumOfNNumbers
    {
        static void Main()
        {
            Console.Write("Enter the number of integers : ");
            int numbers = Int32.Parse(Console.ReadLine());

            int sum = 0;

            for (int i = 0; i < numbers; i++)
            {
                Console.Write("Number{0} = ", i + 1);
                int num = Int32.Parse(Console.ReadLine());
                sum = sum + num;
            }

            Console.WriteLine("Sum = {0}",sum);
        }
    }