namespace BinomialCoefficients
{
    using System;
    using System.Diagnostics;

    public class BinomialCoefficients
    {
        public static void Main()
        {
            // Source: https://en.wikipedia.org/wiki/Binomial_coefficient
            Console.Write("Please enter n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Please enter k: ");
            int k = int.Parse(Console.ReadLine());

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Recursive call");
            var binomialCoefficent = GetBinomialCoefficentRecursive(n, k);
            Console.WriteLine("The binomial coefficent is: {0}", binomialCoefficent);
            Console.WriteLine("Elaplsed time in miliseconds: {0}", stopwatch.ElapsedMilliseconds);
            stopwatch.Stop();
            stopwatch.Start();
            Console.WriteLine("Iteratively call");
            binomialCoefficent = GetBinomialCoefficentIteratively(n, k);
            Console.WriteLine("The binomial coefficent is: {0}", binomialCoefficent);
            Console.WriteLine("Elaplsed time in miliseconds: {0}", stopwatch.ElapsedMilliseconds);
        }

        private static int GetBinomialCoefficentRecursive(int n, int k)
        {
            var binomialCoefficents = new int[n + 1, k + 1];

            if (k < 0 || k > n)
            {
                return 0;
            }

            if (k > n - k)
            {
                k = n - k;
            }

            if (k == 0 || n <= 1)
            {
                return 1;
            }

            if (binomialCoefficents[n, k] == 0)
            {
                binomialCoefficents[n, k] = GetBinomialCoefficentRecursive(n - 1, k) + GetBinomialCoefficentRecursive(n - 1, k - 1);
            }

            return binomialCoefficents[n, k];
        }

        private static int GetBinomialCoefficentIteratively(int n, int k)
        {
            var binomialCoefficents = new int[n + 1, k + 1];

            if (k < 0 || k > n)
            {
                return 0;
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            if (binomialCoefficents[n, k] == 0)
            {
                k = Math.Min(k, n - k);
                int binomialCoefficent = 1;
                for (int i = 0; i < k; i++)
                {
                    binomialCoefficent = binomialCoefficent * (n - i) / (i + 1);
                }

                binomialCoefficents[n, k] = binomialCoefficent;
            }

            return binomialCoefficents[n, k];
        }
    }
}
