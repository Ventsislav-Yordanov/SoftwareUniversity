/*Write a Boolean expression that returns if the bit at position p (counting from 0, starting from the right)
 * in given integer number n has value of 1. */
using System;

    class CheckABitAtGivenPosition
    {
        static void Main()
        {
            Console.Write("Enter number : ");
            uint number = UInt32.Parse(Console.ReadLine());
            Console.Write("Enter position : ");
            byte position = Byte.Parse(Console.ReadLine());
            uint numberRightPositions = number >> position;
            uint bit = numberRightPositions & 1;
            string binaryNumberString = Convert.ToString(number, 2).PadLeft(16, '0');
            Console.WriteLine("Binary representation : {0}", binaryNumberString);
            bool isBitOne = bit == 1;
            Console.WriteLine("bit #postion {0} == 1 ?  answer : {1}",position, isBitOne);
        }
    }