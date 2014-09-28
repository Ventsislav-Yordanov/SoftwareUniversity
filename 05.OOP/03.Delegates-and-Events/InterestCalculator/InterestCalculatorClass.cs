using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InterestCalculator
{
    class InterestCalculatorClass
    {
        static void Main(string[] args) //shortcut for static void Main(string[] args) : svm + tab + tab
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            InterestCalculator interestCalc1 = new InterestCalculator(500m, 5.6m, 10, GetCompoundInterest);
            Console.WriteLine("{0:F4}", interestCalc1.Result);

            InterestCalculator interestCalc2 = new InterestCalculator(2500m, 7.2m, 15, GetSimpleInterest);
            Console.WriteLine("{0:F4}", interestCalc2.Result);
        }

        private static decimal GetSimpleInterest(decimal moneySum, decimal interest, int years)
        {
            decimal result = moneySum * (1 + (interest / 100) * years);
            return result;
        }

        private static decimal GetCompoundInterest(decimal moneySum, decimal interest, int years)
        {
            decimal result = moneySum * (decimal)Math.Pow((double)(1 + (interest / 100) / 12), 12 * years);
            return result;
        }
    }
}
