/*Condition : https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx */
using System;
using System.Numerics;

    class CalculateFactorials2
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

            BigInteger factorialN = 1;
            BigInteger factorialK = 1;
            BigInteger factorialNandK = 1;

            for (int i = 1; i <= n; i++)
            {
                factorialN = factorialN * i;
                if (i <= k)
                {
                    factorialK = factorialK * i;
                }
                if (i <= (n - k))
                {
                    factorialNandK = factorialNandK * i;
                }
            }

            BigInteger result = factorialN / (factorialK * factorialNandK);
            Console.WriteLine("{0} / {1} * ({0}-{1})! = {2}", n, k, result);
        }
    }