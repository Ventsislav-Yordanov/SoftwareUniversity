/*We are given an integer number n, a bit value v (v=0 or 1) and a position p.
 * Write a sequence of operators (a few lines of C# code) that modifies n to hold the value v
 * at the position p from the binary representation of n while preserving all other bits in n.*/
using System;

    class ModifyABitAtGivenPosition
    {
        static void Main()
        {
            Console.Write("Enter number : ");
            int number = Int32.Parse(Console.ReadLine());
            Console.Write("Enter position : ");
            byte position = Byte.Parse(Console.ReadLine());
            Console.Write("Enter value : ");
            byte value = Byte.Parse(Console.ReadLine());
            string binaryNumberString = Convert.ToString(number, 2).PadLeft(16, '0');
            Console.WriteLine("Binary representation number#{0}: {1}",number, binaryNumberString);
            if (value == 0)
            {
                int mask = ~(1 << position);
                int result = number & mask;
                string binaryNumber = Convert.ToString(result, 2).PadLeft(16, '0');
                Console.WriteLine("Result : {0}", result);
                Console.WriteLine("Binary result number#{0}: {1}", result, binaryNumber);
            }
            else
            {
                int mask = 1 << position;
                int result = number | mask;
                string binaryNumber = Convert.ToString(result, 2).PadLeft(16, '0');
                Console.WriteLine("Result : {0}", result);
                Console.WriteLine("Binary result number#{0}: {1}", result, binaryNumber);
            }
        }
    }