using System;
using System.Collections.Generic;
using System.Linq;

class WeAllLoveBits
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());

        int result = 0;

        for (int i = 0; i < n; i++)
        {
            int num = Int32.Parse(Console.ReadLine());

            result = 0; // reset for every number
            while (num > 0)
            {
                int lastBit = num & 1; // get last bit
                num = num >> 1;
                result = result << 1; //releasing the last position
                result = result | lastBit;
            } 
            Console.WriteLine(result);
        }
    }
}