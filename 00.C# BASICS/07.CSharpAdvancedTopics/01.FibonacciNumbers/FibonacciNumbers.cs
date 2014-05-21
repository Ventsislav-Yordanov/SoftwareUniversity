﻿/* Problem 1. Fibonacci Numbers
   Define a method Fib(n) that calculates 
   the nth Fibonacci number. 
   Examples: n = 11, Fib(n) = 144
             n = 0	 Fib(n) = 1
             n = 1	 Fib(n) = 1
             n = 2	 Fib(n) = 2
             n = 3	 Fib(n) = 3
             n = 4	 Fib(n) = 5
             n = 5	 Fib(n) = 8
             n = 6	 Fib(n) = 13
             n = 11	 Fib(n) = 144
             n = 25	 Fib(n) = 121393  */

using System;
using System.Numerics;

class Fibonacci
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger result = Fib(n);

        Console.WriteLine(result);
    }

    private static BigInteger Fib(int n)
    {
        BigInteger firstNum = 0;
        BigInteger secondNum = 1;
        BigInteger nextNum;

        if (n == 1) 
            return firstNum;
        if (n == 2) 
            return secondNum;
        else
        {

            for (int i = 1; i <= n; i++)
            {
                nextNum = firstNum + secondNum;
                firstNum = secondNum;
                secondNum = nextNum;

                if (i == n)
                {
                    return nextNum;
                }
            }
        }

        return 0;
    }
}

