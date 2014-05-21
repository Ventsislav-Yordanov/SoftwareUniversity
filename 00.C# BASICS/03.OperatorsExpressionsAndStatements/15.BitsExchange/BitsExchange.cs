/*Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer. */
using System;

    class BitsExchange
    {
        static void Main()
        {
            Console.Write("Enter number : ");
            uint number = UInt32.Parse(Console.ReadLine());
            string binaryNumberString = Convert.ToString(number, 2).PadLeft(32, '0');
            Console.WriteLine("Binary representation number#{0}: {1}", number, binaryNumberString);

            int position3 = 3;
            int position4 = 4;
            int position5 = 5;
            int position24 = 24;
            int position25 = 25;
            int position26 = 26;

            int bit3 = (int)(number >> position3) & 1;
            int bit4 = (int)(number >> position4) & 1;
            int bit5 = (int)(number >> position5) & 1;
            int bit24 = (int)(number >> position24) & 1;
            int bit25 = (int)(number >> position25) & 1;
            int bit26 = (int)(number >> position26) & 1;

            // binaryNumberString 1,2,3,4,5,6 show what happens

            number = number & (uint)(~(1 << position24)) | (uint)(bit3 << position24);

            //string binaryNumberString1 = Convert.ToString(number, 2).PadLeft(32, '0');
            //Console.WriteLine("Binary representation number#{0}: {1}", number, binaryNumberString1);

            number = number & (uint)(~(1 << position25)) | (uint)(bit4 << position25);

            //string binaryNumberString2 = Convert.ToString(number, 2).PadLeft(32, '0');
            //Console.WriteLine("Binary representation number#{0}: {1}", number, binaryNumberString2);

            number = number & (uint)(~(1 << position26)) | (uint)(bit5 << position26);

            //string binaryNumberString3 = Convert.ToString(number, 2).PadLeft(32, '0');
            //Console.WriteLine("Binary representation number#{0}: {1}", number, binaryNumberString3);

            number = number & (uint)(~(1 << position3)) | (uint)(bit24 << position3);

            //string binaryNumberString4 = Convert.ToString(number, 2).PadLeft(32, '0');
            //Console.WriteLine("Binary representation number#{0}: {1}", number, binaryNumberString4);

            number = number & (uint)(~(1 << position4)) | (uint)(bit25 << position4);

            //string binaryNumberString5 = Convert.ToString(number, 2).PadLeft(32, '0');
            //Console.WriteLine("Binary representation number#{0}: {1}", number, binaryNumberString5);

            number = number & (uint)(~(1 << position5)) | (uint)(bit26 << position5);

            //string binaryNumberString6 = Convert.ToString(number, 2).PadLeft(32, '0');
            //Console.WriteLine("Binary representation number#{0}: {1}", number, binaryNumberString6);

            Console.WriteLine();
            Console.WriteLine("Result : {0}", number);
            string binaryNumber = Convert.ToString(number, 2).PadLeft(32, '0');
            Console.WriteLine("Binary representation number#{0}: {1}", number, binaryNumber);
        }
    }