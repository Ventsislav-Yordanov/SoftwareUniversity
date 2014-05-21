/*Write a program that enters 3 integers n, min and max (min ≤ max) and prints n random numbers
 * in the range [min...max]. */
using System;

    class RandomNumbersInGivenRange
    {
        static void Main()
        {
            Console.Write("n = ");
            int n = Int32.Parse(Console.ReadLine());
            Console.Write("min = ");
            int min = Int32.Parse(Console.ReadLine());
            Console.Write("max = ");
            int max = Int32.Parse(Console.ReadLine());

            if (min <= max)
            {
                Random random = new Random();

                for (int i = 1; i <= n; i++)
                {
                    Console.Write("{0} ", random.Next(min, max));
                }
            }
            else
            {
                Console.WriteLine("Invalid input !");
            }
        }
    }