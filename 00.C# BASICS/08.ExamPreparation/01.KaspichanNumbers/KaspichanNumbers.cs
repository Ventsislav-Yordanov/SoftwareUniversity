using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class KaspichanNumbers
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        List<string> digits = new List<string>();

        for (char i = 'A'; i <= 'Z'; i++) // adding Capital number to list
        {
            digits.Add(i.ToString());
        }

        for (char i = 'a'; i <= 'i'; i++)
        {
            for (char j = 'A'; j <= 'Z'; j++)
            {
                digits.Add(i.ToString() + j.ToString());
            }
        }

        //foreach (var item in digits)
        //{
        //    Console.Write(item + " ");
        //}

        string result = "";

        if (n == 0)
        {
            Console.WriteLine("A");
        }

        while (n != 0)
        {
            result = digits[(int)(n % 256)] + result;
            n = n / 256;
        }
        Console.WriteLine(result);
    }
}