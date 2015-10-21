namespace BinomialCoefficients
{
    using System;

    public class BinomialCoefficients
    {
        public static void Main()
        {
            // Source: https://en.wikipedia.org/wiki/Binomial_coefficient
            Console.Write("Please enter n: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Please enter k: ");
            int k = int.Parse(Console.ReadLine());

            var binomialCoefficent = GetBinomialCoefficent(n, k);
            Console.WriteLine("The binomial coefficent is: {0}", binomialCoefficent);
        }

        private static int GetBinomialCoefficent(int n, int k)
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
