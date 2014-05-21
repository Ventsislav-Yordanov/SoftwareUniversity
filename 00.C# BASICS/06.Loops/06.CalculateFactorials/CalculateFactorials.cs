/*Write a program that calculates n! / k! for given n and k (1 < k < n < 100). Use only one loop.
 Note : first enter number K and then number N  */
using System;

    class CalculateFactorials
    {
        static void Main()
        {
            int n;
            int k;
            string input;

            do
            {
                Console.Write("Enter K : ");
                input = Console.ReadLine();
            } while (!(int.TryParse(input, out k) && (1 < k)));

            do
            {
                Console.Write("Enter N : ");
                input = Console.ReadLine();
            }
            while (!(int.TryParse(input, out n) && (n > k) && (n < 100)));

            ulong factorialN = 1;
            ulong factorialK = 1;

            for (int i = 1; i <= n; i++)
            {
                factorialN = factorialN * (ulong)i;
                if (i <= k)
                {
                    factorialK = factorialK * (ulong)i;
                }
            }

            Console.WriteLine("{0}! / {1}! = {2}", n, k, factorialN/factorialK);
        }
    }