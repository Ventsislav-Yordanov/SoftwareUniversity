//namespace CheckPrimeWorstCase
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Diagnostics;

//    public class Program
//    {
//        static void Main()
//        {
//            var sw = new Stopwatch();
//            for (int number = 0; number < 85; number++)
//            {
//                sw.Start();
//                FindFirstNPrimes(number);
//                sw.Stop();
//                Console.WriteLine(sw.Elapsed);
//            }
//        }
//        static bool IsPrimeFast(long num)
//        {
//            int maxDivisor = (int)Math.Sqrt(num);
//            for (int i = 2; i <= maxDivisor; i++)
//            {
//                if (num % i == 0)
//                {
//                    return false;
//                }
//            }

//            return true;
//        }
//        static IList<int> FindFirstNPrimes(int n)
//        {
//            var primes = new List<int>(n);
//            int p = 2;
//            while (primes.Count < n)
//            {
//                if (IsPrimeFast(p))
//                {
//                    primes.Add(p);
//                }
//                p++;
//            }

//            return primes;
//        }
//    }
//}
