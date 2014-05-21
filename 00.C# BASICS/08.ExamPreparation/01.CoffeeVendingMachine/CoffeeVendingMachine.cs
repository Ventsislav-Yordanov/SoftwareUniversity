using System;
using System.Threading;

class CoffeeVendingMachine
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        double n1 = double.Parse(Console.ReadLine()); //0.05
        double n2 = double.Parse(Console.ReadLine()); //0.10
        double n3 = double.Parse(Console.ReadLine()); //0.20
        double n4 = double.Parse(Console.ReadLine()); //0.50
        double n5 = double.Parse(Console.ReadLine()); //1.00
        double amaunt = double.Parse(Console.ReadLine()); // amaunt human
        double price = double.Parse(Console.ReadLine());  //price prodcut

        double n1Sum = 0.05 * n1;
        double n2Sum = 0.10 * n2;
        double n3Sum = 0.20 * n3;
        double n4Sum = 0.50 * n4;
        double n5Sum = 1.00 * n5;
        double totalSum = n1Sum + n2Sum + n3Sum + n4Sum + n5Sum;
        double change = amaunt - price;

        if (amaunt >= price)
        {
            if (totalSum >= change)
            {
                Console.WriteLine("Yes {0:F2}", totalSum - change);
            }
            else if (totalSum < change)
            {
                Console.WriteLine("No {0:F2}", change - totalSum);
            }
        }
        else if (amaunt < price)
        {
            Console.WriteLine("More {0:F2}", price - amaunt);
        }
    }
}