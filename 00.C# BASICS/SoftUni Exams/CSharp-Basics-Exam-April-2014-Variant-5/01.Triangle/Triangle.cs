using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Triangle
{
    static void Main()
    {
        int Ax = Int32.Parse(Console.ReadLine());
        int Ay = Int32.Parse(Console.ReadLine());
        int Bx = Int32.Parse(Console.ReadLine());
        int By = Int32.Parse(Console.ReadLine());
        int Cx = Int32.Parse(Console.ReadLine());
        int Cy = Int32.Parse(Console.ReadLine());

        double ab = Math.Sqrt(
            (Bx - Ax) * (Bx - Ax) +
            (By - Ay) * (By - Ay));

        double bc = Math.Sqrt(
            (Bx - Cx) * (Bx - Cx) +
            (By - Cy) * (By - Cy));

        double ac = Math.Sqrt(
            (Cx - Ax) * (Cx - Ax) +
            (Cy - Ay) * (Cy - Ay));

        bool areFormingTriangle = (ab + bc > ac && ab + ac > bc && ac + bc > ab);

        if (areFormingTriangle == true)
        {
            Console.WriteLine("Yes");
            double p = (ab + bc + ac) / 2;
            double area = Math.Sqrt(p * (p - ab) * (p - bc) * (p - ac));
            Console.WriteLine("{0:F2}",area);
        }
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0:F2}", ab);
        }
    }
}