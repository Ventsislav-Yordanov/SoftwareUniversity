using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class HalfSum
{
    static void Main()
    {
        int n = Int32.Parse(Console.ReadLine());

        int[] numbers = new int[n * 2];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = Int32.Parse(Console.ReadLine());
        }

        int firstSum = 0;
        int SecondSum = 0;

        for (int i = 0; i <= numbers.Length/2 - 1; i++)
        {
            firstSum = firstSum + numbers[i];
        }

        for (int i = numbers.Length/2 ; i < numbers.Length; i++)
        {
            SecondSum = SecondSum + numbers[i];
        }

        if (firstSum == SecondSum)
        {
            Console.WriteLine("Yes, sum={0}",firstSum);
        }
        else
        {
            int difference = firstSum - SecondSum;
            
            if (difference < 0)
	        {
	        	 difference = difference * (-1);
	        }

            Console.WriteLine("No, diff={0}",difference);
        }
    }
}