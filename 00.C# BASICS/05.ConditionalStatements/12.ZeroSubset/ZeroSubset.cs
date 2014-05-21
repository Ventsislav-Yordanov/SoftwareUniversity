/*We are given 5 integer numbers. Write a program that finds all subsets of these numbers whose sum is 0.
 * Assume that repeating the same subset several times is not a problem.*/
using System;
using System.Linq;

    class ZeroSubset
    {
        static void Main()
        {
            int n1 = 0;
            int n2 = 0;
            int n3 = 0;
            int n4 = 0;
            int n5 = 0;
            bool noZero = true;

            Console.WriteLine("Please type 5 integer numbers: ");
            bool isValid = false;
            while (!isValid)
            {
                Console.Write("<1>: ");
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out n1);
            }
            isValid = false;

            while (!isValid)
            {
                Console.Write("<2>: ");
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out n2);
            }
            isValid = false;

            while (!isValid)
            {
                Console.Write("<3>: ");
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out n3);
            }
            isValid = false;

            while (!isValid)
            {
                Console.Write("<4>: ");
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out n4);
            }
            isValid = false;

            while (!isValid)
            {
                Console.Write("<5>: ");
                string input = Console.ReadLine();
                isValid = int.TryParse(input, out n5);
            }
            isValid = false;

            int k1;
            int k2;
            int k3;
            int k4;
            int k5;

            for (int counter = 1; counter < 32; counter++)
            {
                k1 = counter & 1;
                k2 = (counter & 3) >> 1;
                k3 = (counter & 5) >> 2;
                k4 = (counter & 9) >> 3;
                k5 = (counter & 17) >> 4;
                int sum = n1 * k1 + n2 * k2 + n3 * k3 + n4 * k4 + n5 * k5;

                if ((sum == 0) && (counter != 2) && (counter != 4) && (counter != 8) && (counter != 16))
                {
                    Console.WriteLine("Zero subset:");
                    if (k1 != 0) Console.Write(n1 + " ");
                    if (k2 != 0) Console.Write(n2 + " ");
                    if (k3 != 0) Console.Write(n3 + " ");
                    if (k4 != 0) Console.Write(n4 + " ");
                    if (k5 != 0) Console.Write(n5);
                    Console.WriteLine();
                    noZero = false;
                }
            }
            if (noZero == true) Console.WriteLine("No zero subset.");
        }
    }