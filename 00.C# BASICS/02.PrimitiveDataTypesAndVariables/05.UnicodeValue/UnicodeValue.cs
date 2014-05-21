/*Declare a character variable and assign it with the symbol that has Unicode code 72, and then print it.
 * Hint: first, use the Windows Calculator to find the hexadecimal representation of 72.
 * The output should be “H”.*/
using System;

    class UnicodeValue
    {
        static void Main()
        {
            int decValue = 72;
            string hexValue = decValue.ToString("X48");
            char symbol = Convert.ToChar(decValue);
            Console.WriteLine(symbol);
        }
    }
