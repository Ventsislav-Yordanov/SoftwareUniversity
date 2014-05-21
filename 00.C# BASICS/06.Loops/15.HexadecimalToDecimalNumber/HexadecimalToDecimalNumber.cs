/*Using loops write a program that converts a hexadecimal integer number to its decimal form.
 * The input is entered as string. The output should be a variable of type long.
 * Do not use the built-in .NET functionality. */
using System;
using System.Globalization;

    class HexadecimalToDecimalNumber
    {
        static void Main()
        {
            Console.Write("Enter you hexadecimal value: ");
            string hexa = Console.ReadLine();

            long dec = long.Parse(hexa, NumberStyles.HexNumber);

            Console.WriteLine("Decimal : {0}",dec);
        }
    }