using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class OddEvenSum
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());

        int oddSum = 0;
        int evenSum = 0;

        for (int i = 0; i < 2 * n; i++)
        {
            int number = Int32.Parse(Console.ReadLine());

            if (i % 2 != 0)
            {
                oddSum += number;   
            }
            else
            {
                evenSum += number;
            }
        }
        if (evenSum == oddSum)
        {
            Console.WriteLine("Yes, sum={0}", evenSum);
        }
        else
        {
            int difference = evenSum - oddSum;
            if (difference < 0)
            {
                difference *= -1;
            }
            Console.WriteLine("No, diff={0}", difference);
        }
    }
}