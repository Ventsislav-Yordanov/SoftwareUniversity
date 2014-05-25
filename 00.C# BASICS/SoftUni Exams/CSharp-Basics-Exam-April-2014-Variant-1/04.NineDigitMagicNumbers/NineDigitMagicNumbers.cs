using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NineDigitMagicNumbers
{
    static void Main()
    {
        int sum = Int32.Parse(Console.ReadLine());
        int diff = Int32.Parse(Console.ReadLine());
        int resultsCount = 0;

        for (int num1 = 111; num1 <= 777; num1++)
        {
            int num2 = num1 + diff;
            int num3 = num2 + diff;

            if (IsAllowedNumber(num1) && IsAllowedNumber(num2) && IsAllowedNumber(num3) &&
                (num3 <= 777) &&
                CalcSumOfDigits(num1) + CalcSumOfDigits(num2) + CalcSumOfDigits(num3) == sum)
            {
                Console.WriteLine("{0}{1}{2}", num1, num2, num3);
                resultsCount++;
            }
        }

        if (resultsCount == 0)
        {
            Console.WriteLine("No");
        }
    }

    private static int CalcSumOfDigits(int num)
    {
        int sum = 0;
        while (num > 0)
        {
            sum += num % 10;
            num = num / 10;
        }
        return sum;
    }

    private static bool IsAllowedNumber(int num)
    {
        string digits = num.ToString();
        foreach (var digit in digits)
        {
            if (digit < '1' || digit > '7')
            {
                return false;
            }
        }
        return true;
    }
}