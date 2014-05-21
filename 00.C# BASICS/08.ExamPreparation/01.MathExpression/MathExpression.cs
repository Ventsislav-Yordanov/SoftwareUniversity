/* Condition : https://www.dropbox.com/s/atcnql1nhwwolpa/Problem%201%20-%20Math%20Expression.doc */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


    class MathExpression
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            string inputN = Console.ReadLine();
            string inputM = Console.ReadLine();
            string inputP = Console.ReadLine();

            double n = Double.Parse(inputN);
            double m = Double.Parse(inputM);
            double p = Double.Parse(inputP);

            const double numberNom = 1337;
            const double numberDenom = 128.523123123;

            double nominator = n * n + 1 / (m * p) + numberNom;
            double denominator = n - numberDenom * p;

            double result = nominator / denominator + Math.Sin((int)m % 180);
            Console.WriteLine("{0:F6}",result);
        }
    }