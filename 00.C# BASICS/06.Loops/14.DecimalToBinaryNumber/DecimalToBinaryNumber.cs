/*Using loops write a program that converts an integer number to its binary representation.
 * The input is entered as long.The output should be a variable of type string.
 * Do not use the built-in .NET functionality. */
using System;

    class DecimalToBinaryNumber
    {
        static void Main()
        {
            Console.Write("Enter Decimal number : ");
            long dec = long.Parse(Console.ReadLine());

            long rest;
            string binary = string.Empty;

            while (dec > 0)
            {
                rest = dec % 2;
                dec = dec / 2;
                binary = rest.ToString() + binary;
            }
            Console.WriteLine("Binary result : {0}",binary);
        }
    }