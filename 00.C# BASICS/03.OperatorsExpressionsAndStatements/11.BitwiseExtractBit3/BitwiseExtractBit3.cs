/*Using bitwise operators, write an expression for finding the value of the bit #3 of a given unsigned integer.
 * The bits are counted from right to left, starting from bit #0.
 * The result of the expression should be either 1 or 0. */
using System;

    class BitwiseExtractBit3
    {
        static void Main()
        {
            Console.Write("Enter number : ");
            uint number = UInt32.Parse(Console.ReadLine());
            byte position = 3;
            uint numberRightPositions = number >> position;
            uint bit = numberRightPositions & 1;
            string binaryNumberString = Convert.ToString(number, 2).PadLeft(16,'0');
            Console.WriteLine("Binary representation : {0}",binaryNumberString);
            Console.WriteLine("The bit #3 is {0}", bit);
        }
    }