/*Write a program that exchanges bits {p, p+1, …, p+k-1} with bits {q, q+1, …, q+k-1} 
 * of a given 32-bit unsigned integer. The first and the second sequence of bits may not overlap.*/
using System;

    class BitExchangeAdvanced
    {
        static void Main()
        {
            Console.Write("Enter an unsigned integer : ");
            long number = long.Parse(Console.ReadLine());
            string binaryNumberString = Convert.ToString(number, 2).PadLeft(32, '0');
            Console.WriteLine("Binary representation number#{0}: {1}", number, binaryNumberString);
            Console.WriteLine();
            Console.Write("Enter the first position you would like to exchange : ");
            int p = int.Parse(Console.ReadLine());
            Console.Write("Enter the second position you would like to exchange with the first position : ");
            int q = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of bits you would like to exchange inbetween : ");
            int k = int.Parse(Console.ReadLine());
            int bitP;
            int bitQ;

            if (p + k > 32 || q + k > 32)
            {
                Console.WriteLine("Result : Out of range");
                return;
            }

            if ((p < q && p + k - 1 >= q) || (p > q && q + k - 1 >= p) || p == q)
            {
                Console.WriteLine("Result : Overlapping");
                return;
            }

            for (int count = 0; count < k; count++)
            {
                bitP = (int)(number >> p) & 1;
                bitQ = (int)(number >> q) & 1;

                number = number & (uint)(~(1 << q)) | (uint)(bitP << q);
                number = number & (uint)(~(1 << p)) | (uint)(bitQ << p);

                p++;
                q++;
            }
            Console.WriteLine();
            string binaryNumberResult = Convert.ToString(number, 2).PadLeft(32, '0');
            Console.WriteLine("Binary result : {0}",binaryNumberResult);
            Console.WriteLine("Result : {0}",number);
        }
    }