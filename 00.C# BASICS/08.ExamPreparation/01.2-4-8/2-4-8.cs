using System;

class Program
{
    static void Main()
    {
        decimal a = Decimal.Parse(Console.ReadLine());
        decimal b = Decimal.Parse(Console.ReadLine());
        decimal c = Decimal.Parse(Console.ReadLine());

        decimal result = 0;

        if (b == 2)
        {
            result = a % c;
        }
        if (b == 4)
        {
            result = a + c;
        }
        if (b == 8)
        {
            result = a * c;
        }

        decimal remainder = result % 4;

        if (remainder == 0)
        {
            Console.WriteLine(result / 4);
        }
        else
        {
            Console.WriteLine(remainder);
        }

        Console.WriteLine(result);
    }
}