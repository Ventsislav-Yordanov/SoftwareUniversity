/*Write an expression that checks if given positive integer number n (n ≤ 100) is prime(
 * i.e. it is divisible without remainder only to itself and 1). */
using System;

    class PrimeNumberCheck
    {
        static void Main()
        {
            // first variant 

            Console.Write("Enter positive integer number n between 2 and 100 : ");
            int numberN = int.Parse(Console.ReadLine());
            while (numberN < 2 || numberN > 100)
            {
                Console.Write("Try again : ");
                numberN = int.Parse(Console.ReadLine());
            }
            bool isPrime = true;
            int counter = 1;
            //Trial division
            while (counter <= Math.Sqrt(numberN))
            {
                if (numberN % counter == 0 && counter > 1)
                {
                    isPrime = false;
                }
                counter++;
            }
            Console.WriteLine("Is your number prime? Answer : {0}", isPrime);



            //  second variant
            //Console.Write("Insert the number that you want to check : ");
            //int num = int.Parse(Console.ReadLine());
            //bool isPrime = true;

            //for (int i = 2; i < num; i++)
            //{
            //    if (num % i == 0)
            //    {
            //        isPrime = false;
            //    }
            //}

            //Console.WriteLine("Is your number prime? Anser : {0}", isPrime);
        }
    }