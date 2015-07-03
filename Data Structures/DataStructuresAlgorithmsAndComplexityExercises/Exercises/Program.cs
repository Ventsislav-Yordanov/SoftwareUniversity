namespace Exercises
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;

    public class Program
    {
        static void Main()
        {
            var startTime = DateTime.Now;
            int p = 1000000;
            for (int i = 0; i < p; i++)
            {
                IsPrimeFast(i);
            }
            var executionTime = DateTime.Now - startTime;
            Console.WriteLine("Execution time: {0}", executionTime);
        }

        // 01.
        // The worst case is when the number is maximum prime long number
        // The running time of the loop is directly proportional to (n-2)
        // O(n)

        // 02.
        // The best case is when the number is even number or equal to 1
        // The loop always exits on the first iteration or does not enter
        // O(1).

        static bool IsPrime(long num)
        {
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        // 03.
        // num = 9  => maxDivisor = 3 
        // num = 16 => maxDivisor = 4
        // num = 17 => maxDivisor = 4 
        // num = 18 => maxDivisor = 4
        // num = 25 => maxDivisor = 5
        // num = 36 => maxDivisor = 6
        // num = 37 => maxDivisor = 6
        // num = 49 => maxDivisor = 7
        // The worst case is when the loop is executed maximum number of times
        // The running time of the loop is directly proportional to (√n-2)
        // O(√n)

        static bool IsPrimeFast(long num)
        {
            int maxDivisor = (int)Math.Sqrt(num);
            for (int i = 2; i <= maxDivisor; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }

        // 04.
        // n = 10 => [2, 3, 5, 7, 11, 13, 17, 19, 23, 29]
        // n = 11 => [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31]
        // n = 12 => [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37]
        // n = 13 => [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41]
        // n = 14 => [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43]
        // https://en.wikipedia.org/wiki/Prime_number
        // The worst case is when the loop is executed maximum number of times.
        // O(nth prime number) -> loop. We can assume that O(nth prime number) ≈ O(n). See here: https://oeis.org/A000040/graph
        // O(√p) -> IsPrimeFast()

        // n = 5 => [2, 3, 5, 7, 11]

        // p = 2 : 1 time IsPrimeFast() loop
        // p = 3 : 1 time IsPrimeFast() loop

        // p = 4 : 2 times IsPrimeFast() loop
        // p = 5 : 2 times IsPrimeFast() loop
        // p = 6 : 2 times IsPrimeFast() loop
        // p = 7 : 2 times IsPrimeFast() loop
        // p = 8 : 2 times IsPrimeFast() loop

        // p = 9 : 3 times IsPrimeFast() loop
        // p = 10 : 3 times IsPrimeFast() loop
        // p = 11 : 3 times IsPrimeFast() loop
        // Total : O( n*√(last prime number) ) = O(n*√n)


        // 05.
        // The memory consumption is directly proportional to (n + 1)
        // O(n)


        static IEnumerable<long> FindFirstNPrimes(int n)
        {
            // -----------------------------------------------------------------
            Thread.MemoryBarrier();
            var initialMemory = System.GC.GetTotalMemory(true);
            // -----------------------------------------------------------------
            var primes = new long[n];
            long p = 2;
            int index = 0;
            while (primes.Length < n)
            {
                if (IsPrimeFast(p))
                {
                    primes[index++] = p;
                }
                p++;
            }
            // -----------------------------------------------------------------
            Thread.MemoryBarrier();
            var finalMemory = System.GC.GetTotalMemory(true);
            var consumption = finalMemory - initialMemory;
            Console.WriteLine(consumption);
            // -----------------------------------------------------------------
            return primes;
        }

        // 06.
        // (end-start) times -> The loop
        // O(√p) -> IsPrimeFast()
        // Total running time : O( (end-start) * √p ) = O( (end-start) * √(end-start) )

        static IList<int> FindPrimesInRange(int start, int end)
        {
            var primes = new List<int>();
            for (int p = start; p <= end; p++)
            {
                if (IsPrimeFast(p))
                {
                    primes.Add(p);
                }
            }
            return primes;
        }

        // 07.
        // ╔════════════════╦══════════════════╦══════════════════╦══════════════════╦══════════════════╦══════════════════╗
        // ║ Function       ║    p = 1 000     ║    p = 10 000    ║    p = 50 000    ║   p = 100 000    ║  p = 1 000 000   ║
        // ╠════════════════╬══════════════════╬══════════════════╬══════════════════╬══════════════════╬══════════════════╣
        // ║ IsPrime(p)     ║ 00:00:00.0020017 ║ 00:00:00.0750471 ║ 00:00:01.5410233 ║ 00:00:05.3515550 ║ hangs            ║
        // ║ IsPrimeFast(p) ║ 00:00:00.0010007 ║ 00:00:00.0020017 ║ 00:00:00.0170094 ║ 00:00:00.0420275 ║ 00:00:00.7254815 ║
        // ╚════════════════╩══════════════════╩══════════════════╩══════════════════╩══════════════════╩══════════════════╝
    }
}
