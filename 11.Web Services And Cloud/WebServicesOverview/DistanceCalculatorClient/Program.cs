using System;

using DistanceCalculatorClient.ServiceReferenceCalculator;

namespace DistanceCalculatorClient
{
    class Program
    {
        static void Main()
        {
            CalculatorClient calculator = new CalculatorClient();
            var result = calculator.CalculateDistance(
                new Point() { X = 3, Y = 4 },
                new Point() { X = -3, Y = -5 }
            );

            Console.WriteLine(result);
            calculator.Close();
        }
    }
}
