using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionCalculator
{
    class FractionCalculatorClass
    {
        public static void Main()
        {
            // http://www.math10.com/problems/bg/zadachi-ot-subirane-i-izvajdane-na-drobi/normal/
            Fraction fraction1 = new Fraction(1, 15);
            Fraction fraction2 = new Fraction(4, 5);
            Fraction result = fraction1 + fraction2;

            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);

            //Fraction fraction3 = new Fraction(9223372036854775807, 2);
            //Fraction fraction4 = new Fraction(23, 43);
            //Fraction divided = fraction3 + fraction4; // gives runtime error because number overflow
        }
    }
}
