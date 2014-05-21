using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BinaryDigitsCount
{
    static void Main()
    {
        byte binaryDigit = Byte.Parse(Console.ReadLine());
        int numbers = Int32.Parse(Console.ReadLine());
        int count = 0;

        for (int i = 0; i < numbers; i++)
        {
            long number = long.Parse(Console.ReadLine());
            string binaryNumberString = Convert.ToString(number, 2);

            for (int j = 0; j < binaryNumberString.Length; j++)
            {
                if (byte.Parse(binaryNumberString[j].ToString()) == binaryDigit)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            count = 0;
        }
    }
}