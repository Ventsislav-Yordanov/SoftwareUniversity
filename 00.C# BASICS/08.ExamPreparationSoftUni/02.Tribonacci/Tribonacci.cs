using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Tribonacci
{
    static void Main(string[] args)
    {
        BigInteger t1 = long.Parse(Console.ReadLine());
        BigInteger t2 = long.Parse(Console.ReadLine());
        BigInteger t3 = long.Parse(Console.ReadLine());
        int n = Int32.Parse(Console.ReadLine());

        if (n == 1)
        {
            Console.WriteLine(t1);
        }
        else if (n == 2)
        {
            Console.WriteLine(t2);
        }
        else if (n == 3)
        {
            Console.WriteLine(t3);
        }
        else
        {
            BigInteger tn = 0;
            for (int i = 4; i <= n; i++)
            {
                tn = t1 + t2 + t3;
                t1 = t2;
                t2 = t3;
                t3 = tn;
            }
            Console.WriteLine(tn);
        }
        
    }
}