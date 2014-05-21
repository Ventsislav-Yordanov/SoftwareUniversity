/*Condition : https://softuni.bg/downloads/svn/csharp-basics/Feb-2014/6.%20Loops-Homework.docx */

using System;
using System.Numerics;

    class CatalanNumbers
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
            while (!(int.TryParse(input, out n) && (n < 100) && (n > 1)));

            BigInteger factN = 1;
            BigInteger plusFactN = 1;
            BigInteger multiFactN = 1;
            BigInteger result = 0;

            for (int i = 1; i <= n; i++)
            {
                factN = factN * i;
            }

            for (int j = 1; j <= n + 1; j++)
            {
                plusFactN = plusFactN * j;
            }

            for (int k = 1; k <= 2 * n; k++)
            {
                multiFactN = multiFactN * k;
            }

            result = multiFactN / (plusFactN * factN);
            Console.WriteLine("Catalan({0}) = {1}", n, result);
        }
    }