/*Write an expression that extracts from given integer n the value of given bit at index p. */
using System;

    class ExtractBitFromInteger
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
            Console.WriteLine("The bit #{0} is {1}",position, bit);
        }
    }