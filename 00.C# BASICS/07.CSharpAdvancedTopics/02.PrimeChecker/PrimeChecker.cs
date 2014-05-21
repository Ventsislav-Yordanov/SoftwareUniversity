﻿// Problem 2. Prime Checker
// Write a Boolean method IsPrime(n) that check whether 
// a given integer number n is prime. Examples: 
// n = 5. IsPrime(n) = true; n = 323, IsPrime(n) = false

using System;
using System.Numerics;

class CheckPrime
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number for n ");
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        bool isPrime = true;
        Console.WriteLine("The number {0} is {1}", n, IsPrimeNumber(n, isPrime));
    }
    static bool IsPrimeNumber(int n, bool isPrime)
    {
        if (n == 0 || n == 1 || 0 > n)
        {
            isPrime = false;
            return isPrime;
        }
        int counter = 0;

        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                counter++;
            }
        }
        if (counter > 2)
        {
            isPrime = false;
            return isPrime;
        }
        isPrime = true;
        return isPrime;
    }
}

