namespace EgyptianFractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EgyptianFractionsExample
    {
        static void Main()
        {
            var fractionInfo = Console.ReadLine()
                .Split('/')
                .Select(int.Parse)
                .ToArray();
            int numerator = fractionInfo[0];
            int denominator = fractionInfo[1];
            if (numerator >= denominator)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            var number = new Fraction(numerator, denominator);
            var resultFractions = new List<Fraction>();
            while (number.Numerator > 0)
            {
                int smallerDenominator = 2;
                while (number.CompareTo(new Fraction(1, smallerDenominator)) < 0)
                {
                    smallerDenominator++;
                }

                var biggestFraction = new Fraction(1, smallerDenominator);
                resultFractions.Add(biggestFraction);

                if (number.CompareTo(biggestFraction) == 0)
                {
                    break;
                }

                number -= biggestFraction;
            }

            Console.WriteLine($"{numerator}/{denominator} = {string.Join(" + ", resultFractions)}");
        }
    }
}
